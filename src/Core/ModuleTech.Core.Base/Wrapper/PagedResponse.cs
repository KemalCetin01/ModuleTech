namespace ModuleTech.Core.Base.Wrapper;

public class PagedResponse<T> : ListResponse<T>
{
    public PagedResponse(ICollection<T> data, int pageNumber, int pageSize, int totalCount) : base(data)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = (uint) Math.Ceiling(totalCount / (double) PageSize);
    }
    
    public PagedResponse(ICollection<T> data, int? pageNumber, int? pageSize, int totalCount) : base(data)
    {
        PageNumber = pageNumber ?? 1;
        PageSize = pageSize ?? totalCount;
        TotalCount = totalCount;
        TotalPages = (uint) Math.Ceiling(totalCount / (double) PageSize);
    }

    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
    public uint TotalPages { get; init; }
}