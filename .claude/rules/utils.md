---
paths:
  - "src/Core/ModuleTech.Core.Base/Extentions/**"
  - "src/Core/ModuleTech.Core.Base/Handlers/Search/**"
  - "src/Core/ModuleTech.Core.Base/Models/**"
  - "src/Core/ModuleTech.Core.Caching/**"
  - "src/Core/ModuleTech.Core.Logging/**"
  - "src/Core/ModuleTech.Core.Networking/**"
---

# Utility ve Extension Kurallari

- Extension method'lar `static class` icinde `static` method olarak tanimlanmali
- Ilk parametre `this` keyword'u ile extend edilen tip olmali
- Pure function olsun (side effect yok, dis state degistirme)
- Parametre ve donus tipleri acikca yazilmali, `object` veya `dynamic` YASAK
- `Console.WriteLine` YASAK, loglama icin `Serilog` kullan
- Null kontrolu icin null-conditional (`?.`) ve null-coalescing (`??`) operatorleri tercih et
- Extension class adi `<Tip>Extensions` convention'ina uymali (ornek: `StringExtensions`, `QueryExtensions`)
- Caching islemlerinde TTL (expiration) belirtmeyi UNUTMA
- HttpClient kullanirken `IHttpClientFactory` pattern'i kullan, dogrudan `new HttpClient()` YASAK
