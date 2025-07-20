using ModuleTech.Core.ExceptionHandling.Exceptions.Common;
using ModuleTech.Core.ExceptionHandling.Wrapper;

namespace ModuleTech.Core.ExceptionHandling.Exceptions;

public class ValidationException : BaseException
{
    public ValidationException(string message) : base(message, HttpStatusCode.BadRequest)
    {
    }

    public ValidationException(string message, string? statusCode = null) : base(message, statusCode,
        HttpStatusCode.BadRequest)
    {
    }

    public ValidationException(string message, string? statusCode = null,
        HttpStatusCode resultCode = HttpStatusCode.BadRequest) : base(message, statusCode, resultCode)
    {
    }

    public ValidationException(IEnumerable<ExceptionErrorResponse>? errors = null,
        string message = Constants.Constants.DefaultValidationErrorMessage, string? statusCode = null,
        HttpStatusCode resultCode = HttpStatusCode.BadRequest) : base(message, statusCode, errors, resultCode)
    {
    }
}