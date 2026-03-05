using ModuleTech.Core.BaseEntities;

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

    public virtual ICollection<GeciciIsletme> GeciciIsletmeler { get; set; } = new List<GeciciIsletme>();

    /// <summary>MODÜL 9: Tesise ait görüş talepleri.</summary>
    public virtual ICollection<GorusTalebi> GorusTalepleri { get; set; } = new List<GorusTalebi>();

    /// <summary>MODÜL 9: Tesise ait ÖFB kayıtları.</summary>
    public virtual ICollection<OfbKayit> OfbKayitlari { get; set; } = new List<OfbKayit>();
}

