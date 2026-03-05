namespace ModuleTech.Domain.Enums;

/// <summary>
/// UC-OZL-005 Adım 7: Askı süresi dolduğunda uygulanacak işlem tercihi.
/// </summary>
public enum AskiBitisIslemEnum
{
    /// <summary>UC-OZL-005 Adım 7 / Alternatif A1: Süre dolunca otomatik aktifleştirme.</summary>
    OtomatikAktiflestirme = 1,

    /// <summary>UC-OZL-005 Adım 7 / Alternatif A1.3: Süre dolunca personele bildirim, manuel onay beklenir.</summary>
    ManuelOnay = 2
}

