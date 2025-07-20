using ModuleTech.Application.Handlers.User.Commands.B2BUser;
using ModuleTech.Application.Handlers.User.Queries.B2B;
using ModuleTech.Core.Base.Api;
using ModuleTech.Core.Base.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ModuleTech.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/b2b-users")]
[ApiController]
public class B2BUserController : BaseApiController
{
    private readonly IRequestBus _requestBus;
    public B2BUserController(IRequestBus requestBus)
    {
        _requestBus = requestBus;
    }
    /// <summary>
    /// returns details
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetB2BUser(Guid id) => StatusCode(StatusCodes.Status200OK, await _requestBus.Send(new GetB2BUserByIdQuery() { Id = id }));
    /// <summary>
    /// creates b2buser
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateB2BUser([FromBody] CreateB2BUserCommand createB2BUserCommand) => StatusCode(StatusCodes.Status200OK, await _requestBus.Send(createB2BUserCommand));
    /// <summary>
    /// update b2buser
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> UpdateB2BUser([FromBody] UpdateB2BUserCommand updateB2BUserCommand) => StatusCode(StatusCodes.Status200OK, await _requestBus.Send(updateB2BUserCommand));


    /// <summary>
    /// delete b2buser by id
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteB2BUser(Guid id)
    {
        await _requestBus.Send(new DeleteB2BUserCommand() { Id = id });
        return NoContent();

    }
    /// <summary>
    /// returns all b2busers
    /// </summary>
    [HttpPost("search")]
    public async Task<IActionResult> GetAllB2BUsers([FromBody] GetB2BUsersQuery getB2BUsers) => StatusCode(StatusCodes.Status200OK, await _requestBus.Send(getB2BUsers)); // Ok(await mediator.Send(getB2BUsers));

    /// <remarks>
    /// Firstly, it fetches assigned role and all the client permissions and if there is a permission for the selected role, the selected and disabled disabled columd is set to true.
    /// </remarks>
    /// <summary>
    /// fetches assigned role and permissions of b2b-users
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id:guid}/permissions")]
    public async Task<IActionResult> GetB2BUserPermissions(Guid id) => Ok(await _requestBus.Send(new GetB2BUserPermissionsQuery() { Id = id }));


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
    ///     PUT /b2b-users
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
    /// assigns group and permission to b2b-users
    /// </summary>
    /// <param name="id"></param>
    [HttpPut("{id:guid}/permissions")]
    public async Task<IActionResult> SetPermissions([FromBody] SetB2BUserGroupPermissionsCommand setB2BUserGroupPermissionsCommand, Guid id)
    {
        setB2BUserGroupPermissionsCommand.userId = id;
        return Ok((await _requestBus.Send(setB2BUserGroupPermissionsCommand)).Data);

    }

    /// <remarks>
    ///b2b reset password
    /// 
    /// 
    /// 
    /// </remarks>
    /// <summary>
    /// b2b reset password
    /// </summary>
    [HttpPut("{id:guid}/reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetB2BUserPasswordCommand resetB2BUserPasswordCommand, Guid id)
    {
        resetB2BUserPasswordCommand.UserId = id;
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(resetB2BUserPasswordCommand));
    }

}
