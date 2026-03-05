namespace ModuleTech.Domain.Enums;

public enum BelgeDurumEnum
{
    Aktif = 1,
    SuresiDoldu = 2,
    Iptal = 3,
    YenilemeBasvurusuYapildi = 4,

    /// <summary>UC-IPT-003: Uygunsuzluk süresi verildi — atık alımı/işleme yapılamaz (Md.14(2))</summary>
    UygunsuzlukSuresiVerildi = 5,

    /// <summary>UC-IPT-006: Faaliyet sonlandırma sebebiyle iptal (Md.14(6))</summary>
    FaaliyetSonlandirmaIptal = 6,

    /// <summary>UC-OZL-005: Lisans konularına yönelik askıya alındı (Şartname 9.5.1.7)</summary>
    Askida = 7
}

