using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.EmployeeRoles.DTOs;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Handlers.Search;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Domain.EntityFilters;
using AutoMapper;

namespace ModuleTech.Application.Handlers.EmployeeRoles.Queries;
public class SearchEmployeeRolesQuery : SearchQuery<SearchEmployeeRolesQueryFilter, PagedResponse<EmployeeRoleDTO>>
{
}
public sealed class SearchEmployeeRolesQueryHandler : BaseQueryHandler<SearchEmployeeRolesQuery, PagedResponse<EmployeeRoleDTO>>
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRoleService _employeeRoleService;
    public SearchEmployeeRolesQueryHandler(IEmployeeRoleService employeeRoleService, IMapper mapper)
    {
        _employeeRoleService = employeeRoleService;
        _mapper = mapper;
    }
    public override async Task<PagedResponse<EmployeeRoleDTO>> Handle(SearchEmployeeRolesQuery request, CancellationToken cancellationToken  )
    {
        var searchResult = _mapper.Map<SearchQueryModel<SearchUserEmployeeRolesQueryFilterModel>>(request);

        var result = await _employeeRoleService.SearchAsync(searchResult, cancellationToken);

        return result;
    }
}
