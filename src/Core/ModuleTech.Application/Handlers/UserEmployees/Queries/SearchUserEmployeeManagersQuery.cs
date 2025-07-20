using AutoMapper;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Core.Base.Dtos.Response;

namespace ModuleTech.Application.Handlers.UserEmployees.Queries;
public sealed class SearchUserEmployeeManagersQuery : IQuery<ListResponse<LabelValueResponse>>
{
    public string Search { get; set; }
}

public sealed class GetEmployeesQueryHandler : BaseQueryHandler<SearchUserEmployeeManagersQuery, ListResponse<LabelValueResponse>>
{
    protected readonly IUserEmployeeService _employeeService;
    protected readonly IMapper _mapper;

    public GetEmployeesQueryHandler(IUserEmployeeService employeeService, IMapper mapper)
    {
        _employeeService = employeeService;
        _mapper = mapper;
    }

    public override async Task<ListResponse<LabelValueResponse>> Handle(SearchUserEmployeeManagersQuery request, CancellationToken cancellationToken  )
    {

        var result = await _employeeService.GetEmployees(request.Search, cancellationToken);
        return new ListResponse<LabelValueResponse>(_mapper.Map<ICollection<LabelValueResponse>>(result));
    }

}