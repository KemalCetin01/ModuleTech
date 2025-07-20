using ModuleTech.Core.ExceptionHandling.Wrapper;

namespace ModuleTech.Core.ExceptionHandling.Exceptions.Common;

public abstract class BaseException : Exception
{
    protected BaseException(string message, HttpStatusCode resultCode = HttpStatusCode.BadRequest) : base(message)
    {
        ResultCode = resultCode;
    }


    protected BaseException(string message, string? statusCode = null,
        HttpStatusCode resultCode = HttpStatusCode.BadRequest) : base(message)
    {
        StatusCode = statusCode;
        ResultCode = resultCode;
    }

    protected BaseException(string message, string? statusCode = null,
        IEnumerable<ExceptionErrorResponse>? errors = null,
        HttpStatusCode resultCode = HttpStatusCode.BadRequest) : base(message)
    {
        StatusCode = statusCode;
        ResultCode = resultCode;
        Errors = errors;
    }

    public IEnumerable<ExceptionErrorResponse>? Errors { get; set; }
    public HttpStatusCode ResultCode { get; set; }
    public string? StatusCode { get; set; }
}