---
name: create-migration
description: EF Core migration olusturur ve dogrular
tools: Read, Write, Edit, Bash, Glob, Grep
---

## Adim 1: On Kontrol
- `AppDbContext.cs` dosyasini oku
- Yeni entity icin `DbSet<Entity>` tanimli mi kontrol et
- `OnModelCreating` icinde `ApplyConfiguration` ekli mi kontrol et
- Eksikse kullaniciya bildir ve ekle

## Adim 2: Migration Olustur
```bash
dotnet ef migrations add <MigrationName> --project src/Infrastructure/ModuleTech.Persistence --startup-project src/Presentation/ModuleTech.API
```
- Migration adi: `Add<Entity>Table` veya `Add<Column>To<Entity>`

## Adim 3: Migration Dogrula
- Olusturulan migration dosyasini oku
- Tablo ve kolon adlarinin snake_case oldugunu dogrula
- Potential data loss uyarisi var mi kontrol et
- Foreign key ve index tanimlarini kontrol et

## Adim 4: Bilgi Ver
Kullaniciya su komutlari bildir:
- Uygula: `dotnet ef database update --project src/Infrastructure/ModuleTech.Persistence --startup-project src/Presentation/ModuleTech.API`
- Geri al: `dotnet ef migrations remove --project src/Infrastructure/ModuleTech.Persistence --startup-project src/Presentation/ModuleTech.API`
