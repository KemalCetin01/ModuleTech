using ModuleTech.Core.ExceptionHandling.Exceptions.Common;
using ModuleTech.Core.ExceptionHandling.Wrapper;

namespace ModuleTech.Core.ExceptionHandling.Exceptions;

public class ResourceNotFoundException : BaseException
{
    public ResourceNotFoundException(string message) : base(message,HttpStatusCode.NotFound)
    {
    }
    
    public ResourceNotFoundException(string message, string? statusCode = null) : base(message, statusCode, HttpStatusCode.NotFound)
    {
    }


    public ResourceNotFoundException(string message, string? statusCode = null,
        HttpStatusCode resultCode = HttpStatusCode.NotFound) : base(message, statusCode, resultCode)
    {
    }

    public ResourceNotFoundException(string message, string? statusCode = null,
        IEnumerable<ExceptionErrorResponse>? errors = null, HttpStatusCode resultCode = HttpStatusCode.NotFound) :
        base(message, statusCode, errors, resultCode)
    {
    }
}