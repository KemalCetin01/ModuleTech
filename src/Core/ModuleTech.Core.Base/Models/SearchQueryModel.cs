namespace ModuleTech.Core.Base.Models;

public interface IFilterModel
{
}

public class SearchQueryModel<TFilter> where TFilter : IFilterModel
{
    public PaginationModel? Pagination { get; set; }
    public SortModel? Sort { get; set; }
    public string? GlobalSearch { get; set; }
    public TFilter? Filter { get; set; }
}

public class PaginationModel
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}

public class SortModel
{
    public string Field { get; set; } = null!;
    public string Direction { get; set; } = null!;
}