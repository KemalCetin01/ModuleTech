using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 9 - UC-OZL-003 Adım 6a: OfbKayit ↔ AtikKodu many-to-many join entity'si.
/// ÖFB kaydına tanımlanan atık kodları.
/// </summary>
public class OfbAtikKodu : BaseSoftDeleteEntity
{
    /// <summary>
    /// Hangi ÖFB kaydına ait.
    /// </summary>
    public Guid OfbKayitId { get; set; }

    /// <summary>
    /// Seçilen atık kodu referansı.
    /// </summary>
    public Guid AtikKoduId { get; set; }

    // Navigation Properties
    public virtual OfbKayit OfbKayit { get; set; } = null!;
    public virtual AtikKodu AtikKodu { get; set; } = null!;
}

