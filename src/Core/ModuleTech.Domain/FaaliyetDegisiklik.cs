using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// UC-YEN-003 / UC-YEN-008: Faaliyet değişikliği ve iyileştirme bildirimi detayları.
/// </summary>
public class FaaliyetDegisiklik : BaseSoftDeleteEntity //OK........
{
    public Guid BasvuruYenilemeId { get; set; }

    public FaaliyetDegisiklikTipiEnum DegisiklikTipi { get; set; }

    public string? EskiDeger { get; set; }

    public string? YeniDeger { get; set; }

    /// <summary>
    /// UC-YEN-003: Kapasite artışı yüzdesi (%33 kuralı kontrolü).
    /// </summary>
    public double? KapasiteDegisimOrani { get; set; }

    /// <summary>
    /// EK-1/EK-2 kapsam değişikliği kontrolü (EK-2'den EK-1'e geçiş).
    /// </summary>
    public bool EkKapsamDegisikligiVar { get; set; }

    public DateTime DegisiklikTarihi { get; set; }

    /// <summary>
    /// UC-YEN-008: 30 günlük bildirim son tarihi (Md.11(2)ç).
    /// </summary>
    public DateTime? BildirimSonTarih { get; set; }

    /// <summary>
    /// UC-YEN-003: 90 günlük yenileme başvuru son tarihi (Md.11(2)e).
    /// </summary>
    public DateTime? YenilemeSonTarih { get; set; }

    public string? Aciklama { get; set; }

    /// <summary>
    /// UC-YEN-008: İyileştirme bildirimi mi? (Md.11(2)a dışı).
    /// </summary>
    public bool IyilestirmeBildirimi { get; set; }

    /// <summary>
    /// UC-YEN-008: Yetkili merci yenileme kararı verdi mi?
    /// </summary>
    public bool YenilemeGerekli { get; set; }

    // Navigation Properties
    public virtual BasvuruYenileme BasvuruYenileme { get; set; } = null!;
}

