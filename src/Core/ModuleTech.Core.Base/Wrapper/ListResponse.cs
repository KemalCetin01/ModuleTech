using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Core.Base.Wrapper;

public class ListResponse<T> : IResponse
{
    public ICollection<T> Data { get; protected set; }

    public ListResponse(ICollection<T> data) => Data = data;
}