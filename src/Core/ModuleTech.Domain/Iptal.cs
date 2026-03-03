using ModuleTech.Core.BaseEntities;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Domain;

/// <summary>
/// MODÜL 8 - İptal süreçleri ana tablosu (UC-IPT-001..006).
/// Belge (GFB veya İzin/Lisans) ile N:1 ilişki — bir belge birden fazla kez iptal edilebilir
/// (iptal → aktifleştirme → tekrar iptal döngüsü).
/// </summary>
public class Iptal : BaseSoftDeleteEntity
{
    /// <summary>
    /// UC-IPT-001..006: Hangi belgeye (GFB/İzin/Lisans) ait olduğu. Belge tablosuyla FK.
    /// </summary>
    public Guid BelgeId { get; set; }

    /// <summary>
    /// UC-IPT-001 Adım 3: İlişkili başvuru. Başvuru bazlı iptallerde dolu olur:
    /// - UC-IPT-001 A1: Eksiklik süresinde tamamlanmayan başvuru (Md.8(3))
    /// - UC-IPT-001 A2: Red kararı verilen başvuru (Md.13(1))
    /// - UC-IPT-001 A3: Uygunluk yapılmayan başvuru (FR-DEG-035)
    /// Manuel/faaliyet sonlandırma gibi başvuru bağımsız iptallerde null.
    /// </summary>
    public Guid? BasvuruId { get; set; }

    /// <summary>
    /// UC-IPT-001..006: İptal senaryosu — süre aşımı, aykırılık, uygunsuzluk, manuel, faaliyet sonlandırma vb.
    /// </summary>
    public IptalTipiEnum IptalTipi { get; set; }

    /// <summary>
    /// UC-IPT-001 Adım 5 / UC-IPT-002 Adım 4 / UC-IPT-004 Adım 5:
    /// İptal gerekçesi açıklaması. Manuel iptalde zorunludur (BR-IPT-004).
    /// </summary>
    public string IptalGerekce { get; set; } = null!;

    /// <summary>
    /// UC-IPT-001 Adım 6 / UC-IPT-002 Adım 8: İptal işleminin gerçekleştiği tarih.
    /// </summary>
    public DateTime IptalTarihi { get; set; }

    /// <summary>
    /// UC-IPT-001: Sistem scheduler tarafından otomatik mi yapıldı, yoksa personel tarafından manuel mi.
    /// true = Sistem otomatik (UC-IPT-001 — günlük GFB süre kontrolü, eksiklik süre aşımı, red kararı),
    /// false = Personel/Manuel (UC-IPT-002/003/004/006).
    /// </summary>
    public bool OtomatikMi { get; set; }

    /// <summary>
    /// UC-IPT-002 Adım 3: Aykırılık nedeni alt kategorisi.
    /// Sadece IptalTipi = AykirilikTespiti ise dolu.
    /// </summary>
    public AykirilikNedeniEnum? AykirilikNedeni { get; set; }

    /// <summary>
    /// UC-IPT-004 Adım 3: Manuel iptal nedeni alt kategorisi.
    /// Sadece IptalTipi = ManuelIptal ise dolu.
    /// </summary>
    public ManuelIptalNedeniEnum? ManuelIptalNedeni { get; set; }
    public string? Gerekce { get; set; }

    /// <summary>
    /// UC-IPT-003 Adım 2: Uygunsuzluk gidermesi için verilen süre bitiş tarihi (en fazla 1 yıl — Md.14(2)).
    /// Sadece IptalTipi = UygunsuzlukGiderilmedi ise dolu.
    /// </summary>
    public DateTime? UygunsuzlukSureBitis { get; set; }

    /// <summary>
    /// UC-IPT-003 Alternatif 2a: Çevre/insan sağlığı tehlikesi var — süre verilmeksizin derhal iptal (Md.14(3)).
    /// </summary>
    public bool DerhalIptalMi { get; set; }

    /// <summary>
    /// UC-IPT-002 Adım 9a: Usulsüz bilgi/belge durumunda faaliyet durdurma süresi (gün).
    /// UC-IPT-003 Adım 4: Uygunsuzluk süresince işletme atık alımı/işleme yapamaz.
    /// Örn: Usulsüz belge → 90 gün (Md.13(3)).
    /// </summary>
    public int? FaaliyetDurdurmaGun { get; set; }

    /// <summary>
    /// UC-IPT-002 Alternatif 3c: Kasıtlı yangın durumunda 3 yıl başvuru yasağı bitiş tarihi (Md.13(6)).
    /// </summary>
    public DateTime? BasvuruYasakBitis { get; set; }

    /// <summary>
    /// UC-IPT-006 Adım 3: Faaliyet sonlandırma tarihi.
    /// Sadece IptalTipi = FaaliyetSonlandirma ise dolu.
    /// </summary>
    public DateTime? FaaliyetSonlandirmaTarihi { get; set; }

    /// <summary>
    /// UC-IPT-006 Adım 5: Lisans konusu tesislerde kapatma planı zorunlu mu (Md.14(6), Md.18(1)).
    /// BR-IPT-006: Lisans konulu tesislerde kapatma planı onayı zorunludur.
    /// </summary>
    public bool KapatmaPlaniZorunluMu { get; set; }

    /// <summary>
    /// UC-IPT-006 Adım 5b: Kapatma planı durumu — null: gerekmez, true: yüklendi, false: "Hazırlanacak" işaretli.
    /// </summary>
    public bool? KapatmaPlaniYuklendi { get; set; }

    /// <summary>
    /// UC-IPT-006 Adım 9b: Kapatma planı onay tarihi.
    /// </summary>
    public DateTime? KapatmaPlaniOnayTarihi { get; set; }

    /// <summary>
    /// UC-IPT-002 Adım 2: GFB İptal işlemini başlatan personel.
    /// UC-IPT-003 Adım 2: Uygunsuzluk süre veren / Adım 6a: İptal kararı veren personel.
    /// UC-IPT-004 Adım 1-2: Manuel iptal işlemini başlatan yetkili personel.
    /// Otomatik iptallerde (UC-IPT-001) null olur.
    /// </summary>
    public Guid? PersonelId { get; set; }

    /// <summary>
    /// UC-IPT-001 Adım 5: Mevzuat referansı — "Md.9(1)", "Md.8(3)", "Md.13(1)" vb.
    /// </summary>
    public string? MevzuatReferans { get; set; }

    // Navigation Properties
    public int TesisId { get; set; } 
    
    
    public virtual Tesis Tesis { get; set; } = null!;
    public virtual Belge Belge { get; set; } = null!;
    
    public virtual Basvuru? Basvuru { get; set; }
    public virtual IptalYenidenAktiflestirme? YenidenAktiflestirme { get; set; }
    public virtual ICollection<IptalBelge> IptalBelgeleri { get; set; } = new List<IptalBelge>();
}

