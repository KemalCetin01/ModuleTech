using ModuleTech.Core.ExceptionHandling.Exceptions.Common;
using ModuleTech.Core.ExceptionHandling.Wrapper;

namespace ModuleTech.Core.ExceptionHandling.Exceptions;

public class ForbiddenAccessException : BaseException
{
    public ForbiddenAccessException(string message) : base(message,HttpStatusCode.Forbidden)
    {
    }
    
    public ForbiddenAccessException(string message, string? statusCode = null) : base(message, statusCode, HttpStatusCode.Forbidden)
    {
    }

    public ForbiddenAccessException(string message, string? statusCode = null,
        HttpStatusCode resultCode = HttpStatusCode.Forbidden) : base(message, statusCode, resultCode)
    {
    }

    public ForbiddenAccessException(string message, string? statusCode = null,
        IEnumerable<ExceptionErrorResponse>? errors = null, HttpStatusCode resultCode = HttpStatusCode.Forbidden) :
        base(message, statusCode, errors, resultCode)
    {
    }
}