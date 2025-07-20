using ModuleTech.Application.Handlers.Auth.Queries;
using ModuleTech.Core.Base.Api;
using ModuleTech.Core.Base.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ModuleTech.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/auth")]
[ApiController]
public class AuthController : BaseApiController
{
    private readonly IRequestBus _requestBus;
    public AuthController(IRequestBus requestBus)
    {
        _requestBus = requestBus;
    }


    [HttpGet("user-info")]
    public async Task<IActionResult> Getuserinfo([FromHeader] string token)
        => Ok(await _requestBus.Send(new GetUserInfoQuery() { Token = token }));

}