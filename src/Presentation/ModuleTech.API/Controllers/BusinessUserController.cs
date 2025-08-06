using ModuleTech.Application.Handlers.User.Commands.BusinessUser;
using ModuleTech.Application.Handlers.User.Queries.BusinessUser;
using ModuleTech.Core.Base.Api;
using ModuleTech.Core.Base.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ModuleTech.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/business-users")]
[ApiController]
public class BusinessUserController : BaseApiController
{
    private readonly IRequestBus _requestBus;
    public BusinessUserController(IRequestBus requestBus)
    {
        _requestBus = requestBus;
    }
    /// <summary>
    /// returns details
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBusinessUser(Guid id) => StatusCode(StatusCodes.Status200OK, await _requestBus.Send(new GetBusinessUserByIdQuery() { Id = id }));
    /// <summary>
    /// creates business-user
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateBusinessUser([FromBody] CreateBusinessUserCommand createBusinessUserCommand) => StatusCode(StatusCodes.Status200OK, await _requestBus.Send(createBusinessUserCommand));
    /// <summary>
    /// update business-user
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> UpdateBusinessUser([FromBody] UpdateBusinessUserCommand updateBusinessUserCommand) => StatusCode(StatusCodes.Status200OK, await _requestBus.Send(updateBusinessUserCommand));


    /// <summary>
    /// delete business-user by id
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBusinessUser(Guid id)
    {
        await _requestBus.Send(new DeleteBusinessUserCommand() { Id = id });
        return NoContent();

    }
    /// <summary>
    /// returns all business-users
    /// </summary>
    [HttpPost("search")]
    public async Task<IActionResult> GetAllBusinessUsers([FromBody] GetBusinessUsersQuery getBusinessUsers) => StatusCode(StatusCodes.Status200OK, await _requestBus.Send(getBusinessUsers)); // Ok(await mediator.Send(getBusinessUsers));

    /// <remarks>
    /// Firstly, it fetches assigned role and all the client permissions and if there is a permission for the selected role, the selected and disabled disabled columd is set to true.
    /// </remarks>
    /// <summary>
    /// fetches assigned role and permissions of business-users
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id:guid}/permissions")]
    public async Task<IActionResult> GetBusinessUserPermissions(Guid id) => Ok(await _requestBus.Send(new GetBusinessUserPermissionsQuery() { Id = id }));


    /// <remarks>
    /// Firstly, all 'groups' assigned to the user are fetched.
    /// 
    /// A user can only have one assigned 'group' at a time.
    /// 
    /// If the 'group' sent with the request has not been previously assigned to the user, it is assigned to them, and any previously assigned 'groups' are removed.
    /// 
    /// Secondly, all permissions on the client and all permissions assigned or to be assigned to the user's group are listed.
    /// 
    /// Assigned permissions to the group are listed as 'selected' and 'disabled'.
    /// 
    /// When additional permission assignment is desired, the user can also be assigned or revoked permissions separately.
    /// 
    /// The input of all the following fields is mandatory.
    /// 
    ///     PUT /business-users
    ///       {
    ///         "roleId": "9682391d-acd0-4ff3-b62a-964c220c80ff",
    ///         "roleName": "arge",
    ///         "userId": "01000000-32ec-1221-6479-08db526e6a22",
    ///         "permissions": [
    ///			  {	
    ///				"id": "a23acec8-c035-4f56-a9fa-5dd213c21a3f",
    ///				"name": "aa_test"
    ///			  }
    ///			]
    ///       }
    /// </remarks>
    /// <summary>
    /// assigns group and permission to business-users
    /// </summary>
    /// <param name="id"></param>
    [HttpPut("{id:guid}/permissions")]
    public async Task<IActionResult> SetPermissions([FromBody] SetBusinessUserGroupPermissionsCommand setBusinessUserGroupPermissionsCommand, Guid id)
    {
        setBusinessUserGroupPermissionsCommand.userId = id;
        return Ok((await _requestBus.Send(setBusinessUserGroupPermissionsCommand)).Data);

    }

    /// <remarks>
    ///business-user reset password
    /// 
    /// 
    /// 
    /// </remarks>
    /// <summary>
    /// business-user reset password
    /// </summary>
    [HttpPut("{id:guid}/reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetBusinessUserPasswordCommand resetBusinessUserPasswordCommand, Guid id)
    {
        resetBusinessUserPasswordCommand.UserId = id;
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(resetBusinessUserPasswordCommand));
    }

}
