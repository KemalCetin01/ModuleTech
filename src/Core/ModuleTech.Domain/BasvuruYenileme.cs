using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// Yenileme ve güncelleme süreçleri detay tablosu (MODÜL 6).
/// Basvuru ile 1:1 ilişki. Tüm yenileme-spesifik alanları barındırır.
/// </summary>
public class BasvuruYenileme : BaseSoftDeleteEntity //Ok....
{
    public Guid BasvuruId { get; set; }

    /// <summary>
    /// Yenileme nedeni (hangi use case'e ait olduğunu belirtir).
    /// </summary>
    public YenilemeNedeniEnum YenilemeNedeni { get; set; }

    /// <summary>
    /// 180/90/30 gün kurallarına göre son başvuru tarihi.
    /// </summary>
    public DateTime? BasvuruSonTarih { get; set; }

    /// <summary>
    /// UC-YEN-002: 180 gün kuralına göre GFB süreci atlandı mı? (Md.11(1)c)
    /// </summary>
    public bool GFBAtlandi { get; set; }

    /// <summary>
    /// UC-YEN-002: Proses/çalışma koşullarında değişiklik olmadığı beyanı.
    /// </summary>
    public bool DegisiklikYokBeyani { get; set; }

    /// <summary>
    /// UC-YEN-005: Atık kodu ekleme yıl bilgisi (yılda 1 defa sınırı kontrolü).
    /// </summary>
    public int? AtikKoduEklemeYili { get; set; }

    /// <summary>
    /// UC-YEN-007: Münferit konu ekleme mi yoksa GFB yenileme mi?
    /// </summary>
    public bool MunferitKonuEkleme { get; set; }

    /// <summary>
    /// E-imza ile onaylanma tarihi.
    /// </summary>
    public DateTime? EImzaTarihi { get; set; }

    /// <summary>
    /// E-imza referans numarası.
    /// </summary>
    public string? EImzaReferansNo { get; set; }

    /// <summary>
    /// UC-YEN-006: Lisans konusu çıkarma nedeni açıklaması.
    /// </summary>
    public string? LisansKonuCikarmaAciklama { get; set; }

    /// <summary>
    /// UC-YEN-008: İyileştirme açıklaması.
    /// </summary>
    public string? IyilestirmeAciklama { get; set; }

    // Navigation Properties
    public virtual Basvuru Basvuru { get; set; } = null!;

    public virtual UnvanDegisiklik? UnvanDegisiklik { get; set; }

    public virtual ICollection<FaaliyetDegisiklik> FaaliyetDegisiklikler { get; set; } = new List<FaaliyetDegisiklik>();

    public virtual ICollection<BasvuruAtikKodu> BasvuruAtikKodlari { get; set; } = new List<BasvuruAtikKodu>();
}

