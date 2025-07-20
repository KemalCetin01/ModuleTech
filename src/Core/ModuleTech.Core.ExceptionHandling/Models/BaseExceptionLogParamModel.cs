using ModuleTech.Core.ExceptionHandling.Wrapper;

namespace ModuleTech.Core.ExceptionHandling.Models;

public sealed class BaseExceptionLogParamModel
{
    public IEnumerable<ExceptionErrorResponse>? Errors { get; set; }
    public string? StatusCode { get; set; }
}