using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 8 - UC-IPT-005: İptal edilen belgenin yeniden aktifleştirilmesi.
/// Iptal ile 1:1 ilişki — her iptal kaydı en fazla 1 kez aktifleştirilebilir.
/// BR-IPT-005: Yeniden aktifleştirme çift onay gerektirir.
/// </summary>
public class IptalYenidenAktiflestirme : BaseSoftDeleteEntity
{
    /// <summary>
    /// UC-IPT-005: Hangi iptal kaydının aktifleştirildiği. Iptal tablosuyla 1:1 FK.
    /// </summary>
    public Guid IptalId { get; set; }

    /// <summary>
    /// UC-IPT-005 Adım 3: Aktifleştirme neden kategorisi (mahkeme kararı, idari itiraz, hatalı iptal).
    /// </summary>
    public AktiflestirmeNedeniEnum AktiflestirmeNedeni { get; set; }

    /// <summary>
    /// UC-IPT-005 Adım 6: Aktifleştirme gerekçe notu.
    /// </summary>
    public string AktiflestirmeNotu { get; set; } = null!;

    /// <summary>
    /// UC-IPT-005 Adım 10: Belgenin yeniden geçerli olduğu tarih.
    /// </summary>
    public DateTime AktiflestirmeTarihi { get; set; }

    /// <summary>
    /// UC-IPT-005 Adım 7: İlk onayı veren personel ID (BR-IPT-005 çift onay — 1. onay).
    /// </summary>
    public Guid basvuruPersonelSurecId { get; set; } 

    // Navigation Properties
    public virtual Iptal Iptal { get; set; } = null!;
    
    
}

