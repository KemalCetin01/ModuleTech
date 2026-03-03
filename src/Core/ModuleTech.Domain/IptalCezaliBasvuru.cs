using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 8 - UC-IPT-007: İptal sonrası cezalı yeniden başvuru takibi.
/// Belge ile N:1 ilişki — aynı belge için birden fazla iptal→yeniden başvuru döngüsü olabilir.
/// BR-IPT-007: Ceza kuralları Md.13(3) ve Md.13(4)'e göre uygulanır.
/// </summary>
public class IptalCezaliBasvuru : BaseSoftDeleteEntity
{
    /// <summary>
    /// UC-IPT-007 Adım 1: Hangi belgeye ait olduğu.
    /// </summary>
    public Guid BelgeId { get; set; }

    /// <summary>
    /// UC-IPT-007 Adım 2: Hangi iptal kaydından sonra oluşturulduğu.
    /// </summary>
    public Guid IptalId { get; set; }

    /// <summary>
    /// UC-IPT-007 Adım 1: İptal sonrası yapılan yeni başvuru. Basvuru tablosuyla FK.
    /// Sistem bu başvuru üzerinden ceza kurallarını uygular (Md.13(3), Md.13(4)).
    /// </summary>
    public Guid? YeniBasvuruId { get; set; }

    /// <summary>
    /// UC-IPT-007 Adım 3: Kaçıncı başarısız başvuru (1, 2, 3...).
    /// Ceza katsayısı ve durdurma süresi buna göre hesaplanır (Md.13(3), Md.13(4)).
    /// </summary>
    public int BasarisizBasvuruSayisi { get; set; }

    /// <summary>
    /// UC-IPT-007 Adım 4a/6a/8b: Belge bedeli çarpan katsayısı.
    /// İlk: 1x, usulsüz ilk: 2x, usulsüz ikinci: 4x (Md.13(3)).
    /// </summary>
    public decimal BedelCarpani { get; set; } = 1;

    /// <summary>
    /// UC-IPT-007 Adım 5a/7a/8a: Faaliyet yasak süresi (gün).
    /// İkinci başarısızlık: 60 gün, üçüncü: 90 gün, usulsüz ilk: 90 gün (Md.13(4)).
    /// </summary>
    public int? FaaliyetYasakGun { get; set; }

    /// <summary>
    /// UC-IPT-007 Adım 5b: Yasak başlangıç tarihi. null ise yasak yok.
    /// </summary>
    public DateTime? YasakBaslangic { get; set; }

    /// <summary>
    /// UC-IPT-007 Adım 5c: Yasak bitiş tarihi. Süre dolmadan başvuru kabul edilmez.
    /// </summary>
    public DateTime? YasakBitis { get; set; }

    /// <summary>
    /// UC-IPT-007 Adım 8: Usulsüz bilgi/belge kaynaklı iptal mi.
    /// true ise daha ağır ceza uygulanır (Md.13(3)).
    /// </summary>
    public bool UsulsuzBilgeMi { get; set; }

    /// <summary>
    /// UC-IPT-007 Adım 8b: Üçüncü usulsüz başvuruda 1 yıl faaliyet durdurma uygulanır mı.
    /// </summary>
    public bool BirYilDurdurmaMi { get; set; }

    // Navigation Properties
    public virtual Belge Belge { get; set; } = null!;
    public virtual Iptal Iptal { get; set; } = null!;
    public virtual Basvuru? YeniBasvuru { get; set; }
}

