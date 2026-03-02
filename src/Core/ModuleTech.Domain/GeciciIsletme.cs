using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 7 - UC-MUA-003: Geçici işletme bildirimi. Başvuru değil, bildirim niteliğinde.
/// </summary>
public class GeciciIsletme : BaseSoftDeleteEntity
{
    /// <summary>
    /// UC-MUA-003 Adım 3: İlişkili tesis (varsa mevcut tesis, yoksa null).
    /// </summary>
    public Guid? TesisId { get; set; }

    /// <summary>
    /// UC-MUA-003 Adım 3: İşletme adı.
    /// </summary>
    public string IsletmeAdi { get; set; } = null!;

    /// <summary>
    /// UC-MUA-003 Adım 3: İşletme adresi.
    /// </summary>
    public string? Adres { get; set; }

    /// <summary>
    /// UC-MUA-003 Adım 3: Faaliyet konusu.
    /// </summary>
    public string? FaaliyetKonusu { get; set; }

    /// <summary>
    /// UC-MUA-003 Adım 3: Planlanan başlangıç tarihi.
    /// </summary>
    public DateTime BaslangicTarihi { get; set; }

    /// <summary>
    /// UC-MUA-003 Adım 3-4: Planlanan bitiş tarihi. Sistem 1 yıldan az olduğunu doğrular (BR-MUA-003).
    /// </summary>
    public DateTime BitisTarihi { get; set; }

    /// <summary>
    /// UC-MUA-003 Adım 3: İl bilgisi.
    /// </summary>
    public int IlKodu { get; set; }

    /// <summary>
    /// UC-MUA-003 Adım 5-8: Bildirim durumu.
    /// </summary>
    public GeciciIsletmeDurumEnum Durum { get; set; }

    // Navigation Properties
    public virtual Tesis? Tesis { get; set; }
}

