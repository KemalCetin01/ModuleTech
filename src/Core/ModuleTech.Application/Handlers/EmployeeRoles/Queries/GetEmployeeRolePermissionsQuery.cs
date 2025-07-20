using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.EmployeeRoles.DTOs;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace ModuleTech.Application.Handlers.EmployeeRoles.Queries;
public class GetEmployeeRolePermissionsQuery : IQuery<ListResponse<EmployeeRolePermissionsDTO>>
{
    public Guid Id { get; set; }
}
public sealed class GetEmployeeRolePermissionsQueryHandler : BaseQueryHandler<GetEmployeeRolePermissionsQuery, ListResponse<EmployeeRolePermissionsDTO>>
{
    protected readonly IEmployeeRoleService _employeeRoleService;
    private readonly IMapper _mapper;
    private readonly KeycloakOptions _keycloakOptions;

    public GetEmployeeRolePermissionsQueryHandler(IEmployeeRoleService employeeRoleService,
        IMapper mapper,
        IOptions<KeycloakOptions> options)
    {
        _employeeRoleService = employeeRoleService;
        _mapper = mapper;
        _keycloakOptions = options.Value;
    }

    public override Task<ListResponse<EmployeeRolePermissionsDTO>> Handle(GetEmployeeRolePermissionsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}