using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

public class Basvuru : BaseSoftDeleteEntity //OK...
{
    public BasvuruTipiEnum BasvuruTipi { get; set; }

    public string? BasvuruNedeni { get; set; }

    public string? Unvan { get; set; }

    public string? TcNo { get; set; }

    public string? Ckn { get; set; }

    public string? Vkn { get; set; }

    public BasvuruDurumEnum BasvuruDurum { get; set; }

    public Guid? BelgeId { get; set; }

    public Guid? TesisId { get; set; }

    public Guid? IzinLisansKonuId { get; set; }

    public string? MevzuatReferans { get; set; }

    public Guid? BelgeYenId { get; set; }

    // Navigation Properties
    public virtual Belge? Belge { get; set; }

    public virtual Tesis? Tesis { get; set; }

    public virtual IzinLisansKonu? IzinLisansKonu { get; set; }

    public virtual Belge? BelgeYen { get; set; }

    /// <summary>
    /// Yenileme detayları (1:1). Sadece yenileme başvurularında dolu olur.
    /// </summary>
    public virtual BasvuruYenileme? BasvuruYenileme { get; set; }

    /// <summary>
    /// Muafiyet detayları (1:1). Sadece muafiyet başvurularında dolu olur.
    /// </summary>
    public virtual Muafiyet? Muafiyet { get; set; }

    public virtual ICollection<BasvuruBelge> BasvuruBelgeleri { get; set; } = new List<BasvuruBelge>();

    public virtual ICollection<Bildirim> Bildirimler { get; set; } = new List<Bildirim>();

    /// <summary>
    /// MODÜL 8: Bu başvuruyla ilişkili iptal kayıtları.
    /// UC-IPT-001 A1 (eksiklik süre aşımı), A2 (başvuru red), A3 (uygunluk yapılmadı) senaryoları.
    /// </summary>
    public virtual ICollection<Iptal> Iptaller { get; set; } = new List<Iptal>();
}

