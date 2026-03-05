using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 9 - UC-OZL-005 Adım 3-4: Askıya alınan lisans konuları.
/// BelgeAski ↔ IzinLisansKonu many-to-many join entity'si.
/// Bir askı işleminde birden fazla lisans konusu askıya alınabilir (UC-OZL-005 Adım 4).
/// </summary>
public class BelgeAskiLisansKonu : BaseSoftDeleteEntity
{
    /// <summary>
    /// Hangi askı kaydına ait.
    /// </summary>
    public Guid BelgeAskiId { get; set; }

    /// <summary>
    /// UC-OZL-005 Adım 4: Askıya alınan lisans konusu.
    /// </summary>
    public Guid IzinLisansKonuId { get; set; }

    // Navigation Properties
    public virtual BelgeAski BelgeAski { get; set; } = null!;
    public virtual IzinLisansKonu IzinLisansKonu { get; set; } = null!;
}

