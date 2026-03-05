using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// Atık kodu referans verisi. UC-YEN-005 için kullanılır.
/// </summary>
public class AtikKodu : BaseSoftDeleteEntity //OK........
{
    public string Kod { get; set; } = null!;

    public string Tanim { get; set; } = null!;

    public bool Aktif { get; set; } = true;

    // Navigation Properties
    public virtual ICollection<BasvuruAtikKodu> BasvuruAtikKodlari { get; set; } = new List<BasvuruAtikKodu>();

    /// <summary>MODÜL 9 - UC-OZL-003: ÖFB kayıtlarıyla ilişkili atık kodları.</summary>
    public virtual ICollection<OfbAtikKodu> OfbAtikKodlari { get; set; } = new List<OfbAtikKodu>();
}

