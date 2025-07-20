using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.UserEmployees.DTOs;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Handlers.Search;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Domain.EntityFilters;
using AutoMapper;

namespace ModuleTech.Application.Handlers.UserEmployees.Queries;
public class SearchUserEmployeesQuery : SearchQuery<SearchUserEmployeesQueryFilter, PagedResponse<UserEmployeeDTO>>
{
}
public sealed class SearchEmployeesQueryHandler : BaseQueryHandler<SearchUserEmployeesQuery, PagedResponse<UserEmployeeDTO>>
{
    private readonly IMapper _mapper;
    private readonly IUserEmployeeService _employeeService;
    public SearchEmployeesQueryHandler(IUserEmployeeService employeeService, IMapper mapper)
    {
        _mapper = mapper;
        _employeeService = employeeService;
    }
    public override async Task<PagedResponse<UserEmployeeDTO>> Handle(SearchUserEmployeesQuery request, CancellationToken cancellationToken  )
    {
        var searchResult = _mapper.Map<SearchQueryModel<SearchUserEmployeesQueryFilterModel>>(request);

        var result = await _employeeService.SearchAsync(searchResult, cancellationToken);

        return result;
    }
}
