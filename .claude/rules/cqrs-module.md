---
paths:
  - "src/Core/ModuleTech.Application/Handlers/**"
  - "src/Core/ModuleTech.Application/Core/Infrastructure/Services/**"
  - "src/Core/ModuleTech.Application/Core/Persistence/Repositories/**"
---

# CQRS Modül Kuralları

## Handler Klasör Yapısı
Her entity için şu yapıyı takip et:
```
Handlers/<Entity>/
  Commands/
    Create<Entity>Command.cs       # ICommand<EntityDTO> + sealed handler
    Update<Entity>Command.cs       # ICommand<EntityDTO> + sealed handler
    Delete<Entity>Command.cs       # ICommand (void) + sealed handler
    Create<Entity>CommandValidator.cs  # AbstractValidator<CreateCommand>
    Update<Entity>CommandValidator.cs  # AbstractValidator<UpdateCommand>
  Queries/
    Get<Entity>DetailsQuery.cs     # IQuery<EntityDTO> + sealed handler
    Search<Entity>Query.cs         # SearchQuery<Filter, PagedResponse<DTO>> + sealed handler
    Search<Entity>Filter.cs        # IFilter implementation
    Get<Entity>KeyValueQuery.cs    # IQuery<ListResponse<LabelValueResponse>> + sealed handler
  DTOs/
    <Entity>DTO.cs                 # IResponse implementation
```

## Command Kuralları
- Create/Update → `ICommand<EntityDTO>` (response ile)
- Delete → `ICommand` (void, response yok)
- Handler sınıfı `sealed`, Command class ile AYNI DOSYADA
- Handler sadece service çağırır, business logic KOYMAZ
- Namespace: `ModuleTech.Application.Handlers.<Entity>.Commands`

## Query Kuralları
- GetDetails → `IQuery<EntityDTO>`
- Search → `SearchQuery<SearchFilter, PagedResponse<EntityDTO>>` extend eder
- KeyValue → `IQuery<ListResponse<LabelValueResponse>>`
- Handler sınıfı `sealed`, Query class ile AYNI DOSYADA
- Namespace: `ModuleTech.Application.Handlers.<Entity>.Queries`

## Validation Kuralları
- Her Command için `AbstractValidator<T>` ZORUNLU
- Hata mesajları TÜRKÇE yazılmalı
- Dosya adı: `<Command>Validator.cs`

## DTO Kuralları
- `IResponse` interface'ini implement et
- Domain entity'yi API'ye doğrudan DÖNME, her zaman DTO kullan

## Service Interface
- Konum: `Application/Core/Infrastructure/Services/<Entity>/I<Entity>Service.cs`
- `IScopedService` extend et
- Standart metodlar: SearchAsync, GetByIdAsync, AddAsync, UpdateAsync, DeleteAsync, GetKeyValueAsync

## Repository Interface
- Konum: `Application/Core/Persistence/Repositories/I<Entity>Repository.cs`
- `IRepository<Entity>` extend et
- Standart metodlar: SearchAsync, Has<Entity>Exists, GetKeyValueAsync

## Referans
Product modülünü şablon olarak kullan (bkz. CLAUDE.md)
