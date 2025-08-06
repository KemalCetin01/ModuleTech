using ModuleTech.Application.Handlers.Auth.Commands.BusinessUser.Login;
using ModuleTech.Application.Handlers.Auth.Commands.BusinessUser.Register;
using ModuleTech.Application.Handlers.Auth.Commands.BusinessUser.ResetPassword;
using ModuleTech.Application.Handlers.Auth.Commands.B2CUser.Register;
using ModuleTech.Application.Handlers.Auth.Queries;
using ModuleTech.Core.Base.Api;
using ModuleTech.Core.Base.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ModuleTech.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/auth")]
[ApiController]
public class BusinessUserAuthController : BaseApiController
{
    private readonly IRequestBus _requestBus;
    public BusinessUserAuthController(IRequestBus requestBus)
    {
        _requestBus = requestBus;
    }

    /// <remarks>
    /// just email 
    /// 
    /// 
    ///     POST /business-user/login
    ///     {
    ///        "Email": "aliveli2@gmail.com",
    ///        "Password":"123456"
    ///     }
    /// 
    /// </remarks>
    /// <summary>
    /// business-user login
    /// </summary>
    [HttpPost("business-user/login")]
    public async Task<IActionResult> BusinessUserLogin([FromBody] BusinessUserLoginCommand loginCommand)
    {
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(loginCommand));
    }

    /// <remarks>
    /// refresh token 
    /// 
    /// 
    /// 
    /// </remarks>
    /// <summary>
    /// BusinessUser refresh token
    /// </summary>
    [HttpPost("business-user/refresh-token")]
    public async Task<IActionResult> BusinessUserRefreshToken([FromQuery] BusinessUserRefreshTokenCommand loginCommand)
    {
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(loginCommand));
    }


    /// <remarks>
    /// business-user information validations
    /// 
    /// 
    /// 
    /// </remarks>
    /// <summary>
    /// business-user information validations
    /// </summary>
    [HttpPost("business-user/validate-signup-info")]
    public async Task<IActionResult> BusinessUserValidateSignUpInfo([FromBody] BusinessUserValidateSignUpInfoQuery b2BValidateSignUpInfoQuery)
    {
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(b2BValidateSignUpInfoQuery));
    }

    /// <remarks>
    /// Billing Address validations
    /// 
    /// 
    /// 
    /// </remarks>
    /// <summary>
    /// Billing Address validations
    /// </summary>
    [HttpPost("business-user/validate-signup-adress")]
    public async Task<IActionResult> BusinessUserValidateSignUpAddress([FromBody] BusinessUserValidateSignUpAddressQuery b2BValidateSignUpAddressQuery)
    {
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(b2BValidateSignUpAddressQuery));
    }

    /// <remarks>
    /// signup - send code
    /// 
    /// 
    /// 
    /// </remarks>
    /// <summary>
    /// signup - send code
    /// </summary>
    [HttpPost("business-user/signup")]
    public async Task<IActionResult> BusinessUserSignUp([FromForm] BusinessUserSignUpCommand b2BSignUpCommand)
    {
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(b2BSignUpCommand));
    }

    /// <remarks>
    /// business-user verify otp
    /// 
    /// 
    /// 
    /// </remarks>
    /// <summary>
    /// business-user verify otp
    /// </summary>
    [HttpPost("business-user/verify-otp")]
    public async Task<IActionResult> BusinessUserVerifyOtp([FromBody] BusinessUserVerifyOtpCommand b2BVerifyOtpCommand)
    {
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(b2BVerifyOtpCommand));
    }

    /// <remarks>
    /// business-user resend otp
    /// 
    /// 
    /// 
    /// </remarks>
    /// <summary>
    /// business-user resend otp
    /// </summary>
    [HttpPost("business-user/resend-otp")]
    public async Task<IActionResult> BusinessUserResendOtp([FromBody] BusinessUserResendOtpCommand b2BResendOtpCommand)
    {
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(b2BResendOtpCommand));
    }

    #region reset password
    /// <remarks>
    ///business-user reset password
    /// 
    /// 
    /// 
    /// </remarks>
    /// <summary>
    /// business-user reset password
    /// </summary>
    [HttpPost("business-user/reset-password")]
    public async Task<IActionResult> BusinessUserResetPassword([FromBody] BusinessUserResetPasswordCommand resetPasswordCommand)
    {
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(resetPasswordCommand));
    }

    /// <remarks>
    /// business-user reset password verify otp
    /// 
    /// 
    /// 
    /// </remarks>
    /// <summary>
    /// business-user reset password verify otp
    /// </summary>
    [HttpPost("business-user/reset-verify-otp")]
    public async Task<IActionResult> BusinessUserResetPasswordVerifyOtp([FromBody] BusinessUserResetVerifyOtpCommand b2BResetVerifyOtpCommand)
    {
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(b2BResetVerifyOtpCommand));
    }

    [HttpPut("business-user/change-password")]
    public async Task<IActionResult> BusinessUserChangePassword([FromBody] BusinessUserChangePasswordCommand b2BChangePasswordCommand)
    {
        return StatusCode(StatusCodes.Status200OK, await _requestBus.Send(b2BChangePasswordCommand));
    }

    #endregion
}