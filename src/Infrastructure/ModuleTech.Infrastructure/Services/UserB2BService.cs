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

public class UserB2BService : IUserB2BService
{
    private readonly IModuleTechUnitOfWork _moduleTechUnitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IUserB2BRepository _userB2BRepository;
    private readonly IUserEmployeeRepository _userEmployeeRepository;
    private readonly IMapper _mapper;
    private readonly IIdentityB2BService _identityB2BService;

    private readonly KeycloakOptions _keycloakOptions;
    private static readonly Serilog.ILogger Logger = Log.ForContext<UserB2BService>();

    public UserB2BService(IModuleTechUnitOfWork moduleTechUnitOfWork,
                          IUserRepository userRepository,
                          IUserB2BRepository userB2BRepository,
                          IMapper mapper,
                          IOptions<KeycloakOptions> options,
                          IUserEmployeeRepository userEmployeeRepository,
                          IIdentityB2BService identityB2BService)
    {
        _moduleTechUnitOfWork = moduleTechUnitOfWork;
        _userRepository = userRepository;
        _userB2BRepository = userB2BRepository;
        _mapper = mapper;

        _keycloakOptions = options.Value;
        _userEmployeeRepository = userEmployeeRepository;
        _identityB2BService = identityB2BService;
    }

    public async Task<B2BUserGetByIdDTO> CreateAsync(CreateB2BUserCommandDTO model, CancellationToken cancellationToken)
    {
        await ValidateCreateB2BUser(model, cancellationToken);
        User userEntity = CreateB2BUserCommandToUser(model);

        CreateIdentityUserRequestDto requestDto = new CreateIdentityUserRequestDto(){
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password,
            UserId = userEntity.Id,
            UserName = model.Email?.Split('@')[0],
        };

        var identityUserResponse = await _identityB2BService.CreateUserAsync(requestDto, cancellationToken);

        if (identityUserResponse.IsSuccess == false)
            throw new ValidationException(UserStatusCodes.KeycloakError.Message, UserStatusCodes.KeycloakError.StatusCode);

        userEntity.IdentityRefId = identityUserResponse.IdentityRefId;

      

        UserB2B userB2BEntity = CreateB2BUserCommandToB2BUser(model, userEntity);
        try
        {
            await _userB2BRepository.AddAsync(userB2BEntity, cancellationToken);

            var result = await _moduleTechUnitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<B2BUserGetByIdDTO>(userB2BEntity);
        }
        catch (Exception)
        {
            var isDeleted = await _identityB2BService.DeleteUserAsync(identityUserResponse.IdentityRefId,cancellationToken);
            if (!isDeleted)
            {
                Logger.ForContext("KeycloakUserId", identityUserResponse.IdentityRefId).Error("There is an error when trying to create b2b user. Keycloak user can not be rollbacked...");
            }
            throw;
        }
    }

    public async Task<int> GetActiveUserInRoleCountAsync(Guid userGroupRoleId, CancellationToken cancellationToken)
    => await _userB2BRepository.GetActiveUserInRoleCountAsync(userGroupRoleId, cancellationToken);

    public async Task<B2BUserGetByIdDTO> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _userB2BRepository.GetById(Id, cancellationToken);
        return _mapper.Map<B2BUserGetByIdDTO>(result);
    }

    public async Task<PagedResponse<B2BUserListDTO>> GetUsersAsync(SearchQueryModel<UserB2BQueryServiceFilter> searchQuery, CancellationToken cancellationToken)
    {
        var users = await _userB2BRepository.GetAll(searchQuery, cancellationToken);
        return _mapper.Map<PagedResponse<B2BUserListDTO>>(users);
    }

    public async Task DeleteAsync(Guid Id, CancellationToken cancellationToken)
    {
        var existUser = await _userB2BRepository.GetById(Id, cancellationToken);
        if (existUser == null)
            throw new ValidationException(UserStatusCodes.UserNotFound.Message, UserStatusCodes.UserNotFound.StatusCode);

        existUser.IsDeleted = true;
        existUser.User.IsDeleted = true;
        _userB2BRepository.Update(existUser);

        bool isDeleted = await _identityB2BService.DeleteUserAsync(existUser.User.IdentityRefId, cancellationToken);

        if (!isDeleted)
            throw new ValidationException(UserStatusCodes.KeycloakError.Message, UserStatusCodes.KeycloakError.StatusCode);

        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

    }

    public async Task<B2BUserGetByIdDTO> UpdateAsync(UpdateB2BUserCommandDTO model, CancellationToken cancellationToken)
    {
        Logger.ForContext("UserId", model.Id).Information("Existing B2B User will be updated");

        UserB2B existUserB2B = await ValidateUpdateB2BUserAsync(model, cancellationToken);


        var updateUserRequest = new UpdateIdentityUserRequestDto
        {
            IdentityRefId = existUserB2B.User.IdentityRefId,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        UpdateIdentityUserResponseDto response = await _identityB2BService.UpdateUserAsync(updateUserRequest, cancellationToken);

        var rollbackUser = new UpdateIdentityUserRequestDto
        {
            IdentityRefId = existUserB2B.User.IdentityRefId,
            Email = existUserB2B.User.Email,
            FirstName = existUserB2B.User.FirstName,
            LastName = existUserB2B.User.LastName
        };


//TODO 
        /*var businessUser = await _businessUserRepository.GetByUserIdAsync(existUserB2B.User.Id, cancellationToken);

        businessUser.BusinessId = model.BusinessId.Value;
        //_businessUserRepository.Update(businessUser);
*/
        UpdateExistingB2BUserWithModel(model, existUserB2B);
        try
        {
            var result = await _moduleTechUnitOfWork.CommitAsync(cancellationToken);
            Logger.ForContext("UserId", model.Id).Information("Existing B2C User is updated");
            return _mapper.Map<B2BUserGetByIdDTO>(existUserB2B);
        }
        catch (Exception)
        {

            await _identityB2BService.UpdateUserAsync(rollbackUser, cancellationToken);

            throw;
        }

    }

    private void UpdateExistingB2BUserWithModel(UpdateB2BUserCommandDTO model, UserB2B existUserB2B)
    {
        existUserB2B.User.FirstName = model.FirstName;
        existUserB2B.User.LastName = model.LastName;
        existUserB2B.User.Email = model.Email;
        existUserB2B.CountryId = model.CountryId;
        existUserB2B.CityId = model.CityId;
        existUserB2B.UserEmployeeId = model.RepresentativeId;
        existUserB2B.PhoneCountryCode = model.PhoneCountryCode;
        existUserB2B.Phone = model.Phone;
        existUserB2B.UserStatus = model.UserStatus;
        existUserB2B.SiteStatus = model.SiteStatus;
        existUserB2B.UserGroupRoleId = model.UserGroupRoleId;

        _userB2BRepository.Update(existUserB2B);
    }

    private async Task<UserB2B> ValidateUpdateB2BUserAsync(UpdateB2BUserCommandDTO model, CancellationToken cancellationToken)
    {
        var currentUser = await _userB2BRepository.GetById(model.Id, cancellationToken);
        if (currentUser == null)
            throw new ValidationException(UserStatusCodes.UserNotFound.Message, UserStatusCodes.UserNotFound.StatusCode);

        var hasExistsEmail = await _userRepository.AnotherUserHasEmailAsync(currentUser.UserId, UserTypeEnum.B2B, model.Email, cancellationToken);
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

    private async Task ValidateCreateB2BUser(CreateB2BUserCommandDTO model, CancellationToken cancellationToken)
    {
        var hasExistsEmail = await _userRepository.AnotherUserHasEmailAsync(null, UserTypeEnum.B2B, model.Email, cancellationToken);
        if (hasExistsEmail)
            throw new ValidationException(UserStatusCodes.EmailConflict.Message, UserStatusCodes.EmailConflict.StatusCode);
    }

    private UserB2B CreateB2BUserCommandToB2BUser(CreateB2BUserCommandDTO model, User userEntity)
    {
        return new UserB2B
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

    private User CreateB2BUserCommandToUser(CreateB2BUserCommandDTO model)
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

        return await _identityB2BService.UpdateUserPasswordAsync(requestDto, cancellationToken);

    }

}
