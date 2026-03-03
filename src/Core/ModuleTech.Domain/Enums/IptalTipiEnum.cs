namespace ModuleTech.Domain.Enums;

/// <summary>
/// UC-IPT-001..006: İptal işlem tipi — hangi iptal senaryosu olduğunu belirler.
/// </summary>
public enum IptalTipiEnum
{
    GfbSureAsimi = 1,
    EksiklikSureAsimi = 2,
    BasvuruRed = 3,
    UygunlukYapilmadi = 4,
    AykirilikTespiti = 5,
    UygunsuzlukGiderilmedi = 6,
    ManuelIptal = 7,
    FaaliyetSonlandirma = 8
}

