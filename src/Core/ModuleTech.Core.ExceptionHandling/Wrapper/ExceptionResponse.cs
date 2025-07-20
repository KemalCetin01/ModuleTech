namespace ModuleTech.Core.ExceptionHandling.Wrapper;

public class ExceptionResponse
{
    public ExceptionResponse(string? message = null, IEnumerable<ExceptionErrorResponse>? errors = null,
        string? statusCode = null)
    {
        Message = message;
        StatusCode = statusCode;
        Errors = errors;
    }

    public string? StatusCode { get; set; }
    public string? Message { get; set; }
    public IEnumerable<ExceptionErrorResponse>? Errors { get; set; }
    public ExceptionDetailedResponse? Trace { get; set; }
}

public class ExceptionDetailedResponse
{
    public string? Message { get; set; }
    public string? StackTrace { get; set; }

}