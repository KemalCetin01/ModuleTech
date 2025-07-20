using ModuleTech.Core.Base.Models;

namespace ModuleTech.Domain.EntityFilters;

public class SearchProductFilterModel:IFilterModel
{
    public string? Name { get; set; }
}
