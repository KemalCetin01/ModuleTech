using ModuleTech.Core.ExceptionHandling.Exceptions.Common;
using ModuleTech.Core.ExceptionHandling.Wrapper;

namespace ModuleTech.Core.ExceptionHandling.Exceptions;

public class UnAuthorizedAccessException : BaseException
{
    public UnAuthorizedAccessException(string message) : base(message,HttpStatusCode.Unauthorized)
    {
    }

    public UnAuthorizedAccessException(string message, string? statusCode = null) : base(message, statusCode,
        HttpStatusCode.Unauthorized)
    {
    }


    public UnAuthorizedAccessException(string message, string? statusCode = null,
        HttpStatusCode resultCode = HttpStatusCode.Unauthorized) : base(message, statusCode, resultCode)
    {
    }

    public UnAuthorizedAccessException(string message, string? statusCode = null,
        IEnumerable<ExceptionErrorResponse>? errors = null, HttpStatusCode resultCode = HttpStatusCode.Unauthorized) :
        base(message, statusCode, errors, resultCode)
    {
    }
}