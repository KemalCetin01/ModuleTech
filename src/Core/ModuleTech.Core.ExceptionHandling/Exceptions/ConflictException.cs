using ModuleTech.Core.ExceptionHandling.Exceptions.Common;
using ModuleTech.Core.ExceptionHandling.Wrapper;

namespace ModuleTech.Application.Exceptions;
public class ConflictException : BaseException
{
    public ConflictException(string message) : base(message, HttpStatusCode.Conflict)
    {
    }

    public ConflictException(string message, string statusCode = null,
        HttpStatusCode resultCode = HttpStatusCode.Conflict) : base(message, statusCode, resultCode)
    {
    }

    public ConflictException(string message, string? statusCode = null,
        IEnumerable<ExceptionErrorResponse>? errors = null, HttpStatusCode resultCode = HttpStatusCode.Conflict)
        : base(message, statusCode, errors, resultCode)
    {
    }
}