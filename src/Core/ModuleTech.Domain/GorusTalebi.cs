using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 9 - UC-OZL-001/002: Görüş talebi ana tablosu.
/// ÇG'nin İzin/Lisans belgesine ilişkin Bakanlık'tan görüş talep ettiği süreç.
/// Tesis ile N:1 ilişki — bir tesis için birden fazla görüş talebi oluşturulabilir.
/// Belge ile N:1 ilişki — aktif belgeye referans (opsiyonel).
/// BR-OZL-001: Görüş talepleri Bakanlık tarafından değerlendirilir (Şartname 9.5.9.2).
/// </summary>
public class GorusTalebi : BaseSoftDeleteEntity
{
    /// <summary>
    /// UC-OZL-001 Adım 1: Hangi tesise ait görüş talebi olduğu.
    /// </summary>
    public Guid TesisId { get; set; }

    /// <summary>
    /// UC-OZL-001 Alternatif 5a: İlişkili İzin/Lisans belgesi.
    /// Belge yoksa null olabilir — sistem uyarı verir (5a1).
    /// </summary>
    public Guid? BelgeId { get; set; }

    /// <summary>
    /// UC-OZL-001 Adım 2-3: Görüş talebi türü (belge görüşü / yenileme gerekliliği görüşü).
    /// </summary>
    public GorusTalebiTipiEnum TalepTipi { get; set; }

    /// <summary>
    /// UC-OZL-001 Adım 5: Görüş talebi konusu başlığı.
    /// </summary>
    public string Konu { get; set; } = null!;

    /// <summary>
    /// UC-OZL-001 Adım 5: Görüş talebi detaylı açıklaması.
    /// </summary>
    public string Detay { get; set; } = null!;

    /// <summary>
    /// UC-OZL-001 → UC-OZL-002: Talebin yaşam döngüsü durumu.
    /// </summary>
    public GorusTalebiDurumEnum Durum { get; set; }

    /// <summary>
    /// UC-OZL-001 Adım 7: ÇG e-imza tarihi.
    /// </summary>
    public DateTime? EImzaTarihi { get; set; }

    /// <summary>
    /// UC-OZL-001 Adım 7: e-İmza referans numarası.
    /// </summary>
    public string? EImzaReferansNo { get; set; }

    /// <summary>
    /// UC-OZL-001 Adım 8: Talebin Bakanlık'a gönderim tarihi.
    /// </summary>
    public DateTime? GonderimTarihi { get; set; }

    /// <summary>
    /// UC-OZL-001 Adım 1: Talebi oluşturan ÇG kullanıcı ID'si.
    /// </summary>
    public Guid TalepEdenId { get; set; }

    // Navigation Properties
    public virtual Tesis Tesis { get; set; } = null!;
    public virtual Belge? Belge { get; set; }
    public virtual User TalepEden { get; set; } = null!;

    /// <summary>
    /// UC-OZL-002: Görüş yanıtı (1:1). Bakanlık yanıtladığında dolu olur.
    /// </summary>
    public virtual GorusYanit? GorusYanit { get; set; }

    /// <summary>
    /// UC-OZL-001 Adım 6: Talebe yüklenen destekleyici belgeler.
    /// </summary>
    public virtual ICollection<GorusTalebiBelge> GorusTalebiBelgeleri { get; set; } = new List<GorusTalebiBelge>();
}

