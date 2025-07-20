using ModuleTech.Application.Handlers.B2bRoles.DTOs;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace ModuleTech.Application.Handlers.B2bRoles.Queries;

public class GetGroupPermissionsQuery : IQuery<ListResponse<B2BRolePermissionsDTO>>
{
    public Guid BusinessId { get; set; }
    public Guid ChildGroupId { get; set; }
}
public sealed class GetGroupPermissionsCommandQueryHandler : BaseQueryHandler<GetGroupPermissionsQuery, ListResponse<B2BRolePermissionsDTO>>
{
    //protected readonly IKeycloakRoleService _keycloakRoleService;
    private readonly IMapper _mapper;
    private readonly KeycloakOptions _keycloakOptions;

    public GetGroupPermissionsCommandQueryHandler(IMapper mapper,
        IOptions<KeycloakOptions> options)
    {
        _mapper = mapper;
        _keycloakOptions = options.Value;
    }

    public override async Task<ListResponse<B2BRolePermissionsDTO>> Handle(GetGroupPermissionsQuery request, CancellationToken cancellationToken  )
    {
        throw new NotImplementedException("this function is not implemented yet..");
        /*
        if(request.BusinessId==null)
            throw new ApiException(BusinessesConstants.BusinessIdCanNotBeNull);
        var business = await _businessService.GetByIdAsync(request.BusinessId, cancellationToken);

        var result = await _keycloakRoleService.GetChildGroupRolePermissions(business.IdentityGroupRefId.ToString(), request.ChildGroupId.ToString(), _keycloakOptions.ecommerce_b2b_realm, KeycloakConstants.ecommerceClient, cancellationToken);
        return new ListResponse<B2BRolePermissionsDTO>(_mapper.Map<ICollection<B2BRolePermissionsDTO>>(result));
        */
    }
}