using ModuleTech.Core.Base.Models;

namespace ModuleTech.Domain.EntityFilters;
public class SearchUserEmployeeRolesQueryFilterModel : IFilterModel
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int FirstDiscountRate { get; set; }
    public int LastDiscountRate { get; set; }

}
