using ModuleTech.Application.Handlers.Product.Commands;
using ModuleTech.Application.Handlers.Product.Queries;
using ModuleTech.Core.Base.Api;
using ModuleTech.Core.Base.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ModuleTech.API.Controllers;

[ApiVersion("1.0")]
[Authorize]
[Route("api/v{version:apiVersion}/category")]
public class CategoryController : BaseApiController
{
    private readonly IRequestBus _requestBus;

    public CategoryController(IRequestBus requestBus)
    {
        _requestBus = requestBus;
    }


    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Post([FromBody] CreateProductCommand createSectorCommand) =>
         Ok(await _requestBus.Send(createSectorCommand));

    [HttpPut]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
       => Ok(await _requestBus.Send(updateProductCommand));

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _requestBus.Send(new DeleteProductCommand() { id = id });
        return NoContent();
    }

}
