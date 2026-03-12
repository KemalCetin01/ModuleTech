using ModuleTech.Application.Handlers.Category.Commands;
using ModuleTech.Application.Handlers.Category.Queries;
using ModuleTech.Core.Base.Api;
using ModuleTech.Core.Base.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ModuleTech.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/category")]
public class CategoryController : BaseApiController
{
    private readonly IRequestBus _requestBus;

    public CategoryController(IRequestBus requestBus)
    {
        _requestBus = requestBus;
    }

    /// <summary>
    /// Kategorileri key-value listesi olarak döndürür
    /// </summary>
    [HttpGet("fkey-list")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetKeyValue(CancellationToken cancellationToken)
        => Ok(await _requestBus.Send(new GetCategoriesKeyValueQuery(), cancellationToken));

    /// <summary>
    /// Kategorileri sayfalı olarak listeler
    /// </summary>
    [HttpPost("search")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get([FromBody] SearchCategoriesQuery searchCategoriesQuery)
        => StatusCode(StatusCodes.Status200OK, (await _requestBus.Send(searchCategoriesQuery)).Data);

    /// <summary>
    /// Kategori detayını döndürür
    /// </summary>
    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(Guid id)
        => Ok(await _requestBus.Send(new GetCategoryDetailsQuery { Id = id }));

    /// <summary>
    /// Yeni kategori oluşturur
    /// </summary>
    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Post([FromBody] CreateCategoryCommand createCategoryCommand)
        => Ok(await _requestBus.Send(createCategoryCommand));

    /// <summary>
    /// Kategori günceller
    /// </summary>
    [HttpPut]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        => Ok(await _requestBus.Send(updateCategoryCommand));

    /// <summary>
    /// Kategori siler
    /// </summary>
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _requestBus.Send(new DeleteCategoryCommand { Id = id });
        return NoContent();
    }
}
