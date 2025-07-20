using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Core.Base.Handlers.Search;

public class SearchQuery<TFilter, TResponse> : IQuery<TResponse> where TFilter : IFilter where TResponse : IResponse
{
    public Pagination? Pagination { get; set; }

    public Sort? Sort { get; set; }

    public string? GlobalSearch { get; set; }

    public TFilter? Filter { get; set; }
}

public class SearchModel<TFilter> where TFilter : IFilter
{
    public Pagination? Pagination { get; set; }

    public Sort? Sort { get; set; }

    public string? GlobalSearch { get; set; }

    public TFilter? Filter { get; set; }
}

public interface IFilter
{
}