---
name: generate-backend-module
description: Entity adi ve property'ler verildiginde tam CQRS modul yapisini olusturur
tools: Read, Write, Edit, Glob, Grep
---

Kullanicidan entity adi ve property listesi al. Product modulunu sablon olarak kullanarak asagidaki dosyalari olustur.

## Adim 1: Referans Dosyalari Oku
Once su dosyalari oku ve pattern'i anla:
- `src/Core/ModuleTech.Domain/Product.cs`
- `src/Core/ModuleTech.Application/Handlers/Product/Commands/CreateProductCommand.cs`
- `src/Core/ModuleTech.Application/Handlers/Product/Commands/UpdateProductCommand.cs`
- `src/Core/ModuleTech.Application/Handlers/Product/Commands/DeleteProductCommand.cs`
- `src/Core/ModuleTech.Application/Handlers/Product/Queries/GetProductDetailsQuery.cs`
- `src/Core/ModuleTech.Application/Handlers/Product/Queries/SearchProductsQuery.cs`
- `src/Core/ModuleTech.Application/Handlers/Product/Queries/SearchProcutFilter.cs`
- `src/Core/ModuleTech.Application/Handlers/Product/Queries/GetProductsKeyValueQuery.cs`
- `src/Core/ModuleTech.Application/Handlers/Product/DTOs/ProductDTO.cs`
- `src/Core/ModuleTech.Application/Handlers/Product/Commands/UpdateProductCommandValidar.cs`
- `src/Core/ModuleTech.Application/Core/Infrastructure/Services/Product/IProductService.cs`
- `src/Core/ModuleTech.Application/Core/Persistence/Repositories/IProductRepository.cs`
- `src/Infrastructure/ModuleTech.Infrastructure/Services/Product/ProductService.cs`
- `src/Infrastructure/ModuleTech.Persistence/Repositories/ProductRepository.cs`
- `src/Infrastructure/ModuleTech.Persistence/EntityConfigurations/ProductConfigurations.cs`
- `src/Presentation/ModuleTech.API/Controllers/ProductController.cs`

## Adim 2: Dosyalari Olustur
Asagidaki dosyalari olustur (<Entity> yerine verilen entity adini koy):

1. `src/Core/ModuleTech.Domain/<Entity>.cs` - BaseSoftDeleteEntity extend, [QuerySearch] ekle
2. `src/Core/ModuleTech.Domain/EntityFilters/Search<Entity>FilterModel.cs` - IFilterModel implement
3. `src/Core/ModuleTech.Application/Handlers/<Entity>/DTOs/<Entity>DTO.cs` - IResponse implement
4. `src/Core/ModuleTech.Application/Handlers/<Entity>/Commands/Create<Entity>Command.cs` - Command + sealed Handler
5. `src/Core/ModuleTech.Application/Handlers/<Entity>/Commands/Update<Entity>Command.cs` - Command + sealed Handler
6. `src/Core/ModuleTech.Application/Handlers/<Entity>/Commands/Delete<Entity>Command.cs` - Command (void) + sealed Handler
7. `src/Core/ModuleTech.Application/Handlers/<Entity>/Commands/Create<Entity>CommandValidator.cs` - Turkce mesajlar
8. `src/Core/ModuleTech.Application/Handlers/<Entity>/Commands/Update<Entity>CommandValidator.cs` - Turkce mesajlar
9. `src/Core/ModuleTech.Application/Handlers/<Entity>/Queries/Get<Entity>DetailsQuery.cs` - Query + sealed Handler
10. `src/Core/ModuleTech.Application/Handlers/<Entity>/Queries/Search<Entity>Query.cs` - SearchQuery + sealed Handler
11. `src/Core/ModuleTech.Application/Handlers/<Entity>/Queries/Search<Entity>Filter.cs` - IFilter implement
12. `src/Core/ModuleTech.Application/Handlers/<Entity>/Queries/Get<Entity>KeyValueQuery.cs` - Query + sealed Handler
13. `src/Core/ModuleTech.Application/Core/Infrastructure/Services/<Entity>/I<Entity>Service.cs` - IScopedService
14. `src/Core/ModuleTech.Application/Core/Persistence/Repositories/I<Entity>Repository.cs` - IRepository<Entity>
15. `src/Infrastructure/ModuleTech.Infrastructure/Services/<Entity>/<Entity>Service.cs` - IMapper + Repo + UoW + Redis
16. `src/Infrastructure/ModuleTech.Persistence/Repositories/<Entity>Repository.cs` - Repository<Entity, AppDbContext>
17. `src/Infrastructure/ModuleTech.Persistence/EntityConfigurations/<Entity>Configurations.cs` - IEntityTypeConfiguration
18. `src/Presentation/ModuleTech.API/Controllers/<Entity>Controller.cs` - BaseApiController + IRequestBus

## Adim 3: Mevcut Dosyalari Guncelle
19. `AppDbContext.cs` → `DbSet<Entity>` property ekle + `OnModelCreating`'e configuration ekle
20. `MappingProfile.cs` → Entity mapping'lerini ekle (Product pattern'ini takip et)

## Adim 4: Kontrol Listesi
Olusturulan tum dosyalari listele ve eksik olanlari bildir.
