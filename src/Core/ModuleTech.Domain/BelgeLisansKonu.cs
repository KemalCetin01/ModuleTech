using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// Belge ↔ IzinLisansKonu many-to-many join entity'si.
/// UC-YEN-006: Lisans konusu çıkarma durumu da bu tablo üzerinden yönetilir.
/// </summary>
public class BelgeLisansKonu : BaseSoftDeleteEntity//OK........??
{
    public Guid BelgeId { get; set; }

    public Guid IzinLisansKonuId { get; set; }

    public DateTime EklemeTarihi { get; set; }

    public DateTime? CikarmaTarihi { get; set; }

    public bool Aktif { get; set; } = true;

    /// <summary>
    /// UC-YEN-006: Çıkarma nedeni (proses kaldırıldı veya muaf olundu).
    /// </summary>
    public LisansKonuCikarmaNedeniEnum? CikarmaNedeni { get; set; }

    public string? CikarmaAciklamasi { get; set; }

    // Navigation Properties
    public virtual Belge Belge { get; set; } = null!;

    public virtual IzinLisansKonu IzinLisansKonu { get; set; } = null!;
}

