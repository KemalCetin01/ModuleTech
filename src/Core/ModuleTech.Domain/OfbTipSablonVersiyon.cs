using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 9 - UC-OZL-004 Adım 5-8: ÖFB tip şablonu versiyon geçmişi.
/// Her güncelleme yeni bir versiyon kaydı oluşturur (Şartname 9.5.12.3, 9.5.12.4).
/// OfbTipSablon ile N:1 ilişki.
/// </summary>
public class OfbTipSablonVersiyon : BaseSoftDeleteEntity
{
    /// <summary>
    /// Hangi şablona ait versiyon.
    /// </summary>
    public Guid OfbTipSablonId { get; set; }

    /// <summary>
    /// UC-OZL-004 Adım 8: Versiyon numarası (1, 2, 3...).
    /// </summary>
    public int VersiyonNo { get; set; }

    /// <summary>
    /// UC-OZL-004 Adım 5b: Versiyon oluşturulma sırasındaki alan tanımları snapshot'ı (JSON).
    /// </summary>
    public string? AlanTanimlariJson { get; set; }

    /// <summary>
    /// UC-OZL-004 Adım 5b: Belge gereksinimleri snapshot'ı (JSON).
    /// </summary>
    public string? BelgeGereksinimleriJson { get; set; }

    /// <summary>
    /// UC-OZL-004 Adım 6: Önceki versiyondan fark açıklaması.
    /// </summary>
    public string? DegisiklikAciklamasi { get; set; }

    /// <summary>
    /// UC-OZL-004 Adım 7: Değişikliği onaylayan yönetici.
    /// </summary>
    public Guid OlusturanId { get; set; }

    // Navigation Properties
    public virtual OfbTipSablon OfbTipSablon { get; set; } = null!;
    public virtual User Olusturan { get; set; } = null!;
}

