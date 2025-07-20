namespace ModuleTech.Core.Base.Models;

public class SearchListModel<T>
{
    public SearchListModel()
    {
    }

    public SearchListModel(ICollection<T> data, int? pageNumber, int? pageSize, int totalCount)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public ICollection<T> Data { get; protected set; } = null!;
    public int? PageNumber { get; init; }
    public int? PageSize { get; init; }
    public int TotalCount { get; init; }
}