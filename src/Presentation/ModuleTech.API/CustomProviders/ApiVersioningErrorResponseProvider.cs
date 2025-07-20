using ModuleTech.Core.ExceptionHandling.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Net;

namespace ModuleTech.API.CustomProviders;
public class ApiVersioningErrorResponseProvider : DefaultErrorResponseProvider
{
    public override IActionResult CreateResponse(ErrorResponseContext context)
    {
        var errorResponse = new ExceptionResponse
        {
            Message = context.Message,
            StatusCode = context.ErrorCode
        };
        var response = new ObjectResult(errorResponse)
        {
            StatusCode = (int)HttpStatusCode.BadRequest
        };

        return response;
    }
}
