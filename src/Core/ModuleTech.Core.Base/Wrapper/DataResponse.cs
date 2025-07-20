using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Core.Base.Wrapper;

[Obsolete("This Class is obsole use void Command instead of this", false)]
public class DataResponse<T> : IResponse
{
    public T? Data { get; set; }
}