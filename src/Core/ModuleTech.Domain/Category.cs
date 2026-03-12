using ModuleTech.Core.Base.Attributes;
using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;
public class Category : BaseSoftDeleteEntity
{
    [QuerySearch]
    public string Name { get; set; }

    [QuerySearch]
    public string Description { get; set; }

    public MuafiyetDurumEnum? MuafiyetDurum { get; set; }
}
