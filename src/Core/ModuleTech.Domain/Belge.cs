using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// İzin/Lisans belgesi. Tesis ile ilişkili.
/// </summary>
public class Belge : BaseSoftDeleteEntity //OK........
{
    public BelgeTipiEnum BelgeTipi { get; set; }

    public BelgeDurumEnum BelgeDurum { get; set; }

    public string? BelgeNo { get; set; }

    public string? BelgeAdi { get; set; }

    public DateTime DuzenlemeTarihi { get; set; }

    public DateTime GecerlilikBaslangicTarihi { get; set; }

    public DateTime GecerlilikBitisTarihi { get; set; }

    public double? BelgeBedeli { get; set; }

    public Guid TesisId { get; set; }

    // Navigation Properties
    public virtual Tesis Tesis { get; set; } = null!;

    public virtual ICollection<Basvuru> Basvurular { get; set; } = new List<Basvuru>();

    public virtual ICollection<BelgeGecerlilikUyari> GecerlilikUyarilari { get; set; } = new List<BelgeGecerlilikUyari>();

    public virtual ICollection<BelgeLisansKonu> BelgeLisansKonulari { get; set; } = new List<BelgeLisansKonu>();

    public virtual ICollection<Iptal> Iptaller { get; set; } = new List<Iptal>();

    public virtual ICollection<IptalCezaliBasvuru> IptalCezaliBasvurular { get; set; } = new List<IptalCezaliBasvuru>();

    /// <summary>MODÜL 9: Belgeye ait görüş talepleri.</summary>
    public virtual ICollection<GorusTalebi> GorusTalepleri { get; set; } = new List<GorusTalebi>();

    /// <summary>MODÜL 9 - UC-OZL-005: Belge askıya alma kayıtları.</summary>
    public virtual ICollection<BelgeAski> BelgeAskilari { get; set; } = new List<BelgeAski>();
}

