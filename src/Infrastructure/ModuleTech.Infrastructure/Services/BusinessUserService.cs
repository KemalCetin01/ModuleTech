using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Application.Core.Persistence.Repositories.UserOtp;
using ModuleTech.Application.Core.Persistence.UoW;
using ModuleTech.Application.DTOs.Identity.Request;
using ModuleTech.Application.DTOs.Identity.Response;
using ModuleTech.Application.Handlers.User.DTOs;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Core.ExceptionHandling.Exceptions;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;
using ModuleTech.Domain.Enums;
using AutoMapper;
using Microsoft.Extensions.Options;
using Serilog;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.Identity.Infrastructure.Services;

public class BusinessUserService : IBusinessUserService
{
    private readonly IModuleTechUnitOfWork _moduleTechUnitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IBusinessUserRepository _businessUserRepository;
    private readonly IUserEmployeeRepository _userEmployeeRepository;
    private readonly IMapper _mapper;
    private readonly IIdentityBusinessUserService _identityBusinessUserService;

    private readonly KeycloakOptions _keycloakOptions;
    private static readonly Serilog.ILogger Logger = Log.ForContext<BusinessUserService>();

    public BusinessUserService(IModuleTechUnitOfWork moduleTechUnitOfWork,
                          IUserRepository userRepository,
                          IBusinessUserRepository businessUserRepository,
                          IMapper mapper,
                          IOptions<KeycloakOptions> options,
                          IUserEmployeeRepository userEmployeeRepository,
                          IIdentityBusinessUserService identityBusinessUserService)
    {
        _moduleTechUnitOfWork = moduleTechUnitOfWork;
        _userRepository = userRepository;
        _businessUserRepository = businessUserRepository;
        _mapper = mapper;

        _keycloakOptions = options.Value;
        _userEmployeeRepository = userEmployeeRepository;
        _identityBusinessUserService = identityBusinessUserService;
    }

    public async Task<BusinessUserGetByIdDTO> CreateAsync(CreateBusinessUserCommandDTO model, CancellationToken cancellationToken)
    {
        await ValidateCreateBusinessUser(model, cancellationToken);
        User userEntity = CreateBusinessUserCommandToUser(model);

        CreateIdentityUserRequestDto requestDto = new CreateIdentityUserRequestDto(){
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password,
            UserId = userEntity.Id,
            UserName = model.Email?.Split('@')[0],
        };

        var identityUserResponse = await _identityBusinessUserService.CreateUserAsync(requestDto, cancellationToken);

        if (identityUserResponse.IsSuccess == false)
            throw new ValidationException(UserStatusCodes.KeycloakError.Message, UserStatusCodes.KeycloakError.StatusCode);

        userEntity.IdentityRefId = identityUserResponse.IdentityRefId;

      

        BusinessUser businessUserEntity = CreateBusinessUserCommandToBusinessUser(model, userEntity);
        try
        {
            await _businessUserRepository.AddAsync(businessUserEntity, cancellationToken);

            var result = await _moduleTechUnitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<BusinessUserGetByIdDTO>(businessUserEntity);
        }
        catch (Exception)
        {
            var isDeleted = await _identityBusinessUserService.DeleteUserAsync(identityUserResponse.IdentityRefId,cancellationToken);
            if (!isDeleted)
            {
                Logger.ForContext("KeycloakUserId", identityUserResponse.IdentityRefId).Error("There is an error when trying to create businessUser user. Keycloak user can not be rollbacked...");
            }
            throw;
        }
    }

    public async Task<int> GetActiveUserInRoleCountAsync(Guid userGroupRoleId, CancellationToken cancellationToken)
    => await _businessUserRepository.GetActiveUserInRoleCountAsync(userGroupRoleId, cancellationToken);

    public async Task<BusinessUserGetByIdDTO> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _businessUserRepository.GetById(Id, cancellationToken);
        return _mapper.Map<BusinessUserGetByIdDTO>(result);
    }

    public async Task<PagedResponse<BusinessUserListDTO>> GetUsersAsync(SearchQueryModel<BusinessUserQueryServiceFilter> searchQuery, CancellationToken cancellationToken)
    {
        var users = await _businessUserRepository.GetAll(searchQuery, cancellationToken);
        return _mapper.Map<PagedResponse<BusinessUserListDTO>>(users);
    }

    public async Task DeleteAsync(Guid Id, CancellationToken cancellationToken)
    {
        var existUser = await _businessUserRepository.GetById(Id, cancellationToken);
        if (existUser == null)
            throw new ValidationException(UserStatusCodes.UserNotFound.Message, UserStatusCodes.UserNotFound.StatusCode);

        existUser.IsDeleted = true;
        existUser.User.IsDeleted = true;
        _businessUserRepository.Update(existUser);

        bool isDeleted = await _identityBusinessUserService.DeleteUserAsync(existUser.User.IdentityRefId, cancellationToken);

        if (!isDeleted)
            throw new ValidationException(UserStatusCodes.KeycloakError.Message, UserStatusCodes.KeycloakError.StatusCode);

        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

    }

    public async Task<BusinessUserGetByIdDTO> UpdateAsync(UpdateBusinessUserCommandDTO model, CancellationToken cancellationToken)
    {
        Logger.ForContext("UserId", model.Id).Information("Existing BusinessUser User will be updated");

        BusinessUser existBusinessUser = await ValidateUpdateBusinessUserAsync(model, cancellationToken);


        var updateUserRequest = new UpdateIdentityUserRequestDto
        {
            IdentityRefId = existBusinessUser.User.IdentityRefId,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        UpdateIdentityUserResponseDto response = await _identityBusinessUserService.UpdateUserAsync(updateUserRequest, cancellationToken);

        var rollbackUser = new UpdateIdentityUserRequestDto
        {
            IdentityRefId = existBusinessUser.User.IdentityRefId,
            Email = existBusinessUser.User.Email,
            FirstName = existBusinessUser.User.FirstName,
            LastName = existBusinessUser.User.LastName
        };


//TODO 
        /*var businessUser = await _businessUserRepository.GetByUserIdAsync(existBusinessUser.User.Id, cancellationToken);

        businessUser.BusinessId = model.BusinessId.Value;
        //_businessUserRepository.Update(businessUser);
*/
        UpdateExistingBusinessUserWithModel(model, existBusinessUser);
        try
        {
            var result = await _moduleTechUnitOfWork.CommitAsync(cancellationToken);
            Logger.ForContext("UserId", model.Id).Information("Existing B2C User is updated");
            return _mapper.Map<BusinessUserGetByIdDTO>(existBusinessUser);
        }
        catch (Exception)
        {

            await _identityBusinessUserService.UpdateUserAsync(rollbackUser, cancellationToken);

            throw;
        }

    }

    private void UpdateExistingBusinessUserWithModel(UpdateBusinessUserCommandDTO model, BusinessUser existBusinessUser)
    {
        existBusinessUser.User.FirstName = model.FirstName;
        existBusinessUser.User.LastName = model.LastName;
        existBusinessUser.User.Email = model.Email;
        existBusinessUser.CountryId = model.CountryId;
        existBusinessUser.CityId = model.CityId;
        existBusinessUser.UserEmployeeId = model.RepresentativeId;
        existBusinessUser.PhoneCountryCode = model.PhoneCountryCode;
        existBusinessUser.Phone = model.Phone;
        existBusinessUser.UserStatus = model.UserStatus;
        existBusinessUser.SiteStatus = model.SiteStatus;
        existBusinessUser.UserGroupRoleId = model.UserGroupRoleId;

        _businessUserRepository.Update(existBusinessUser);
    }

    private async Task<BusinessUser> ValidateUpdateBusinessUserAsync(UpdateBusinessUserCommandDTO model, CancellationToken cancellationToken)
    {
        var currentUser = await _businessUserRepository.GetById(model.Id, cancellationToken);
        if (currentUser == null)
            throw new ValidationException(UserStatusCodes.UserNotFound.Message, UserStatusCodes.UserNotFound.StatusCode);

        var hasExistsEmail = await _userRepository.AnotherUserHasEmailAsync(currentUser.UserId, UserTypeEnum.BusinessUser, model.Email, cancellationToken);
        if (hasExistsEmail)
            throw new ValidationException(UserStatusCodes.EmailConflict.Message, UserStatusCodes.EmailConflict.StatusCode);

        if (model.RepresentativeId != null)
        {
            var hasExistsRepresentative = await _userEmployeeRepository.GetById(model.RepresentativeId, cancellationToken);
            if (hasExistsRepresentative == null)
                throw new ResourceNotFoundException(EmployeeRoleConstants.EmployeeRoleNotFound);
        }

        return currentUser;
    }

    private async Task ValidateCreateBusinessUser(CreateBusinessUserCommandDTO model, CancellationToken cancellationToken)
    {
        var hasExistsEmail = await _userRepository.AnotherUserHasEmailAsync(null, UserTypeEnum.BusinessUser, model.Email, cancellationToken);
        if (hasExistsEmail)
            throw new ValidationException(UserStatusCodes.EmailConflict.Message, UserStatusCodes.EmailConflict.StatusCode);
    }

    private BusinessUser CreateBusinessUserCommandToBusinessUser(CreateBusinessUserCommandDTO model, User userEntity)
    {
        return new BusinessUser
        {
            User = userEntity,
            UserId = userEntity.Id,
            CityId = model.CityId,
            CountryId = model.CountryId,
            TownId = model.TownId,
            Phone = model.Phone,
            PhoneCountryCode = model.PhoneCountryCode,
            SiteStatus = model.SiteStatus
        };
    }

    private User CreateBusinessUserCommandToUser(CreateBusinessUserCommandDTO model)
    {
        return new User
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Suffix = null, 
        };
    }

    public async Task<bool> ResetPasswordAsync(ResetPasswordCommandDTO model, CancellationToken cancellationToken)
    {
        var userEntity = await _userRepository.GetById(model.UserId, cancellationToken);

        if (userEntity == null)
            throw new ValidationException(UserStatusCodes.UserNotFound.Message, UserStatusCodes.UserNotFound.StatusCode);

        UpdateIdentityUserPasswordRequestDto requestDto = new UpdateIdentityUserPasswordRequestDto
        {
            IdentityRefId = userEntity.IdentityRefId,
            Password = model.Password
        };

        return await _identityBusinessUserService.UpdateUserPasswordAsync(requestDto, cancellationToken);

    }

}
