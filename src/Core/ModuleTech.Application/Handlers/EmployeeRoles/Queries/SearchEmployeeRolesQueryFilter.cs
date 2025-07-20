using ModuleTech.Core.Base.Handlers.Search;

namespace ModuleTech.Application.Handlers.EmployeeRoles.Queries;
public class SearchEmployeeRolesQueryFilter : IFilter
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int FirstDiscountRate { get; set; }
    public int LastDiscountRate { get; set; }
}
