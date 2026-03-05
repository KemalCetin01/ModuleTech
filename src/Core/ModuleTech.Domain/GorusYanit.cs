using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 9 - UC-OZL-002: Bakanlık personelinin görüş talebine verdiği yanıt.
/// GorusTalebi ile 1:1 ilişki — her talep en fazla 1 yanıt alabilir.
/// BR-OZL-002: Yanıtlar tanımlı şablonlar kullanılarak hazırlanır ve imza akışına sunulur (Şartname 9.5.9.2).
/// </summary>
public class GorusYanit : BaseSoftDeleteEntity
{
    /// <summary>
    /// UC-OZL-002 Adım 1: Hangi görüş talebine yanıt verildiği. GorusTalebi ile 1:1 FK.
    /// </summary>
    public Guid GorusTalebiId { get; set; }

    /// <summary>
    /// UC-OZL-002 Adım 4: Kullanılan şablon adı/referansı. 
    /// Alternatif 4a: Uygun şablon bulunamazsa null — serbest metin yazılır.
    /// </summary>
    public string? SablonReferans { get; set; }

    /// <summary>
    /// UC-OZL-002 Adım 5: Görüş yazısı içeriği (personel tarafından düzenlenir).
    /// </summary>
    public string YanitIcerik { get; set; } = null!;

    /// <summary>
    /// UC-OZL-002 Adım 3: Yanıtı hazırlayan Bakanlık personeli.
    /// </summary>
    public Guid HazirlayanPersonelId { get; set; }

    /// <summary>
    /// UC-OZL-002 Adım 7: Şube Müdürü onay veren kişi.
    /// </summary>
    public Guid? OnaylayanId { get; set; }

    /// <summary>
    /// UC-OZL-002 Adım 7: Onay tarihi.
    /// </summary>
    public DateTime? OnayTarihi { get; set; }

    /// <summary>
    /// UC-OZL-002 Adım 8: e-İmza tarihi (Belgenet).
    /// </summary>
    public DateTime? EImzaTarihi { get; set; }

    /// <summary>
    /// UC-OZL-002 Adım 8: e-İmza referans numarası.
    /// </summary>
    public string? EImzaReferansNo { get; set; }

    /// <summary>
    /// UC-OZL-002 Adım 10: Yanıtın oluşturulma → onay süreci kaç gün sürdüğü.
    /// </summary>
    public int? YanitSureGun { get; set; }

    // Navigation Properties
    public virtual GorusTalebi GorusTalebi { get; set; } = null!;
    public virtual User HazirlayanPersonel { get; set; } = null!;
    public virtual User? Onaylayan { get; set; }
}

