using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 8 - UC-IPT-002 Adım 5 / UC-IPT-004 Adım 6 / UC-IPT-005 Adım 5:
/// İptal veya aktifleştirme işlemine eklenen destekleyici belgeler
/// (denetim raporu, mahkeme kararı, soruşturma sonucu vb.).
/// Iptal ile N:1 ilişki.
/// </summary>
public class IptalBelge : BaseSoftDeleteEntity
{
    /// <summary>
    /// Hangi iptal kaydına ait.
    /// </summary>
    public Guid IptalId { get; set; }

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
    /// Belge açıklaması (denetim raporu, mahkeme kararı, soruşturma sonucu vb.).
    /// </summary>
    public string? Aciklama { get; set; }

    /// <summary>
    /// Yükleme tarihi.
    /// </summary>
    public DateTime YuklemeTarihi { get; set; }

    // Navigation Properties
    public virtual Iptal Iptal { get; set; } = null!;
}

