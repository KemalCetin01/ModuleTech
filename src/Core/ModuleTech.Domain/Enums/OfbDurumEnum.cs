namespace ModuleTech.Domain.Enums;

/// <summary>
/// UC-OZL-003: ÖFB kayıt durumları.
/// </summary>
public enum OfbDurumEnum
{
    /// <summary>UC-OZL-003 Adım 5-8: Form doldurulmaya devam ediyor.</summary>
    Taslak = 0,

    /// <summary>UC-OZL-003 Adım 9-10: Kayıt onaylandı ve tesis ile ilişkilendirildi.</summary>
    Aktif = 1,

    /// <summary>ÖFB kaydı iptal/pasif edildi.</summary>
    Pasif = 2
}

