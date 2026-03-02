using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

/// <summary>
/// İzin/Lisans konusu referans entity'si.
/// UC-YEN-005, UC-YEN-006, UC-YEN-007 için kullanılır.
/// </summary>
public class IzinLisansKonu : BaseSoftDeleteEntity //OK........
{
    public string KonuAdi { get; set; } = null!;

    public string? KonuKodu { get; set; }

    public string? Aciklama { get; set; }

    public bool Aktif { get; set; } = true;

    // Navigation Properties
    public virtual ICollection<BelgeLisansKonu> BelgeLisansKonulari { get; set; } = new List<BelgeLisansKonu>();
}

