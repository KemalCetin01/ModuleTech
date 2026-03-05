using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 9 - UC-OZL-005: Belge askıya alma/kaldırma ana tablosu.
/// Belge ile N:1 ilişki — bir belge birden fazla kez askıya alınabilir.
/// BR-OZL-005: Askıya alma süresi belirlenmeli ve gerekçe girilmelidir (Şartname 9.5.1.7).
/// </summary>
public class BelgeAski : BaseSoftDeleteEntity
{
    /// <summary>
    /// UC-OZL-005 Adım 1: Hangi belgeye ait askı işlemi.
    /// </summary>
    public Guid BelgeId { get; set; }

    /// <summary>
    /// UC-OZL-005 Adım 5: Askıya alma gerekçesi (zorunlu alan — Alternatif 5a).
    /// BR-OZL-005: Gerekçe girilmelidir.
    /// </summary>
    public string Gerekce { get; set; } = null!;

    /// <summary>
    /// UC-OZL-005 Adım 6: Askı başlangıç tarihi.
    /// </summary>
    public DateTime AskiBaslangicTarihi { get; set; }

    /// <summary>
    /// UC-OZL-005 Adım 6: Askı bitiş tarihi.
    /// BR-OZL-005: Askıya alma süresi belirlenmeli.
    /// </summary>
    public DateTime AskiBitisTarihi { get; set; }

    /// <summary>
    /// UC-OZL-005 Adım 7: Süre dolduğunda otomatik aktifleştirme mi yoksa manuel onay mı.
    /// </summary>
    public AskiBitisIslemEnum BitisIslemi { get; set; }

    /// <summary>
    /// UC-OZL-005 Adım 9 → Alternatif A1/A2: Askı durumu.
    /// </summary>
    public AskiDurumEnum Durum { get; set; }

    /// <summary>
    /// UC-OZL-005 Alternatif A2.2: Erken kaldırma veya süre sonu kaldırma gerekçesi.
    /// </summary>
    public string? KaldirmaGerekce { get; set; }

    /// <summary>
    /// UC-OZL-005 Alternatif A1/A2: Askının fiilen kaldırıldığı tarih.
    /// </summary>
    public DateTime? KaldirmaTarihi { get; set; }

    /// <summary>
    /// UC-OZL-005 Adım 8/11: İşlemi yapan personel.
    /// </summary>
    public Guid PersonelId { get; set; }

    // Navigation Properties
    public virtual Belge Belge { get; set; } = null!;
    public virtual User Personel { get; set; } = null!;

    /// <summary>
    /// UC-OZL-005 Adım 3-4: Askıya alınan lisans konuları.
    /// </summary>
    public virtual ICollection<BelgeAskiLisansKonu> AskiLisansKonulari { get; set; } = new List<BelgeAskiLisansKonu>();
}

