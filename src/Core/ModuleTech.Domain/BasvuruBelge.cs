using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// Başvuruya yüklenen belgeler/dosyalar. E-imza destekli.
/// </summary>
public class BasvuruBelge : BaseSoftDeleteEntity //OK........
{
    public Guid BasvuruId { get; set; }

    public string DosyaAdi { get; set; } = null!;

    public string DosyaYolu { get; set; } = null!;

    public string? DosyaTipi { get; set; }

    public long DosyaBoyutu { get; set; }

    public bool EImzali { get; set; }

    public DateTime? EImzaTarihi { get; set; }

    public string? EImzaReferansNo { get; set; }

    public DateTime YuklemeTarihi { get; set; }

    // Navigation Properties
    public virtual Basvuru Basvuru { get; set; } = null!;
}

