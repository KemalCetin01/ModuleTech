using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.DTOs.Identity.Response;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.ExceptionHandling.Exceptions;
using Microsoft.Extensions.Options;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.Application.Handlers.User.Queries.B2B;

public class GetB2BUserPermissionsQuery : IQuery<GetB2BUserRoleAndPermissionsResponseDto>
{
    public Guid Id { get; set; }
}
public sealed class GetB2BUserPermissionsQueryueryHandler : BaseQueryHandler<GetB2BUserPermissionsQuery, GetB2BUserRoleAndPermissionsResponseDto>
{
    protected readonly IIdentityB2BService _identityB2BService;
    protected readonly IUserB2BService _userB2BService;
    private readonly KeycloakOptions _keycloakOptions;

    public GetB2BUserPermissionsQueryueryHandler(IUserB2BService userB2BService, IIdentityB2BService identityB2BService,
        IOptions<KeycloakOptions> options)
    {
        _userB2BService = userB2BService;
        _identityB2BService = identityB2BService;
        _keycloakOptions = options.Value;
    }

    public override Task<GetB2BUserRoleAndPermissionsResponseDto> Handle(GetB2BUserPermissionsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}