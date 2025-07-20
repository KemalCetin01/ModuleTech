using ModuleTech.Application.Handlers.B2bRoles.DTOs;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Handlers.Search;
using ModuleTech.Core.Base.Wrapper;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace ModuleTech.Application.Handlers.B2bRoles.Queries;

public class SearchBusinessRolesQuery : SearchQuery<SearchBusinessRolesQueryFilter, PagedResponse<B2bGroupRoleDTO>>
{
}
public sealed class SearchBusinessRolesQueryHandler : BaseQueryHandler<SearchBusinessRolesQuery, PagedResponse<B2bGroupRoleDTO>>
{
    private readonly IMapper _mapper;
    //private readonly IKeycloakGroupService _keycloakGroupService;
    private readonly KeycloakOptions _keycloakOptions;
    public SearchBusinessRolesQueryHandler(IMapper mapper, 
        IOptions<KeycloakOptions> options)
    {
        _mapper = mapper;
        _keycloakOptions = options.Value;
    }

    public override async Task<PagedResponse<B2bGroupRoleDTO>> Handle(SearchBusinessRolesQuery request, CancellationToken cancellationToken  )
    {
        throw new NotImplementedException("this function is not implemented yet..");
        /*
        if (request.Filter.BusinessId == null)
            throw new ApiException(BusinessesConstants.BusinessIdCanNotBeNull);

        var business = await _businessService.GetByIdAsync(request.Filter.BusinessId, cancellationToken);

        var searchResult = _mapper.Map<SearchQueryModel<SearchBusinessRolesQueryFilterModel>>(request);

        var result = await _keycloakGroupService.SearchAsync(searchResult, business.IdentityGroupRefId.Value, _keycloakOptions.ecommerce_b2b_realm, cancellationToken);

        return result;
        */
    }
}
