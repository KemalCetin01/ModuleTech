---
paths:
  - "src/Presentation/ModuleTech.API/Controllers/**"
---

# API Tasarım Kuralları

## Controller Yapısı
- `BaseApiController` extend et
- `[ApiVersion("1.0")]` attribute zorunlu
- `[Route("api/v{version:apiVersion}/resource-name")]` (kebab-case, tekil)
- Sadece `IRequestBus` inject et, başka servis/repository INJECT ETME
- Business logic controller'da YASAK, tamamı handler/service'te olmalı

## HTTP Endpoint Kalıpları
| İşlem | HTTP Method | Route | Dönüş |
|-------|------------|-------|-------|
| Arama | `[HttpPost("search")]` | POST /search | `StatusCode(200, result.Data)` |
| Detay | `[HttpGet("{id}")]` | GET /{id} | `Ok(result)` |
| Oluştur | `[HttpPost]` | POST / | `Ok(result)` |
| Güncelle | `[HttpPut]` | PUT / | `Ok(result)` |
| Sil | `[HttpDelete("{id}")]` | DELETE /{id} | `NoContent()` |
| Key-Value | `[HttpGet("fkey-list")]` | GET /fkey-list | `Ok(result)` |

## Endpoint İmza Örnekleri
```csharp
[HttpPost("search")]
[MapToApiVersion("1.0")]
public async Task<IActionResult> Get([FromBody] SearchEntityQuery query)
    => StatusCode(StatusCodes.Status200OK, (await _requestBus.Send(query)).Data);

[HttpGet("{id}")]
[MapToApiVersion("1.0")]
public async Task<IActionResult> Get(Guid id)
    => Ok(await _requestBus.Send(new GetEntityDetailsQuery { Id = id }));

[HttpPost]
[MapToApiVersion("1.0")]
public async Task<IActionResult> Post([FromBody] CreateEntityCommand command)
    => Ok(await _requestBus.Send(command));

[HttpPut]
[MapToApiVersion("1.0")]
public async Task<IActionResult> Update([FromBody] UpdateEntityCommand command)
    => Ok(await _requestBus.Send(command));

[HttpDelete("{id}")]
[MapToApiVersion("1.0")]
public async Task<IActionResult> Delete(Guid id)
{
    await _requestBus.Send(new DeleteEntityCommand { id = id });
    return NoContent();
}

[HttpGet("fkey-list")]
[MapToApiVersion("1.0")]
public async Task<IActionResult> GetKeyValue(CancellationToken cancellationToken)
    => Ok(await _requestBus.Send(new GetEntityKeyValueQuery(), cancellationToken));
```

## Genel Kurallar
- Her endpoint'e `[MapToApiVersion("1.0")]` ekle
- XML doc comment ekle (Türkçe açıklama)
- `CancellationToken` parametresini mümkünse kullan
- Controller namespace: `ModuleTech.API.Controllers`
