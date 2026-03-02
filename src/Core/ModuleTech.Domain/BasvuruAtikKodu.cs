using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// BasvuruYenileme ↔ AtikKodu many-to-many join entity'si.
/// UC-YEN-005: Başvuruya eklenmek istenen atık kodları.
/// </summary>
public class BasvuruAtikKodu : BaseSoftDeleteEntity //OK........
{
    public Guid BasvuruYenilemeId { get; set; }

    public Guid AtikKoduId { get; set; }

    // Navigation Properties
    public virtual BasvuruYenileme BasvuruYenileme { get; set; } = null!;

    public virtual AtikKodu AtikKodu { get; set; } = null!;
}

