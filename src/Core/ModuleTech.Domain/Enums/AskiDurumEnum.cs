namespace ModuleTech.Domain.Enums;

/// <summary>
/// UC-OZL-005: Belge askıya alma durumları.
/// BR-OZL-005: Askıya alma süresi belirlenmeli ve gerekçe girilmelidir (Şartname 9.5.1.7).
/// </summary>
public enum AskiDurumEnum
{
    /// <summary>UC-OZL-005 Adım 9: Seçilen lisans konuları askıya alındı.</summary>
    Askida = 1,

    /// <summary>UC-OZL-005 Alternatif A1: Askı süresi doldu, otomatik aktifleştirildi.</summary>
    OtomatikKaldirildi = 2,

    /// <summary>UC-OZL-005 Alternatif A2: Personel erken askı kaldırma yaptı.</summary>
    ManuelKaldirildi = 3
}

