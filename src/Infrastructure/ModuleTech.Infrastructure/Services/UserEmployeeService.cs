﻿using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Application.Core.Persistence.Repositories.UserOtp;
using ModuleTech.Application.Core.Persistence.UoW;
using ModuleTech.Application.DTOs.Identity.Request;
using ModuleTech.Application.Exceptions;
using ModuleTech.Application.Handlers.UserEmployees.Commands;
using ModuleTech.Application.Handlers.UserEmployees.DTOs;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Application.Models.FKeyModel;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Core.ExceptionHandling.Exceptions;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;
using ModuleTech.Domain.Enums;
using AutoMapper;
using Microsoft.Extensions.Options;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.Infrastructure.Services;
public class UserEmployeeService : IUserEmployeeService
{
    private readonly IModuleTechUnitOfWork _moduleTechUnitOfWork;
    private readonly IUserEmployeeRepository _employeeRepository;
    private readonly IEmployeeRoleRepository _employeeRoleRepository;
    private readonly IMapper _mapper;
    private readonly IIdentityEmployeeService _identityEmployeeService;
    private readonly IUserRepository _userRepository;
    private readonly KeycloakOptions _keycloakOptions;

    public UserEmployeeService(IMapper mapper,
        IModuleTechUnitOfWork moduleTechUnitOfWork,
        IUserEmployeeRepository employeeRepository,
        IEmployeeRoleRepository employeeRoleRepository,
        IUserRepository userRepository,
        IOptions<KeycloakOptions> options,
        IIdentityEmployeeService identityEmployeeService)
    {
        _mapper = mapper;
        _moduleTechUnitOfWork = moduleTechUnitOfWork;
        _employeeRepository = employeeRepository;
        _employeeRoleRepository = employeeRoleRepository;
        _userRepository = userRepository;
        _keycloakOptions = options.Value;
        _identityEmployeeService = identityEmployeeService;
    }

    public async Task<ICollection<LabelValueModel>> GetEmployees(string search, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetEmployees(search, cancellationToken);
    }

    public async Task<PagedResponse<UserEmployeeDTO>> SearchAsync(SearchQueryModel<SearchUserEmployeesQueryFilterModel> searchQuery, CancellationToken cancellationToken)
    {
        var result = await _employeeRepository.SearchAsync(searchQuery, cancellationToken);

        var mapResult = _mapper.Map<PagedResponse<UserEmployeeDTO>>(result);

        return mapResult;
    }

    public async Task<UserEmployeeDTO> CreateAsync(CreateUserEmployeeCommandDTO createEmployeeCommandDTO, CancellationToken cancellationToken)
    {
        await EmployeeConflictControl(null, createEmployeeCommandDTO.Email, cancellationToken);
        var roleDetail = await _employeeRoleRepository.GetById(createEmployeeCommandDTO.RoleId);

        if (roleDetail == null)
            throw new ResourceNotFoundException(EmployeeRoleConstants.EmployeeRoleNotFound);

        var user = new User()
        {
            FirstName = createEmployeeCommandDTO.FirstName,
            LastName = createEmployeeCommandDTO.LastName,
            Email = createEmployeeCommandDTO.Email,
            IdentityRefId = Guid.NewGuid()
        };

        var userEmployee = new UserEmployee()
        {
            PhoneNumber = createEmployeeCommandDTO.PhoneNumber,
            EmployeeRoleId = createEmployeeCommandDTO.RoleId,
            UserId = user.Id
        };
        CreateIdentityUserRequestDto createIdentityUserRequestDto = new CreateIdentityUserRequestDto
        {
            UserId = userEmployee.UserId,
            Email = createEmployeeCommandDTO.Email,
            FirstName = createEmployeeCommandDTO.FirstName,
            LastName = createEmployeeCommandDTO.LastName,
            Password = createEmployeeCommandDTO.Password,
            UserName = createEmployeeCommandDTO.UserName,
        };

        var identityUserResponse = await _identityEmployeeService.CreateUserAsync(createIdentityUserRequestDto, cancellationToken);

        #region Keycloak mapping-role assign
        UpdateIdentityUserRolesRequestDto updateIdentityUserRolesRequestDto = new UpdateIdentityUserRolesRequestDto
        {
            IdentityRefId = identityUserResponse.IdentityRefId,
            CurrentRoles = new List<string>() { roleDetail.Name }
        };
        
        bool identityRoleUpdated = await _identityEmployeeService.UpdateUserRolesAsync(updateIdentityUserRolesRequestDto, cancellationToken);

        #endregion

        if (identityUserResponse.IsSuccess && identityRoleUpdated)
        {
            user.IdentityRefId = identityUserResponse.IdentityRefId;
            await _employeeRepository.AddAsync(userEmployee, cancellationToken);
            await _userRepository.AddAsync(user, cancellationToken);
            await _moduleTechUnitOfWork.CommitAsync(cancellationToken);


            return _mapper.Map<UserEmployeeDTO>(userEmployee);
        }
        throw new ValidationException(UserStatusCodes.KeycloakError.Message, UserStatusCodes.KeycloakError.StatusCode);
    }

    public async Task<UserEmployeeDTO> UpdateAsync(UpdateUserEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken)
    {

        var existingUserEmployee = await GetById(updateEmployeeCommand.UserId, cancellationToken);
        var roleDetail = await _employeeRoleRepository.GetById(updateEmployeeCommand.RoleId);

        if (roleDetail == null)
            throw new ResourceNotFoundException(EmployeeRoleConstants.EmployeeRoleNotFound);

        existingUserEmployee.User.FirstName = updateEmployeeCommand.FirstName;
        existingUserEmployee.User.LastName = updateEmployeeCommand.LastName;
        existingUserEmployee.User.Email = updateEmployeeCommand.Email;
        existingUserEmployee.PhoneNumber = updateEmployeeCommand.PhoneNumber;
        existingUserEmployee.EmployeeRoleId = updateEmployeeCommand.RoleId;
        //UserEmployee.Password = updateEmployeeCommand.password;

        await EmployeeConflictControl(existingUserEmployee.UserId, existingUserEmployee.User.Email, cancellationToken);

        _employeeRepository.Update(existingUserEmployee);

        #region Keycloak Assign Role-Mappings
        UpdateIdentityUserRequestDto updateIdentityUserRequestDto = new UpdateIdentityUserRequestDto
        {
            IdentityRefId = existingUserEmployee.User.IdentityRefId,
            Email = updateEmployeeCommand.Email,
            FirstName = updateEmployeeCommand.FirstName,
            LastName = updateEmployeeCommand.LastName
        };
        var identityUserResponseDto = await _identityEmployeeService.UpdateUserAsync(updateIdentityUserRequestDto, cancellationToken);

        if (updateEmployeeCommand.RoleId != existingUserEmployee.EmployeeRole?.Id)
        {
            UpdateIdentityUserRolesRequestDto updateIdentityUserRolesRequestDto = new UpdateIdentityUserRolesRequestDto
            {
                IdentityRefId = existingUserEmployee.User.IdentityRefId,
                CurrentRoles = new List<string>() { roleDetail.Name }
            };

            if (existingUserEmployee.EmployeeRole != null) {
                updateIdentityUserRolesRequestDto.DeletedRoles = new List<string>(){ existingUserEmployee.EmployeeRole.Name};
            }
            bool userRolesUpdated = await _identityEmployeeService.UpdateUserRolesAsync(updateIdentityUserRolesRequestDto, cancellationToken);

        }
        #endregion

        if (identityUserResponseDto.IsSuccess)
            await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<UserEmployeeDTO>(existingUserEmployee);
    }

    public async Task DeleteAsync(Guid UserId, CancellationToken cancellationToken)
    {
        var existingUserEmployee = await GetById(UserId, cancellationToken);

        existingUserEmployee.User.IsDeleted = true;
        existingUserEmployee.IsDeleted = true;

        _employeeRepository.Update(existingUserEmployee);
        bool isDeleted = await _identityEmployeeService.DeleteUserAsync(existingUserEmployee.User.IdentityRefId, cancellationToken);

        if (!isDeleted)
            throw new ValidationException(UserStatusCodes.KeycloakError.Message, UserStatusCodes.KeycloakError.StatusCode);

        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

    }
    private async Task<UserEmployee> GetById(Guid UserId, CancellationToken cancellationToken)
    {
        var UserEmployee = await _employeeRepository.GetByIdAsync(UserId, cancellationToken);
        if (UserEmployee == null)
            throw new ResourceNotFoundException(EmployeeConstants.EmployeeNotFound);

        return UserEmployee;
    }

    private async Task<bool> EmployeeConflictControl(Guid? id, string email, CancellationToken cancellationToken)
    {
        var isEmployeeExists = await _userRepository.AnotherUserHasEmailAsync(id, UserTypeEnum.EMPLOYEE, email, cancellationToken);
        if (isEmployeeExists)
            throw new ConflictException("Eklemeye/güncellemeye çalıştığınız personel '" + email + "' bazında zaten mevcut");
        return true;
    }

    public async Task<UserEmployeeDTO> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var result = await _employeeRepository.GetByIdAsync(Id, cancellationToken);
        if (result != null)
        {
            var Details = new UserEmployeeDTO()
            {
                UserId = result.UserId,
                FullName = result.User.FirstName + result.User.LastName,
                FirstName = result.User.FirstName,
                LastName = result.User.LastName,
                Email = result.User.Email,
                PhoneNumber = result.PhoneNumber,
                LastDateEntry = result.LastDateEntry,
                DiscountRate = result.EmployeeRole.DiscountRate,
                Role = result.EmployeeRole.Name,
                RoleId = result.EmployeeRole.Id,
                IdentityRefId = result.User.IdentityRefId
                // Password = result.User.Password, //TODO

            };
            return Details;
        }
        throw new ResourceNotFoundException(EmployeeConstants.EmployeeNotFound);

    }

    public async Task<int> GetActiveUserInRoleCountAsync(Guid roleId, CancellationToken cancellationToken)
    => await _employeeRepository.GetActiveUserInRoleCountAsync(roleId, cancellationToken);
}
