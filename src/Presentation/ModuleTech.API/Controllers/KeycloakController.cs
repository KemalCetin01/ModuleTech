using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.EmployeeRoles.Commands;
using ModuleTech.Application.Handlers.Keycloak.Commands;
using ModuleTech.Application.Handlers.UserEmployees.Commands;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.Api;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Infrastructure.Clients.Keycloak.Interfaces;
using ModuleTech.Infrastructure.Clients.Keycloak.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/keycloak")]
[ApiController]

public class KeycloakController : BaseApiController
{
    private readonly IKeycloakUserService _keycloakUserService;
    private readonly IKeycloakRoleService _keycloakRoleService;
    private readonly IUserEmployeeService _employeeService;
    private readonly IEmployeeRoleService _employeeRoleService;
    private readonly KeycloakOptions _keycloakOptions;
    private readonly IRequestBus _requestBus;

    public KeycloakController(IKeycloakUserService keycloakUserService, IKeycloakRoleService keycloakRoleService, IRequestBus requestBus, IOptions<KeycloakOptions> options, IUserEmployeeService employeeService, IEmployeeRoleService employeeRoleService)
    {
        _keycloakUserService = keycloakUserService;
        _keycloakRoleService = keycloakRoleService;
        _requestBus = requestBus;
        _keycloakOptions = options.Value;
        _employeeService = employeeService;
        _employeeRoleService = employeeRoleService;
    }


    [HttpGet("user-info")]
    public async Task<KeycloakUserInfoModel> Get([FromHeader] string token)
    {
        return _keycloakUserService.GetUserDetails(token);
    }





    [HttpPost("create-super-user-and-roles")]
    public async Task CreateSuperUserAndRoles([FromBody] CreateSuperUserAndRolesCommand keycloakMigrateClientRolesCommand, CancellationToken cancellationToken)
    {

        CreateEmployeeRoleCommand createEmployeeRoleCommand = new CreateEmployeeRoleCommand()
        {
            Name = "AdminTest",
            Description = "AdminTest",
            DiscountRate = 100
        };
        var superRole = await _employeeRoleService.AddAsync(createEmployeeRoleCommand, cancellationToken);

        await _keycloakRoleService.AssignAllClientPermsToRealmRole(_keycloakOptions.moduleTech_realm, KeycloakConstants.clientPrefix, createEmployeeRoleCommand.Name, cancellationToken);

        CreateUserEmployeeCommand createUserEmployeeCommand = new CreateUserEmployeeCommand()
        {
            Email = "info1@moduleTechTest.com",
            FirstName = "Super",
            LastName = "Admin",
            Password = "12345",
            PhoneNumber = "5555555555",
            UserName = "superadminTest",
            RoleId = superRole.Id.Value
        };
        var superUser = await _employeeService.CreateAsync(createUserEmployeeCommand, cancellationToken);
        await _keycloakRoleService.AssignAllClientPermsToRealmRole(_keycloakOptions.moduleTech_realm, KeycloakConstants.clientPrefix, createUserEmployeeCommand.RoleId.ToString(), cancellationToken);


    }
    [HttpPost("transfer-client-roles")]
    public async Task transferClientRoles([FromBody] KeycloakMigrateClientRolesCommand keycloakMigrateClientRolesCommand, CancellationToken cancellationToken)
    {
        await _keycloakRoleService.MigrationClientRoles(keycloakMigrateClientRolesCommand, cancellationToken);
    }

    [HttpGet("realm-roles")]
    public async Task<List<RoleRepresentation>> GetRealmRoles(string realm)
    {
        return await _keycloakRoleService.GetRealmRolesAsync(realm, default);
    }



}
