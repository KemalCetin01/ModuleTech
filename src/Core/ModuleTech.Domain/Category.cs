using ModuleTech.Core.Base.Attributes;
using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;
public class Category : BaseSoftDeleteEntity
{
    [QuerySearch]
    public string Name { get; set; }

    [QuerySearch]
    public string Description { get; set; }
}
