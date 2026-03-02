using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// Tesis (facility) bilgileri.
/// </summary>
public class Tesis : BaseSoftDeleteEntity
{
    public string TesisAdi { get; set; } = null!;

    public string? TesisNo { get; set; }

    public string? Adres { get; set; }

    public int? IlKodu { get; set; }

    public int? IlceKodu { get; set; }

    public string? Telefon { get; set; }

    public string? Eposta { get; set; }

    public bool BildirimAktif { get; set; } = true;

    public Guid? SorumluKisiId { get; set; }

    // Navigation Properties
    public virtual User? SorumluKisi { get; set; }

    public virtual ICollection<Belge> Belgeler { get; set; } = new List<Belge>();

    public virtual ICollection<Basvuru> Basvurular { get; set; } = new List<Basvuru>();
}

