---
paths:
  - "src/Core/ModuleTech.Core.Base/**"
---

# Paylasilan Core Base Kurallari

## Base Entity
- Yeni entity olusturulurken uygun base class sec: `BaseGuidEntity`, `BaseSoftDeleteEntity`, `BaseAuditableGuidEntity`
- Soft delete gereken entity'ler `BaseSoftDeleteEntity`'den turemeli
- Audit gereken entity'ler `IAuditableEntity` implement etmeli
- Entity'ye dogrudan business logic KOYMA, Application katmaninda handle et

## Repository & UnitOfWork
- `IRepository<TEntity>` interface'ini kullan, dogrudan DbContext'e erisme
- Transaction gereken islemlerde `IUnitOfWork.SaveChangesAsync()` kullan
- Ozel sorgular icin domain-specific repository interface olustur (ornek: `IProductRepository`)

## Handler (CQRS)
- Write islemleri icin `ICommand<TResponse>` kullan
- Read islemleri icin `IQuery<TResponse>` kullan
- Handler'lar `BaseCommandHandler` veya `BaseQueryHandler`'dan turemeli
- Handler'da dogrudan DbContext kullanma, service veya repository kullan

## Response Wrapper
- Tekil veri: `DataResponse<T>` kullan
- Liste: `ListResponse<T>` kullan
- Sayfalamali liste: `PagedResponse<T>` kullan
- Hata: `ErrorResponse` kullan

## IoC / Dependency Injection
- Scoped servisler `IScopedService` implement etmeli
- Transient servisler `ITransientService` implement etmeli
- Manuel registration yerine marker interface ile auto-registration tercih et

## Extension Method
- Extension method'lar `Extentions` klasorunde olmali
- IQueryable extension'lari `QueryExtensions`'a ekle
- String helper'lar `StringExtensions`'a ekle
