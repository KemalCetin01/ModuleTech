using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 9 - UC-OZL-001 Adım 6: Görüş talebine eklenen destekleyici belgeler.
/// GorusTalebi ile N:1 ilişki.
/// </summary>
public class GorusTalebiBelge : BaseSoftDeleteEntity
{
    /// <summary>
    /// Hangi görüş talebine ait olduğu.
    /// </summary>
    public Guid GorusTalebiId { get; set; }

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
    public virtual GorusTalebi GorusTalebi { get; set; } = null!;
}

