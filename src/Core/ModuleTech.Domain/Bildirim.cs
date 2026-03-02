using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// Bildirim entity'si. E-posta, SMS, sistem içi bildirim kanalları.
/// UC-YEN-001 ve genel bildirim altyapısı için kullanılır.
/// </summary>
public class Bildirim : BaseSoftDeleteEntity//OK........
{
    public BildirimTipiEnum BildirimTipi { get; set; }

    public BildirimDurumEnum BildirimDurum { get; set; }

    public Guid AliciId { get; set; }

    public string? AliciEposta { get; set; }

    public string? AliciTelefon { get; set; }

    public string Baslik { get; set; } = null!;

    public string Icerik { get; set; } = null!;

    public DateTime? GonderimTarihi { get; set; }

    public int DenemeSayisi { get; set; }

    public string? HataMesaji { get; set; }

    public Guid? BelgeId { get; set; }

    public Guid? BasvuruId { get; set; }

    public Guid? BelgeGecerlilikUyariId { get; set; }

    // Navigation Properties
    public virtual User Alici { get; set; } = null!;

    public virtual Belge? Belge { get; set; }

    public virtual Basvuru? Basvuru { get; set; }

    public virtual BelgeGecerlilikUyari? BelgeGecerlilikUyari { get; set; }
}

