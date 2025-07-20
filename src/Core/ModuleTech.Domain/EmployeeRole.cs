using ModuleTech.Core.Base.Attributes;
using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;
public class EmployeeRole : BaseSoftDeleteEntity
{
    [QuerySearch]
    public string Name { get; set; } = null!;
    [QuerySearch]
    public string Description { get; set; } = null!;
    public int? DiscountRate { get; set; }

    public ICollection<UserEmployee> UserEmployees { get; set; }
}
