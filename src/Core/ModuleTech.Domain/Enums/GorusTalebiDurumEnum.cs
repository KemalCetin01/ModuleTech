namespace ModuleTech.Domain.Enums;

/// <summary>
/// UC-OZL-001/002: Görüş talebi yaşam döngüsü durumları.
/// </summary>
public enum GorusTalebiDurumEnum
{
    /// <summary>UC-OZL-001 Adım 4: Form doldurulmaya başlandı, henüz gönderilmedi.</summary>
    Taslak = 0,

    /// <summary>UC-OZL-001 Adım 8: e-İmza ile gönderildi, Bakanlık'a yönlendirildi.</summary>
    Gonderildi = 1,

    /// <summary>UC-OZL-002 Adım 3: Bakanlık personeli incelemeye başladı.</summary>
    Incelemede = 2,

    /// <summary>UC-OZL-002 Adım 6: Görüş yazısı imza akışında.</summary>
    ImzaAkisinda = 3,

    /// <summary>UC-OZL-002 Alternatif 7a: Şube Müdürü düzeltme istedi, personele iade edildi.</summary>
    DuzeltmeIstendi = 4,

    /// <summary>UC-OZL-002 Adım 7-8: Onaylanıp e-imzalanarak yanıtlandı.</summary>
    Yanitlandi = 5
}

