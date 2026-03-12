---
paths:
  - "src/Infrastructure/ModuleTech.Persistence/**"
  - "src/Core/ModuleTech.Domain/**"
---

# Veritabanı ve Migration Kuralları

## Entity Oluşturma
- Uygun base class seç:
  - `BaseSoftDeleteEntity` → çoğu iş entity'si (Id, audit fields, soft delete)
  - `BaseAuditableGuidEntity` → audit gereken ama soft delete olmayan
  - `BaseGuidEntity` → sadece GUID Id
  - `BaseIntEntity` → integer Id
- Aranabilir string property'lere `[QuerySearch]` attribute ekle
- Entity namespace: `ModuleTech.Domain`
- Filter model namespace: `ModuleTech.Domain.EntityFilters`
- Filter model `IFilterModel` implement etmeli

## Entity Configuration
- `IEntityTypeConfiguration<TEntity>` implement et
- Konum: `Persistence/EntityConfigurations/<Entity>Configurations.cs`
- `builder.ToTable(nameof(Entity))` kullan (snake_case global olarak uygulanır)
- İlişkileri Fluent API ile yapılandır, Data Annotation KULLANMA
- Namespace: `ModuleTech.Persistence.EntityConfigurations`

## AppDbContext Kayıt
- `DbSet<Entity>` property ekle
- `OnModelCreating` içinde `modelBuilder.ApplyConfiguration(new EntityConfigurations())` ekle
- `modelBuilder.UseSnakeCaseNaming()` satırından ÖNCE ekle

## Migration Kuralları
- Migration komutu: `dotnet ef migrations add <Name> --project src/Infrastructure/ModuleTech.Persistence --startup-project src/Presentation/ModuleTech.API`
- Mevcut migration dosyalarını ASLA değiştirme, her zaman yeni migration oluştur
- Migration adı açıklayıcı olmalı: `Add<Entity>Table`, `Add<Column>To<Entity>`
- Rollback: `dotnet ef migrations remove --project src/Infrastructure/ModuleTech.Persistence --startup-project src/Presentation/ModuleTech.API`

## Genel Kurallar
- İş entity'lerinde hard delete YASAK, `IsDeleted = true` kullan
- Sorgulamalarda `!x.IsDeleted` filtresi UNUTMA
- PostgreSQL snake_case: `UseSnakeCaseNaming()` global olarak uygulanır, manuel snake_case YAPMA
