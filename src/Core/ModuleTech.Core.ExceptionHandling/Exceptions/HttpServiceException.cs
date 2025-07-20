using ModuleTech.Core.ExceptionHandling.Exceptions.Common;
using ModuleTech.Core.ExceptionHandling.Wrapper;

namespace ModuleTech.Core.ExceptionHandling.Exceptions;

public class HttpServiceException : BaseException
{
    public HttpServiceException(string message) : base(message,HttpStatusCode.BadRequest)
    {
    }
    
    public HttpServiceException(string message, string? statusCode = null) : base(message, statusCode, HttpStatusCode.BadRequest)
    {
    }

    public HttpServiceException(string message, string? statusCode = null,
        HttpStatusCode resultCode = HttpStatusCode.BadRequest) : base(message, statusCode, resultCode)
    {
    }

    public HttpServiceException(string message, string? statusCode = null,
        IEnumerable<ExceptionErrorResponse>? errors = null, HttpStatusCode resultCode = HttpStatusCode.BadRequest) :
        base(message, statusCode, errors, resultCode)
    {
    }
}