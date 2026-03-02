using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 7 - Muafiyet detay tablosu. Basvuru ile 1:1 ilişki.
/// </summary>
public class Muafiyet : BaseSoftDeleteEntity
{
    /// <summary>
    /// UC-MUA-001 Adım 1: Hangi başvuruya ait olduğu. Basvuru.BasvuruTipi ile birlikte kullanılır.
    /// </summary>
    public Guid BasvuruId { get; set; }

    /// <summary>
    /// UC-MUA-001 Adım 2-3: Seçilen muafiyet tipi (Hava Emisyonu / Atıksu Deşarjı / Çevresel Gürültü).
    /// </summary>
    public MuafiyetTipiEnum MuafiyetTipi { get; set; }

    /// <summary>
    /// UC-MUA-001 Adım 4a/5a: ÇG'nin emisyon/deşarj olmadığına dair beyanı.
    /// </summary>
    public bool BeyanOnay { get; set; }

    /// <summary>
    /// UC-MUA-001 Adım 5b: Atıksu bertaraf yöntemi (kanalizasyon, vidanjör vb.). Sadece AtıksuDeşarjı tipinde dolu.
    /// </summary>
    public string? BertarafYontemi { get; set; }

    /// <summary>
    /// UC-MUA-001 Alternatif 4c: EK-1/EK-2 dipnot referansı. Sistem otomatik muafiyet önerdiğinde dolar.
    /// </summary>
    public string? DipnotReferans { get; set; }

    /// <summary>
    /// UC-MUA-001 Adım 10: Muafiyet yazısı/belgesi düzenlenme tarihi.
    /// </summary>
    public DateTime? MuafiyetBelgeTarihi { get; set; }

    // Navigation Properties
    public virtual Basvuru Basvuru { get; set; } = null!;
}

