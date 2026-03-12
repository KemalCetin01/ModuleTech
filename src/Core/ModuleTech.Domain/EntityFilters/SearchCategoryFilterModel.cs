using ModuleTech.Core.Base.Models;

namespace ModuleTech.Domain.EntityFilters;

public class SearchCategoryFilterModel : IFilterModel
{
    public string? Name { get; set; }
}
