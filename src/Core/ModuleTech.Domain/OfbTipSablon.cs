using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 9 - UC-OZL-004: ÖFB (Özel Faaliyet Belgesi) tip şablonu.
/// Versiyonlama desteği ile yeni tipler eklenebilir yapıda olmalıdır.
/// BR-OZL-004: ÖFB şablonları versiyonlanır, yeni tipler eklenebilir (Şartname 9.5.12.3, 9.5.12.4).
/// </summary>
public class OfbTipSablon : BaseSoftDeleteEntity
{
    /// <summary>
    /// UC-OZL-004 Adım 4a: ÖFB tip adı.
    /// </summary>
    public string TipAdi { get; set; } = null!;

    /// <summary>
    /// UC-OZL-004 Adım 4a: ÖFB tip açıklaması.
    /// </summary>
    public string? Aciklama { get; set; }

    /// <summary>
    /// UC-OZL-004 Adım 8: Mevcut aktif versiyon numarası.
    /// Her güncelleme otomatik artırılır (UC-OZL-004 Adım 5c).
    /// </summary>
    public int AktifVersiyon { get; set; } = 1;

    /// <summary>
    /// UC-OZL-004 Adım 4b: Gerekli alan tanımları JSON formatında
    /// (atık kodları, işleme yöntemleri, kapasite bilgileri vb.).
    /// </summary>
    public string? AlanTanimlariJson { get; set; }

    /// <summary>
    /// UC-OZL-004 Adım 4c: Gerekli belge gereksinimleri JSON formatında.
    /// </summary>
    public string? BelgeGereksinimleriJson { get; set; }

    /// <summary>
    /// UC-OZL-004 Alternatif 3a: Şablon aktif/pasif durumu.
    /// Aktif kayıtlarda kullanılan şablon silinemez, pasif duruma alınır.
    /// </summary>
    public bool Aktif { get; set; } = true;

    // Navigation Properties

    /// <summary>
    /// UC-OZL-004 Adım 5-8: Şablonun versiyon geçmişi.
    /// </summary>
    public virtual ICollection<OfbTipSablonVersiyon> Versiyonlar { get; set; } = new List<OfbTipSablonVersiyon>();

    /// <summary>
    /// UC-OZL-003: Bu şablonla oluşturulmuş ÖFB kayıtları.
    /// UC-OZL-004 Alternatif 5d: Aktif kayıtlarda kullanım kontrolü.
    /// </summary>
    public virtual ICollection<OfbKayit> OfbKayitlari { get; set; } = new List<OfbKayit>();
}

