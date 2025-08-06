using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.User.DTOs;
using ModuleTech.Application.Handlers.User.Queries.Filters;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Handlers.Search;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Domain.EntityFilters;
using AutoMapper;

namespace ModuleTech.Application.Handlers.User.Queries.BusinessUser;

public sealed class GetBusinessUsersQuery : SearchQuery<UserQueryFilter, PagedResponse<BusinessUserListDTO>>
{

}

public sealed class GetBusinessUsersQueryHandler : BaseQueryHandler<GetBusinessUsersQuery, PagedResponse<BusinessUserListDTO>>
{
    protected readonly IBusinessUserService _userService;
    protected readonly IMapper _mapper;

    public GetBusinessUsersQueryHandler(IBusinessUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public override async Task<PagedResponse<BusinessUserListDTO>> Handle(GetBusinessUsersQuery request, CancellationToken cancellationToken  )
    {

        var searchResult = _mapper.Map<SearchQueryModel<BusinessUserQueryServiceFilter>>(request);

        return await _userService.GetUsersAsync(searchResult, cancellationToken);

    }
}