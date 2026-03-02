using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// UC-YEN-004: Unvan değişikliği başvurusu detayları.
/// Geçerlilik süresi değişmeden belge güncellenir.
/// </summary>
public class UnvanDegisiklik : BaseSoftDeleteEntity//OK........
{
    public Guid BasvuruYenilemeId { get; set; }

    public string? SicilGazetesiNo { get; set; }

    public DateTime? SicilGazetesiTarihi { get; set; }

    /// <summary>
    /// Belge bedeli. 90 günlük süre aşılırsa 2 kat uygulanır (Md.12(4)).
    /// </summary>
    public double? BelgeBedeli { get; set; }

    /// <summary>
    /// Süre aşımı nedeniyle 2 kat bedel uygulandı mı?
    /// </summary>
    public bool IkiKatBedelUygulandi { get; set; }

    public DateTime DegisiklikTarihi { get; set; }

    /// <summary>
    /// 90 günlük başvuru son tarihi.
    /// </summary>
    public DateTime BasvuruSonTarih { get; set; }

    // Navigation Properties
    public virtual BasvuruYenileme BasvuruYenileme { get; set; } = null!;
}

