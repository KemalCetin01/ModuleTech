using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Core.Base.Wrapper;

public sealed class ErrorResponse : IResponse
{
    public string? Code { get; set; }
    public string? Message { get; set; }
    public IDictionary<string, string[]>? Errors { get; set; }
}