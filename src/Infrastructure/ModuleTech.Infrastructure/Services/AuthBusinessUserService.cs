using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Application.Core.Persistence.Repositories.UserOtp;
using ModuleTech.Application.Core.Persistence.UoW;
using ModuleTech.Application.DTOs.Identity.Request;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;
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

public class AuthBusinessUserService : IAuthBusinessUserService
{
    private readonly IModuleTechUnitOfWork _moduleTechUnitOfWork;
    private readonly IBusinessUserRepository _businessUserRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly KeycloakOptions _keycloakOptions;
    private readonly OtpOptions _otpOptions;
    private readonly IBusinessUserService _businessUserService;
    private readonly IUserOTPRepository _userOTPRepository;
    private readonly IUserResetPasswordRepository _userResetPasswordRepository;
    private readonly IIdentityBusinessUserService _identityBusinessUserService;
    private readonly HeaderContext _headerContext;
    private static readonly Serilog.ILogger Logger = Log.ForContext<BusinessUserService>();

    public AuthBusinessUserService(IModuleTechUnitOfWork moduleTechUnitOfWork,
                                 IMapper mapper,
                                 IBusinessUserRepository businessUserRepository,
                                 IUserRepository userRepository,
                                 IOptions<KeycloakOptions> options,
                                 IOptions<OtpOptions> otpOptions,
                                 IBusinessUserService businessUserService,
                                 IUserOTPRepository userOTPRepository,
                                 HeaderContext headerContext,
                                 IUserResetPasswordRepository userResetPasswordRepository,
                                 IIdentityBusinessUserService identityBusinessUserService)
    {
        _moduleTechUnitOfWork = moduleTechUnitOfWork;
        _mapper = mapper;
        _keycloakOptions = options.Value;
        _otpOptions = otpOptions.Value;
        _businessUserRepository = businessUserRepository;
        _userRepository = userRepository;
        _businessUserService = businessUserService;
        _userOTPRepository = userOTPRepository;
        _headerContext = headerContext;
        _userResetPasswordRepository = userResetPasswordRepository;
        _identityBusinessUserService = identityBusinessUserService;
    }

    public async Task<AuthenticationDTO> BusinessUserLoginAsync(BusinessUserLoginDTO loginDTO, CancellationToken cancellationToken)
    {
        await ValidateBusinessUserLoginAsync(loginDTO, cancellationToken);

        var result = await _identityBusinessUserService.LoginAsync(loginDTO, cancellationToken);

        return _mapper.Map<AuthenticationDTO>(result);
    }


    public async Task<AuthenticationDTO> BusinessUserRefreshTokenLoginAsync(string refreshToken, CancellationToken cancellationToken)
    {
        AuthenticationDTO authentication = await _identityBusinessUserService.RefreshTokenLoginAsync(refreshToken, cancellationToken);
        return _mapper.Map<AuthenticationDTO>(authentication);
    }

    public async Task<SignUpDTO> BusinessUserSignUpAsync(BusinessUserSignupCommandDTO model, CancellationToken cancellationToken)
    {
        var hasExistsEmail = await _userRepository.AnotherUserHasEmailAsync(null, UserTypeEnum.BusinessUser, model.Email, cancellationToken);
        if (hasExistsEmail)
            throw new ValidationException(UserStatusCodes.EmailConflict.Message, UserStatusCodes.EmailConflict.StatusCode);

        User userEntity = BusinessUserSignupCommandToUser(model);

        BusinessUser businessUserEntity = BusinessUserSignupCommandToBusinessUser(model, userEntity);


        #region Identity user insert
        CreateIdentityUserRequestDto createIdentityUserRequestDto = new CreateIdentityUserRequestDto
        {
            UserId = userEntity.Id,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password
        };


        var identityUser = await _identityBusinessUserService.CreateUserAsync(createIdentityUserRequestDto, cancellationToken);

        if (identityUser.IsSuccess == false)
            throw new ValidationException(UserStatusCodes.KeycloakError.Message, UserStatusCodes.KeycloakError.StatusCode);

        #endregion


        businessUserEntity.User.IdentityRefId = identityUser.IdentityRefId;




        #region user and businessUser insert

        await _businessUserRepository.AddAsync(businessUserEntity, cancellationToken);

        #endregion

        //#region UserConfirmRegisterType insert

        //foreach (var confirmRegister in model.ConfirmRegisters)
        //{
        //    await _userConfirmRegisterTypeRepository.AddAsync(
        //        new UserConfirmRegisterType()
        //        {
        //            UserId = businessUserEntity.User.Id,
        //            ConfirmRegisterTypeId = Convert.ToInt32(confirmRegister)
        //        });
        //}
        //#endregion
        var userOTP = await AddUserOtpAsync(businessUserEntity.UserId, businessUserEntity.Phone, businessUserEntity.User.Email, OtpTypeEnum.SignUp, UserTypeEnum.BusinessUser, VerificationTypeEnum.Email, cancellationToken);

        try
        {
            await _moduleTechUnitOfWork.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            var isUserDeleted = await _identityBusinessUserService.DeleteUserAsync(identityUser.IdentityRefId, cancellationToken);

            if (!isUserDeleted)
            {
                Logger.ForContext("KeycloakUserId", identityUser.IdentityRefId).Error("There is an error when trying to create businessUser user. Keycloak user can not be rollbacked...");
            }
         
            throw;
        }


        var authentication = await BusinessUserLoginAsync(new BusinessUserLoginDTO() { Email = model.Email, Password = model.Password }, cancellationToken);

        return new SignUpDTO() { TransactionId = userOTP.Id, OTPCode = userOTP.OtpCode, authenticationDTO = authentication };
    }


    private BusinessUser BusinessUserSignupCommandToBusinessUser(BusinessUserSignupCommandDTO model, User userEntity)
    {
        return new BusinessUser
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

    private User BusinessUserSignupCommandToUser(BusinessUserSignupCommandDTO model)
    {
        return new User
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Suffix = model.Suffix
        };
    }

    public async Task<bool> BusinessUserVerifyOtpAsync(VerifyOtpDTO model, CancellationToken cancellationToken)
    {
        var userOtpDetail = await _userOTPRepository.GetVerifyByIdAsync(model.TransactionId, UserTypeEnum.BusinessUser, OtpTypeEnum.SignUp, cancellationToken);
       
        var businessUserEntity = await _businessUserRepository.GetById(userOtpDetail.UserId, cancellationToken);

        if (businessUserEntity == null)
            throw new ApiException(BusinessUserConstants.RecordNotFound);

        if (userOtpDetail == null)
            throw new ApiException("Expire Time Süresi Aşıldı. Uygun kayıt bulunamadı.");

        if (userOtpDetail.OtpCode != model.OtpCode)
            throw new ApiException("OtpCode Hatalı!");

        userOtpDetail.IsVerified = true;
        userOtpDetail.VerificationDate = DateTime.UtcNow;
        _userOTPRepository.Update(userOtpDetail);

        businessUserEntity.SiteStatus = SiteStatusEnum.Open;
        _businessUserRepository.Update(businessUserEntity);

        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        return true;
    }

    public async Task<ResendOtpDTO> BusinessUserResendOtpAsync(CancellationToken cancellationToken)
    {
        BusinessUser businessUserEntity = await ValidateBusinessUserResendOtpAsync(cancellationToken);
        var userOTP = await AddUserOtpAsync(businessUserEntity.UserId, businessUserEntity.Phone, businessUserEntity.User.Email, OtpTypeEnum.SignUp, UserTypeEnum.BusinessUser, VerificationTypeEnum.Email, cancellationToken);

        businessUserEntity.SiteStatus = SiteStatusEnum.Open;
        _businessUserRepository.Update(businessUserEntity);

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
        var result = await _identityBusinessUserService.UpdateUserPasswordAsync(updateIdentityUserPasswordRequestDto, cancellationToken);

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

    private async Task ValidateBusinessUserLoginAsync(BusinessUserLoginDTO loginDTO, CancellationToken cancellationToken)
    {
        if (RegexEmail(loginDTO.Email))
        {
            BusinessUser businessUserEntity = await _businessUserRepository.GetByEmailAsync(loginDTO.Email, cancellationToken);

            if (businessUserEntity == null)
                throw new ValidationException(UserStatusCodes.UserNotFound.Message, UserStatusCodes.UserNotFound.StatusCode);
            else if (businessUserEntity.SiteStatus == SiteStatusEnum.Closed)
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

    private async Task<BusinessUser> ValidateBusinessUserResendOtpAsync(CancellationToken cancellationToken)
    {
        var businessUserEntity = await _businessUserRepository.GetById(_headerContext.IdentityRefId.Value, cancellationToken);

        if (businessUserEntity == null)
            throw new ApiException(BusinessUserConstants.RecordNotFound);

        var isVerified = await _userOTPRepository.IsVerifiedAsync(_headerContext.IdentityRefId.Value, UserTypeEnum.BusinessUser, OtpTypeEnum.SignUp, cancellationToken);

        if (isVerified)
            throw new ApiException(IsVerifiedUser);
        return businessUserEntity;
    }
}
