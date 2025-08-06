using AutoMapper;
using Microsoft.Extensions.Options;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Core.ExceptionHandling.Exceptions;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.User.DTOs;
using ModuleTech.Application.Helpers;
using static ModuleTech.Application.Constants.Constants;
using ModuleTech.Application.Helpers.Options;

namespace ModuleTech.Application.Handlers.User.Commands.BusinessUser;

public class SetBusinessUserGroupPermissionsCommand : BusinessUserRolePermissionRequestDTO, ICommand<DataResponse<bool>>
{
}
public sealed class SetBusinessUserGroupPermissionsCommandHandler : BaseCommandHandler<SetBusinessUserGroupPermissionsCommand, DataResponse<bool>>
{
    protected readonly IBusinessUserService _businessUserService;
    //protected readonly IKeycloakGroupService _keycloakGroupService;
    private readonly KeycloakOptions _keycloakOptions;
    private readonly IMapper _mapper;

    public SetBusinessUserGroupPermissionsCommandHandler(IBusinessUserService businessUserService,
        IMapper mapper,
        IOptions<KeycloakOptions> options)
    {
        _businessUserService = businessUserService;
        _keycloakOptions = options.Value;
        _mapper = mapper;
    }


    public override async Task<DataResponse<bool>> Handle(SetBusinessUserGroupPermissionsCommand request, CancellationToken cancellationToken)
    {
        //TODO: Servise taşınacak.
        var userDetail = await _businessUserService.GetByIdAsync(request.userId, cancellationToken);
        if (userDetail == null)
            throw new ResourceNotFoundException(BusinessUserConstants.RecordNotFound);


        if (userDetail.UserGroupRoleId.ToString()!= request.roleId.ToString())
        {
            if (string.IsNullOrEmpty(request.roleId))
            {
                userDetail.UserGroupRoleId = null;
            }
            else
            {
                userDetail.UserGroupRoleId = new Guid(request.roleId);
            }
            var businessUserCommandDTO = _mapper.Map<UpdateBusinessUserCommandDTO>(userDetail);
            await _businessUserService.UpdateAsync(businessUserCommandDTO, cancellationToken);
        }
      
      //  request.userId = userDetail.IdentityRefId;
      //  var result = await _keycloakGroupService.AssignBusinessUserGroupsAndPermissionsAsync(request, _keycloakOptions.ecommerce_businessUser_realm, cancellationToken);
        throw new NotImplementedException("set businessUser user group permission function is not implemented yet..");

    }
}
