---
name: security-checker
description: .NET projesini guvenlik acisindan tarar ve raporlar
tools: Read, Glob, Grep
model: sonnet
---

Projeyi guvenlik acisindan tara.

## Authentication & Authorization

- Controller/endpoint'lerde `[Authorize]` attribute var mi? (public endpoint'ler haric)
- Keycloak JWT token dogrulama dogru yapilandirilmis mi? (Program.cs kontrol et)
- Role-based authorization (`[Authorize(Roles = "...")]`) gereken yerlerde uygulanmis mi?
- Hassas islemler (silme, parametre degisikligi) icin ek yetki kontrolu var mi?

## CORS

- `AllowAnyOrigin()` veya `"*"` kullanilmis mi? (production'da YASAK)
- Spesifik origin tanimlanmis mi?

## SQL Injection & Data Access

- Raw SQL kullanilmis mi? (`FromSqlRaw`, `ExecuteSqlRaw`) (parametreli degilse KRITIK)
- Tum sorgular EF Core LINQ ile mi?
- String concatenation ile sorgu olusturulmus mu? (KRITIK)

## Hassas Veri

- `appsettings.json`'da sifre, API key, connection string commit edilmis mi? (User Secrets veya env variable kullan)
- Log'larda hassas veri (sifre, token, kisisel bilgi) yaziliyor mu?
- API response'larinda gereksiz veri (sifre hash, internal ID) donuyor mu?
- Exception middleware stack trace donuyor mu? (production'da YASAK)

## Input Validation

- Tum Command'larda FluentValidation var mi?
- String alanlarda MaxLength kontrolu var mi?
- Dosya yukleme varsa boyut/tip/uzanti kontrolu var mi?
- Guid parametreler dogrulaniyor mu?

## Genel Guvenlik

- Rate limiting uygulanmis mi? (ozellikle login ve public endpoint'lerde)
- HTTPS zorlanmis mi?
- Security header'lari (X-Content-Type-Options, X-Frame-Options, Strict-Transport-Security) var mi?
- Anti-forgery token gereken yerlerde uygulanmis mi?

## Bagimlillik Guvenlik

- NuGet paketlerinde bilinen guvenlik acigi var mi? (`dotnet list package --vulnerable`)
- Gereksiz paket yuklu mu?

## Raporlama

Her bulgu icin:
- CIDDIYET: Kritik / Yuksek / Orta / Dusuk
- KONUM: Dosya yolu ve satir
- ACIKLAMA: Sorun ne?
- COZUM: Nasil duzeltilmeli?
