using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Application.Core.Persistence.Repositories.UserOtp;
using ModuleTech.Application.Core.Persistence.UoW;
using ModuleTech.Application.DTOs.Identity.Request;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.Auth.DTOs.B2BUser;
using ModuleTech.Application.Helpers;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.Dtos;
using ModuleTech.Core.ExceptionHandling.Exceptions;
using ModuleTech.Domain;
using ModuleTech.Domain.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.Options;
using Serilog;
using System.Text.RegularExpressions;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.Identity.Infrastructure.Services;

public class AuthB2BService : IAuthB2BService
{
    private readonly IModuleTechUnitOfWork _moduleTechUnitOfWork;
    private readonly IUserB2BRepository _userB2BRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly KeycloakOptions _keycloakOptions;
    private readonly OtpOptions _otpOptions;
    private readonly IUserB2BService _userB2BService;
    private readonly IUserOTPRepository _userOTPRepository;
    private readonly IUserResetPasswordRepository _userResetPasswordRepository;
    private readonly IIdentityB2BService _identityB2BService;
    private readonly HeaderContext _headerContext;
    private static readonly Serilog.ILogger Logger = Log.ForContext<UserB2BService>();

    public AuthB2BService(IModuleTechUnitOfWork moduleTechUnitOfWork,
                                 IMapper mapper,
                                 IUserB2BRepository userB2BRepository,
                                 IUserRepository userRepository,
                                 IOptions<KeycloakOptions> options,
                                 IOptions<OtpOptions> otpOptions,
                                 IUserB2BService userB2BService,
                                 IUserOTPRepository userOTPRepository,
                                 HeaderContext headerContext,
                                 IUserResetPasswordRepository userResetPasswordRepository,
                                 IIdentityB2BService identityB2BService)
    {
        _moduleTechUnitOfWork = moduleTechUnitOfWork;
        _mapper = mapper;
        _keycloakOptions = options.Value;
        _otpOptions = otpOptions.Value;
        _userB2BRepository = userB2BRepository;
        _userRepository = userRepository;
        _userB2BService = userB2BService;
        _userOTPRepository = userOTPRepository;
        _headerContext = headerContext;
        _userResetPasswordRepository = userResetPasswordRepository;
        _identityB2BService = identityB2BService;
    }

    public async Task<AuthenticationDTO> B2BLoginAsync(B2BLoginDTO loginDTO, CancellationToken cancellationToken)
    {
        await ValidateB2BLoginAsync(loginDTO, cancellationToken);

        var result = await _identityB2BService.LoginAsync(loginDTO, cancellationToken);

        return _mapper.Map<AuthenticationDTO>(result);
    }


    public async Task<AuthenticationDTO> B2BRefreshTokenLoginAsync(string refreshToken, CancellationToken cancellationToken)
    {
        AuthenticationDTO authentication = await _identityB2BService.RefreshTokenLoginAsync(refreshToken, cancellationToken);
        return _mapper.Map<AuthenticationDTO>(authentication);
    }

    public async Task<SignUpDTO> B2BSignUpAsync(B2BSignupCommandDTO model, CancellationToken cancellationToken)
    {
        var hasExistsEmail = await _userRepository.AnotherUserHasEmailAsync(null, UserTypeEnum.B2B, model.Email, cancellationToken);
        if (hasExistsEmail)
            throw new ValidationException(UserStatusCodes.EmailConflict.Message, UserStatusCodes.EmailConflict.StatusCode);

        User userEntity = B2BSignupCommandToUser(model);

        UserB2B userB2BEntity = B2BSignupCommandToUserB2B(model, userEntity);


        #region Identity user insert
        CreateIdentityUserRequestDto createIdentityUserRequestDto = new CreateIdentityUserRequestDto
        {
            UserId = userEntity.Id,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password
        };


        var identityUser = await _identityB2BService.CreateUserAsync(createIdentityUserRequestDto, cancellationToken);

        if (identityUser.IsSuccess == false)
            throw new ValidationException(UserStatusCodes.KeycloakError.Message, UserStatusCodes.KeycloakError.StatusCode);

        #endregion


        userB2BEntity.User.IdentityRefId = identityUser.IdentityRefId;




        #region user and userB2B insert

        await _userB2BRepository.AddAsync(userB2BEntity, cancellationToken);

        #endregion

        //#region UserConfirmRegisterType insert

        //foreach (var confirmRegister in model.ConfirmRegisters)
        //{
        //    await _userConfirmRegisterTypeRepository.AddAsync(
        //        new UserConfirmRegisterType()
        //        {
        //            UserId = userB2BEntity.User.Id,
        //            ConfirmRegisterTypeId = Convert.ToInt32(confirmRegister)
        //        });
        //}
        //#endregion
        var userOTP = await AddUserOtpAsync(userB2BEntity.UserId, userB2BEntity.Phone, userB2BEntity.User.Email, OtpTypeEnum.SignUp, UserTypeEnum.B2B, VerificationTypeEnum.Email, cancellationToken);

        try
        {
            await _moduleTechUnitOfWork.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            var isUserDeleted = await _identityB2BService.DeleteUserAsync(identityUser.IdentityRefId, cancellationToken);

            if (!isUserDeleted)
            {
                Logger.ForContext("KeycloakUserId", identityUser.IdentityRefId).Error("There is an error when trying to create b2b user. Keycloak user can not be rollbacked...");
            }
         
            throw;
        }


        var authentication = await B2BLoginAsync(new B2BLoginDTO() { Email = model.Email, Password = model.Password }, cancellationToken);

        return new SignUpDTO() { TransactionId = userOTP.Id, OTPCode = userOTP.OtpCode, authenticationDTO = authentication };
    }


    private UserB2B B2BSignupCommandToUserB2B(B2BSignupCommandDTO model, User userEntity)
    {
        return new UserB2B
        {
            User = userEntity,
            UserId = userEntity.Id,
            CityId = model.CityId,
            CountryId = model.CountryId,
            Phone = model.Phone,
            PhoneCountryCode = model.PhoneCountryCode,
            SiteStatus = SiteStatusEnum.Closed,
            UserStatus = UserStatusEnum.Active
        };
    }

    private User B2BSignupCommandToUser(B2BSignupCommandDTO model)
    {
        return new User
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Suffix = model.Suffix
        };
    }

    public async Task<bool> B2BVerifyOtpAsync(VerifyOtpDTO model, CancellationToken cancellationToken)
    {
        var userOtpDetail = await _userOTPRepository.GetVerifyByIdAsync(model.TransactionId, UserTypeEnum.B2B, OtpTypeEnum.SignUp, cancellationToken);
       
        var userB2BEntity = await _userB2BRepository.GetById(userOtpDetail.UserId, cancellationToken);

        if (userB2BEntity == null)
            throw new ApiException(B2BUserConstants.RecordNotFound);

        if (userOtpDetail == null)
            throw new ApiException("Expire Time Süresi Aşıldı. Uygun kayıt bulunamadı.");

        if (userOtpDetail.OtpCode != model.OtpCode)
            throw new ApiException("OtpCode Hatalı!");

        userOtpDetail.IsVerified = true;
        userOtpDetail.VerificationDate = DateTime.UtcNow;
        _userOTPRepository.Update(userOtpDetail);

        userB2BEntity.SiteStatus = SiteStatusEnum.Open;
        _userB2BRepository.Update(userB2BEntity);

        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        return true;
    }

    public async Task<ResendOtpDTO> B2BResendOtpAsync(CancellationToken cancellationToken)
    {
        UserB2B userB2BEntity = await ValidateB2BResendOtpAsync(cancellationToken);
        var userOTP = await AddUserOtpAsync(userB2BEntity.UserId, userB2BEntity.Phone, userB2BEntity.User.Email, OtpTypeEnum.SignUp, UserTypeEnum.B2B, VerificationTypeEnum.Email, cancellationToken);

        userB2BEntity.SiteStatus = SiteStatusEnum.Open;
        _userB2BRepository.Update(userB2BEntity);

        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        return new ResendOtpDTO() { TransactionId = userOTP.Id, OTPCode = userOTP.OtpCode };
    }

    public async Task<VerifyOtpDTO> ResetPasswordAsync(ResetPasswordCommandDTO resetPasswordCommandDTO, UserTypeEnum platform, CancellationToken cancellationToken)
    {
        var userDetail = await _userRepository.GetByEmailAsync(resetPasswordCommandDTO.Email, platform, cancellationToken);

        if (userDetail == null)
            throw new ValidationException(UserStatusCodes.UserNotFound.Message, UserStatusCodes.UserNotFound.StatusCode);

        UserOTP userOtp = SetUserOtp(resetPasswordCommandDTO.Email, platform, userDetail.Id);

        _userOTPRepository.Add(userOtp);

        UserResetPassword userResetPassword = SetUserResetPassword(userDetail.Id, userOtp.Id);

        _userResetPasswordRepository.Add(userResetPassword);

        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);
        return new VerifyOtpDTO() { TransactionId = userOtp.Id, OtpCode = userOtp.OtpCode };
    }

    public async Task<ResetVerifyOtpDTO> ResetVerifyOtpAsync(VerifyOtpDTO model, UserTypeEnum platform, CancellationToken cancellationToken)
    {
        var userOtpDetail = await _userOTPRepository.GetVerifyByIdAsync(model.TransactionId, platform, OtpTypeEnum.ResetPassword, cancellationToken);

        if (userOtpDetail == null)
            throw new ApiException("Reset Expire Time Süresi Aşıldı. Uygun kayıt bulunamadı.");

        if (userOtpDetail.OtpCode != model.OtpCode)
            throw new ApiException("OtpCode Hatalı!");

        userOtpDetail.IsVerified = true;
        userOtpDetail.VerificationDate = DateTime.UtcNow;
        _userOTPRepository.Update(userOtpDetail);

        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        return new ResetVerifyOtpDTO() { TransactionId = userOtpDetail.UserResetPassword.Id };
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordCommandDTO model, string realm, CancellationToken cancellationToken)
    {
        UserResetPassword resetPasswordDetail = await _userResetPasswordRepository.GetVerifyByIdAsync(model.TransactionId, cancellationToken);

        User userDetail = await ValidateChangePasswordAsync(resetPasswordDetail, cancellationToken);

        resetPasswordDetail.IsUsed = true;
        resetPasswordDetail.ResetPasswordDate = DateTime.UtcNow;
        _userResetPasswordRepository.Update(resetPasswordDetail);

        UpdateIdentityUserPasswordRequestDto updateIdentityUserPasswordRequestDto = new UpdateIdentityUserPasswordRequestDto
        {
            IdentityRefId = userDetail.IdentityRefId,
            Password = model.Password
        };
        var result = await _identityB2BService.UpdateUserPasswordAsync(updateIdentityUserPasswordRequestDto, cancellationToken);

        if (result)
        {
            await _moduleTechUnitOfWork.CommitAsync(cancellationToken);
            return true;
        }

        return false;
    }

    private async Task<User> ValidateChangePasswordAsync(UserResetPassword resetPasswordDetail, CancellationToken cancellationToken)
    {
        if (resetPasswordDetail == null)
            throw new ApiException("Expire Time Süresi Aşıldı. Uygun kayıt bulunamadı.");

        var userDetail = await _userRepository.GetById(resetPasswordDetail.UserId, cancellationToken);

        if (userDetail == null)
            throw new ValidationException(UserStatusCodes.UserNotFound.Message, UserStatusCodes.UserNotFound.StatusCode);

        return userDetail;
    }

    private async Task ValidateB2BLoginAsync(B2BLoginDTO loginDTO, CancellationToken cancellationToken)
    {
        if (RegexEmail(loginDTO.Email))
        {
            UserB2B userB2BEntity = await _userB2BRepository.GetByEmailAsync(loginDTO.Email, cancellationToken);

            if (userB2BEntity == null)
                throw new ValidationException(UserStatusCodes.UserNotFound.Message, UserStatusCodes.UserNotFound.StatusCode);
            else if (userB2BEntity.SiteStatus == SiteStatusEnum.Closed)
                throw new ValidationException(UserStatusCodes.UserInActive.Message, UserStatusCodes.UserInActive.StatusCode);
        }
        else
        { throw new ValidationException(UserStatusCodes.InvalidEmail.Message, UserStatusCodes.InvalidEmail.StatusCode); }
    }

    private UserResetPassword SetUserResetPassword(Guid userId, Guid transactionId)
    {
        return new UserResetPassword()
        {
            CreatedDate = DateTime.UtcNow,
            IsUsed = false,
            ExpireDate = DateTimeHelper.AddSecondsUtc(_otpOptions.reset_expire_time),
            UserId = userId,
            UserOtpId = transactionId
        };
    }

    private UserOTP SetUserOtp(string email, UserTypeEnum platform, Guid userId)
    {
        return new UserOTP
        {
            Email = email,
            ExpireDate = DateTimeHelper.AddSecondsUtc(_otpOptions.expire_time),
            VerificationType = VerificationTypeEnum.Email,
            OtpCode = GenerateOTP(),
            OtpType = OtpTypeEnum.ResetPassword,
            IsVerified = false,
            Platform = platform,
            UserId = userId,
            CreatedDate = DateTime.UtcNow
        };
    }

    private string GenerateOTP()
    {
        string numbers = NumberSequence;
        string otp = string.Empty;
        for (int i = 0; i < OtpLenght; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, numbers.Length);
                character = numbers.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;
        }
        return otp;
    }

    private bool RegexPhone(string EmailOrPhone)
    {
        Regex validatePhoneNumberRegex = new Regex("^\\+?[1-9][0-9]{3,15}$");
        return validatePhoneNumberRegex.IsMatch(EmailOrPhone);
    }

    private bool RegexEmail(string EmailOrPhone)
    {
        Regex validateEmailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
        return validateEmailRegex.IsMatch(EmailOrPhone);
    }

    private async Task<UserOTP> AddUserOtpAsync(Guid userId, string? phone, string? email, OtpTypeEnum otpType, UserTypeEnum platform, VerificationTypeEnum verificationMethod, CancellationToken cancellationToken)
    {
        UserOTP userOTP = new UserOTP
        {
            UserId = userId,
            Phone = phone,
            Email = email,
            ExpireDate = DateTimeHelper.AddSecondsUtc(_otpOptions.expire_time),
            OtpCode = GenerateOTP(),
            IsVerified = false,
            OtpType = otpType,
            Platform = platform,
            VerificationType = verificationMethod,
            CreatedDate = DateTime.UtcNow
        };

        await _userOTPRepository.AddAsync(userOTP, cancellationToken);
        return userOTP;
    }

    private async Task<UserB2B> ValidateB2BResendOtpAsync(CancellationToken cancellationToken)
    {
        var userB2BEntity = await _userB2BRepository.GetById(_headerContext.ODRefId.Value, cancellationToken);

        if (userB2BEntity == null)
            throw new ApiException(B2BUserConstants.RecordNotFound);

        var isVerified = await _userOTPRepository.IsVerifiedAsync(_headerContext.ODRefId.Value, UserTypeEnum.B2B, OtpTypeEnum.SignUp, cancellationToken);

        if (isVerified)
            throw new ApiException(IsVerifiedUser);
        return userB2BEntity;
    }
}
