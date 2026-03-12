using ModuleTech.Core.Base.Attributes;
using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;
public class Product: BaseSoftDeleteEntity
{
    [QuerySearch]
    public string Name { get; set; }

    [QuerySearch]
    public string Url { get; set; }
}

