using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 9 - UC-OZL-003 Adım 7: ÖFB kaydına yüklenen belgeler.
/// OfbKayit ile N:1 ilişki.
/// </summary>
public class OfbKayitBelge : BaseSoftDeleteEntity
{
    /// <summary>
    /// Hangi ÖFB kaydına ait.
    /// </summary>
    public Guid OfbKayitId { get; set; }

    /// <summary>
    /// Dosya adı (orijinal).
    /// </summary>
    public string DosyaAdi { get; set; } = null!;

    /// <summary>
    /// Dosya yolu veya storage key.
    /// </summary>
    public string DosyaYolu { get; set; } = null!;

    /// <summary>
    /// Dosya boyutu (byte).
    /// </summary>
    public long DosyaBoyutu { get; set; }

    /// <summary>
    /// Belge açıklaması.
    /// </summary>
    public string? Aciklama { get; set; }

    /// <summary>
    /// Yükleme tarihi.
    /// </summary>
    public DateTime YuklemeTarihi { get; set; }

    // Navigation Properties
    public virtual OfbKayit OfbKayit { get; set; } = null!;
}

