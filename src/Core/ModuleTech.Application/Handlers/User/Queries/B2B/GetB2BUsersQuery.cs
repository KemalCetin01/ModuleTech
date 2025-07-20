using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.User.DTOs;
using ModuleTech.Application.Handlers.User.Queries.Filters;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Handlers.Search;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Domain.EntityFilters;
using AutoMapper;

namespace ModuleTech.Application.Handlers.User.Queries.B2B;

public sealed class GetB2BUsersQuery : SearchQuery<UserQueryFilter, PagedResponse<B2BUserListDTO>>
{

}

public sealed class GetB2BUsersQueryHandler : BaseQueryHandler<GetB2BUsersQuery, PagedResponse<B2BUserListDTO>>
{
    protected readonly IUserB2BService _userService;
    protected readonly IMapper _mapper;

    public GetB2BUsersQueryHandler(IUserB2BService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public override async Task<PagedResponse<B2BUserListDTO>> Handle(GetB2BUsersQuery request, CancellationToken cancellationToken  )
    {

        var searchResult = _mapper.Map<SearchQueryModel<UserB2BQueryServiceFilter>>(request);

        return await _userService.GetUsersAsync(searchResult, cancellationToken);

    }
}