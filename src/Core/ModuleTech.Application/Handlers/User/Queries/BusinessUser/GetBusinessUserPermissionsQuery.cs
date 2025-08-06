using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.DTOs.Identity.Response;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.ExceptionHandling.Exceptions;
using Microsoft.Extensions.Options;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.Application.Handlers.User.Queries.BusinessUser;

public class GetBusinessUserPermissionsQuery : IQuery<GetBusinessUserRoleAndPermissionsResponseDto>
{
    public Guid Id { get; set; }
}
public sealed class GetBusinessUserPermissionsQueryueryHandler : BaseQueryHandler<GetBusinessUserPermissionsQuery, GetBusinessUserRoleAndPermissionsResponseDto>
{
    protected readonly IIdentityBusinessUserService _identityBusinessUserService;
    protected readonly IBusinessUserService _businessUserService;
    private readonly KeycloakOptions _keycloakOptions;

    public GetBusinessUserPermissionsQueryueryHandler(IBusinessUserService businessUserService, IIdentityBusinessUserService identityBusinessUserService,
        IOptions<KeycloakOptions> options)
    {
        _businessUserService = businessUserService;
        _identityBusinessUserService = identityBusinessUserService;
        _keycloakOptions = options.Value;
    }

    public override Task<GetBusinessUserRoleAndPermissionsResponseDto> Handle(GetBusinessUserPermissionsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}