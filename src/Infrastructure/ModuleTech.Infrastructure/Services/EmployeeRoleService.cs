using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Application.Core.Persistence.UoW;
using ModuleTech.Application.DTOs.Identity.Request;
using ModuleTech.Application.Exceptions;
using ModuleTech.Application.Handlers.EmployeeRoles.Commands;
using ModuleTech.Application.Handlers.EmployeeRoles.DTOs;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Core.ExceptionHandling.Exceptions;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;
using ModuleTech.Infrastructure.Clients.Keycloak.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.Infrastructure.Services;
public class EmployeeRoleService : IEmployeeRoleService
{
    private readonly IModuleTechUnitOfWork _moduleTechUnitOfWork;
    private readonly IEmployeeRoleRepository _employeeRoleRepository;
    private readonly IIdentityEmployeeService _identityEmployeeService;
    private readonly IMapper _mapper;
    private readonly KeycloakOptions _keycloakOptions;

    public EmployeeRoleService(IModuleTechUnitOfWork moduleTechUnitOfWork,
        IEmployeeRoleRepository employeeRoleRepository,
        IMapper mapper,
        IOptions<KeycloakOptions> options,
        IIdentityEmployeeService identityEmployeeService)
    {
        _mapper = mapper;
        _moduleTechUnitOfWork = moduleTechUnitOfWork;
        _employeeRoleRepository = employeeRoleRepository;
        _keycloakOptions = options.Value;
        _identityEmployeeService = identityEmployeeService;
    }
    public async Task<EmployeeRoleDTO> GetByIdAsync(Guid Id, CancellationToken cancellationToken  )
    {
        var employeeRole = await GetById(Id, cancellationToken);
        return _mapper.Map<EmployeeRoleDTO>(employeeRole);
    }
    public async Task<EmployeeRoleDTO> AddAsync(CreateEmployeeRoleCommand createEmployeeCommand, CancellationToken cancellationToken  )
    {

        await RoleConflictControl(createEmployeeCommand.Name, null, cancellationToken);
        CreateIdentityRoleRequestDto createIdentityRoleRequestDto = new CreateIdentityRoleRequestDto
        {
            Name = createEmployeeCommand.Name,
            Description = createEmployeeCommand.Description
        };
        
        var rolesUpdated = await _identityEmployeeService.CreateRoleAsync(createIdentityRoleRequestDto, cancellationToken);
        
        if (!rolesUpdated)
            throw new ApiException(EmployeeRoleConstants.EmployeeRoleAddedError);

        var employeeRole = new EmployeeRole()
        {
            Name = createEmployeeCommand.Name,
            DiscountRate = createEmployeeCommand.DiscountRate,
            Description = createEmployeeCommand.Description

        };

        await _employeeRoleRepository.AddAsync(employeeRole);
        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<EmployeeRoleDTO>(employeeRole);
    }

    public async Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken  )
    {
        var employeeRole = await GetById(Id, cancellationToken);

        bool isDeleted = await _identityEmployeeService.DeleteRoleAsync(employeeRole.Name, cancellationToken);

        if (!isDeleted)
            throw new ApiException(EmployeeRoleConstants.EmployeeRoleDeletedError);

        employeeRole.IsDeleted = true;
        var transaction = await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        return transaction == transaction
            ? true
            : throw new ApiException(EmployeeRoleConstants.EmployeeRoleDeletedError);
    }

    public async Task<ICollection<EmployeeRoleKeyValueDTO>> SearchFKeyAsync(string search, CancellationToken cancellationToken  )
    {
        return await _employeeRoleRepository.SearchFKeyAsync(search, cancellationToken);

    }

    public async Task<EmployeeRoleDTO> UpdateAsync(UpdateEmployeeRoleCommand updateEmployeeCommand, CancellationToken cancellationToken  )
    {
        var employeeRole = await GetById(updateEmployeeCommand.Id, cancellationToken);
        employeeRole.Description = updateEmployeeCommand.Description;
        employeeRole.DiscountRate = updateEmployeeCommand.DiscountRate;

        await RoleConflictControl(updateEmployeeCommand.Description, updateEmployeeCommand.Id, cancellationToken);
        _employeeRoleRepository.Update(employeeRole);

        var keycloackRoleModel = new KeycloakRoleModel() { name = employeeRole.Name, description = updateEmployeeCommand.Description };
        UpdateIdentityRoleRequestDto updateIdentityRoleRequestDto = new UpdateIdentityRoleRequestDto
        {
            Name = employeeRole.Name,
            Description = employeeRole.Description
        };

        bool rolesUpdated = await _identityEmployeeService.UpdateRoleAsync(updateIdentityRoleRequestDto, cancellationToken);

        if (!rolesUpdated)
            throw new ApiException(EmployeeRoleConstants.EmployeeRoleUpdatedError);

        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<EmployeeRoleDTO>(employeeRole);
    }

    private async Task<bool> RoleConflictControl(string name, Guid? id, CancellationToken cancellationToken  )
    {
        var isRoleExists = await _employeeRoleRepository.HasRoleAsync(name, id, cancellationToken);
        if (isRoleExists)
            throw new ConflictException(EmployeeRoleConstants.EmployeeRoleConflict);
        return true;
    }

    private async Task<EmployeeRole> GetById(Guid Id, CancellationToken cancellationToken  )
    {
        var employeeRole = await _employeeRoleRepository.GetById(Id, cancellationToken);
        if (employeeRole == null)
            throw new ResourceNotFoundException(EmployeeRoleConstants.EmployeeRoleNotFound);

        return employeeRole;
    }

    public async Task<PagedResponse<EmployeeRoleDTO>> SearchAsync(SearchQueryModel<SearchUserEmployeeRolesQueryFilterModel> searchQuery, CancellationToken cancellationToken  )
    {
        var result = await _employeeRoleRepository.SearchAsync(searchQuery, cancellationToken);

        var mapResult = _mapper.Map<PagedResponse<EmployeeRoleDTO>>(result);

        return mapResult;
    }
}

