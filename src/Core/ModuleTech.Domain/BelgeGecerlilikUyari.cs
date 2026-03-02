using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// UC-YEN-001: Belge geçerlilik süresi uyarı kaydı. Scheduler job tarafından üretilir.
/// </summary>
public class BelgeGecerlilikUyari : BaseSoftDeleteEntity//OK........
{
    public Guid BelgeId { get; set; }

    public UyariSeviyesiEnum UyariSeviyesi { get; set; }

    public DateTime PlanlananTarih { get; set; }

    public DateTime? GonderimTarihi { get; set; }

    public bool Gonderildi { get; set; }

    // Navigation Properties
    public virtual Belge Belge { get; set; } = null!;

    public virtual ICollection<Bildirim> Bildirimler { get; set; } = new List<Bildirim>();
}

