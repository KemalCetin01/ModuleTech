using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 9 - UC-OZL-003: Özel Faaliyet Belgesi (ÖFB) kaydı.
/// Tesis ile N:1 ilişki — bir tesis birden fazla ÖFB kaydına sahip olabilir.
/// OfbTipSablon ile N:1 ilişki — her ÖFB kaydı bir şablon tipine bağlıdır.
/// BR-OZL-003: ÖFB kayıt işlemleri yetkili personel tarafından gerçekleştirilir (Şartname 9.5.12.2).
/// </summary>
public class OfbKayit : BaseSoftDeleteEntity
{
    /// <summary>
    /// UC-OZL-003 Adım 5: Hangi tesise ait ÖFB kaydı.
    /// </summary>
    public Guid TesisId { get; set; }

    /// <summary>
    /// UC-OZL-003 Adım 2-3: Seçilen ÖFB tip şablonu.
    /// Alternatif 3a: Uygun tip bulunamazsa yeni şablon tanımlanır (UC-OZL-004).
    /// </summary>
    public Guid OfbTipSablonId { get; set; }

    /// <summary>
    /// UC-OZL-003 Adım 3: Kayıt oluşturulduğu andaki şablon versiyon numarası.
    /// UC-OZL-004 Alternatif 5d: Değişiklikler yalnızca yeni kayıtları etkiler.
    /// </summary>
    public int SablonVersiyonNo { get; set; }

    /// <summary>
    /// UC-OZL-003 Adım 6b: İşleme yöntemleri (JSON formatında).
    /// </summary>
    public string? IslemeYontemleriJson { get; set; }

    /// <summary>
    /// UC-OZL-003 Adım 6c: Kapasite bilgileri (JSON formatında).
    /// </summary>
    public string? KapasiteBilgileriJson { get; set; }

    /// <summary>
    /// UC-OZL-003 Adım 8-10: Kayıt durumu.
    /// </summary>
    public OfbDurumEnum Durum { get; set; }

    /// <summary>
    /// UC-OZL-003 Adım 9: Kaydı onaylayan personel.
    /// </summary>
    public Guid OlusturanPersonelId { get; set; }

    // Navigation Properties
    public virtual Tesis Tesis { get; set; } = null!;
    public virtual OfbTipSablon OfbTipSablon { get; set; } = null!;
    public virtual User OlusturanPersonel { get; set; } = null!;

    /// <summary>
    /// UC-OZL-003 Adım 6a: ÖFB'ye ait atık kodları (M:N).
    /// </summary>
    public virtual ICollection<OfbAtikKodu> OfbAtikKodlari { get; set; } = new List<OfbAtikKodu>();

    /// <summary>
    /// UC-OZL-003 Adım 7: ÖFB kaydına yüklenen belgeler.
    /// </summary>
    public virtual ICollection<OfbKayitBelge> OfbKayitBelgeleri { get; set; } = new List<OfbKayitBelge>();
}

