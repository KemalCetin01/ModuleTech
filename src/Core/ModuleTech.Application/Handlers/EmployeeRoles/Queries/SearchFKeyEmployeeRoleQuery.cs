using AutoMapper;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Core.Base.Dtos.Response;

namespace ModuleTech.Application.Handlers.EmployeeRoles.Queries;
public class SearchFKeyEmployeeRoleQuery : IQuery<ListResponse<LabelValueResponse>>
{
    public string Search { get; set; }

}
public sealed class SearchFKeyEmployeeRoleQueryHandler : BaseQueryHandler<SearchFKeyEmployeeRoleQuery, ListResponse<LabelValueResponse>>
{
    protected readonly IEmployeeRoleService _employeeRoleService;
    protected readonly IMapper _mapper;

    public SearchFKeyEmployeeRoleQueryHandler(IEmployeeRoleService employeeRoleService, IMapper mapper)
    {
        _employeeRoleService = employeeRoleService;
        _mapper = mapper;
    }

    public override async Task<ListResponse<LabelValueResponse>> Handle(SearchFKeyEmployeeRoleQuery request, CancellationToken cancellationToken  )
    {

        var result = await _employeeRoleService.SearchFKeyAsync(request.Search, cancellationToken);
        return new ListResponse<LabelValueResponse>(_mapper.Map<ICollection<LabelValueResponse>>(result));
    }

}