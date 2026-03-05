namespace ModuleTech.Domain.Enums;

/// <summary>
/// UC-OZL-001 Adım 2: Görüş talebi türleri.
/// BR-OZL-001: Görüş talepleri Bakanlık tarafından değerlendirilir (Şartname 9.5.9.2).
/// </summary>
public enum GorusTalebiTipiEnum
{
    /// <summary>UC-OZL-001 Adım 2a: İzin/Lisans belgesine ilişkin görüş.</summary>
    IzinLisansBelgesiGorusu = 1,

    /// <summary>UC-OZL-001 Adım 2b: Belge yenileme gerekliliğine ilişkin görüş.</summary>
    BelgeYenilemeGorusu = 2
}

