# 🚀 ModuleTech – .NET 9 Web API Clean Architecture

## 🧪 Proje Hakkında

Bu proje, **.NET 9.0 Web API** teknolojisi kullanılarak geliştirilmiş, modern yazılım mimarisi prensipleriyle yapılandırılmış bir **Clean Architecture** örneğidir.  
> **Not:** Aynı zamanda şimdiye kadar edindiğim tüm teknolojik tecrübeleri bir araya getirerek oluşturduğum kapsamlı bir .NET test uygulamasıdır.


## 🔧 Kullanılan Teknolojiler ve Araçlar

| Katman | Açıklama |
|-------|----------|
| **.NET 9.0** | Web API projesi olarak geliştirildi. |
| **Keycloak (SSO)** | Authorization ve Authentication işlemleri için Keycloak ile tek oturum (SSO) yönetimi entegre edildi. |
| **PostgreSQL** | Veritabanı olarak kullanıldı. |
| **Redis** | Caching işlemleri için tercih edildi. |
| **Serilog** | Loglama işlemleri için kullanıldı. |
| **FluentValidation** | Gelişmiş validation işlemleri için kullanıldı. |
| **AutoMapper** | Nesne dönüşümleri için kullanıldı. |
| **CQRS + MediatR** | Komut ve sorgu işlemlerinin ayrıştırılması sağlandı. |
| **Generic Repository & Unit of Work** | Veri erişimi katmanında soyutlama ve yönetilebilirlik sağlandı. |

## 🧱 Katmanlı Mimari (Clean Architecture)

Proje aşağıdaki ana katmanlara ayrılmıştır:

- **Presentation**: API uç noktalarının bulunduğu dış katman.
- **Application**: İş kurallarının ve use-case’lerin tanımlandığı katman.
- **Infrastructure**: Servisler, dış servis entegrasyonları ve altyapı bileşenleri.
- **Persistence**: Veritabanı işlemleri ve Entity yapılarını içerir.
- **Domain**: Entityler, iş modelleri ve domain kuralları.

## 📦 Base ve Ortak Yapılar

Yaygın ihtiyaçlara yönelik olarak aşağıdaki **generic ve reusable** yapılar oluşturulmuştur:

- **Base Project**: Temel sınıflar, interface'ler, filtreler vb.
- **Caching**: Redis destekli cache altyapısı.
- **Exception Handling**: Global exception yönetimi.
- **Logging**: Serilog ile merkezi loglama mekanizması.
- **Networking**: API dış servis iletişimi için ortak HTTP istemcileri.

## 🧠 Mimaride Hedeflenen Avantajlar

- **SOLID prensiplerine** uygun kod yapısı
- **Test edilebilirlik** ve bağımlılıkların azaltılması
- **Performans** ve **ölçeklenebilirlik** için cache ve logging altyapısı
- **Ayrıştırılmış sorumluluklar** ve net sınırlar
- **Kolay genişletilebilir** ve sürdürülebilir mimari

## 📂 Proje Klasör Yapısı

```text
├── src                          # Ana kaynak kod dizini
│   ├── Presentation             # Uygulamanın dışa açılan katmanı (Controller'lar, API Endpoint'leri)
│   │   └── API                  # Web API projesi (Startup, Middlewares vs.)
|   ├── Core 
│   |  └── Application          # Use-case'ler, CQRS, DTO'lar, servis arayüzleri
│   |  └──  Base                # Taban sınıflar, arayüzler, Result yapısı, filtreler
│   |  └──  Caching             # Redis ve Cache altyapısı
│   |  └──  ExceptionHandling   # Global hata yönetimi ve middleware'lar
│   |  └──  Logging             # Serilog tabanlı loglama altyapısı
│   |  └──  Networking          # HTTP client altyapısı, dış servis istekleri
│   |  └── Domain               # Entity ve Domain modelleri (iş kuralları)
│   ├── Infrastructure          # E-posta, dosya sistemi, dış servis gibi altyapı bağımlılıkları
│   ├── Persistence             # Veritabanı işlemleri (Repositories, DbContext, Configurations)
    
