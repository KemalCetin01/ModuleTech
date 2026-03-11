# e-İzin Projesi

Çevre İzin/Lisans sistemi - 13 modül, 81 use case.

## Tech Stack
- Backend: .NET 9.0, Clean Architecture, CQRS + MediatR
- ORM: Entity Framework Core 9 + PostgreSQL (snake_case naming)
- Cache: Redis (IRedisCacheService)
- Auth: Keycloak SSO (JWT Bearer)
- Validation: FluentValidation (MediatR pipeline)
- Mapping: AutoMapper (tek MappingProfile.cs)
- Logging: Serilog

## Mimari Katmanlar
```
Presentation (API) → Application (Handlers/DTOs/Services) → Domain (Entities)
                                                           ↑
                      Infrastructure (Services impl) ──────┘
                      Persistence (Repositories/EF Core) ──┘
```

## Modül Kodları
SYS, KUL, CG, BSV, DEG, YEN, MUA, IPT, OZL, BLG, RPR, ENT, BLD

## Dil Kuralı
- Kod (class, property, method): İngilizce
- UI mesajları, validation mesajları: Türkçe
- Yorumlar: Türkçe tercih

## Temel Komutlar
- Build: `dotnet build ModuleTech.sln`
- Run: `dotnet run --project src/Presentation/ModuleTech.API`
- Migration oluştur: `dotnet ef migrations add <Name> --project src/Infrastructure/ModuleTech.Persistence --startup-project src/Presentation/ModuleTech.API`
- Migration uygula: `dotnet ef database update --project src/Infrastructure/ModuleTech.Persistence --startup-project src/Presentation/ModuleTech.API`
- Test: `dotnet test`

## CQRS Pattern
- Write işlemleri: `ICommand<TResponse>` veya `ICommand` (void)
- Read işlemleri: `IQuery<TResponse>`
- Handler'lar: `BaseCommandHandler<T,R>` veya `BaseQueryHandler<T,R>` extend eder, `sealed` olmalı
- Search: `SearchQuery<TFilter, PagedResponse<TDto>>` extend eder
- Validation: Her Command için `AbstractValidator<T>` zorunlu

## Response Wrappers
- Tekil: DTO doğrudan döner (DataResponse deprecated)
- Liste: `ListResponse<T>`
- Sayfalama: `PagedResponse<T>`
- Key-Value: `ListResponse<LabelValueResponse>`

## DI Convention
- Scoped: `IScopedService` implement et
- Transient: `ITransientService` implement et
- Auto-registration marker interface ile çalışır

## Referans Şablon
Yeni modül oluştururken Product modülünü referans al:
- Entity: `src/Core/ModuleTech.Domain/Product.cs`
- Handlers: `src/Core/ModuleTech.Application/Handlers/Product/`
- Service: `src/Infrastructure/ModuleTech.Infrastructure/Services/Product/`
- Repository: `src/Infrastructure/ModuleTech.Persistence/Repositories/ProductRepository.cs`
- Controller: `src/Presentation/ModuleTech.API/Controllers/ProductController.cs`
