using ModuleTech.Application.Handlers.Product.Commands;
using ModuleTech.Application.Handlers.Product.Queries;
using ModuleTech.Core.Base.Api;
using ModuleTech.Core.Base.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ModuleTech.API.Controllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/product")]
public class ProductController : BaseApiController
{
    private readonly IRequestBus _requestBus;

    public ProductController(IRequestBus requestBus)
    {
        _requestBus = requestBus;
    }


    /// <summary>
    /// returns all products
    /// </summary>
    [HttpPost("search")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get([FromBody] SearchProductsQuery searchProductsQuery)
    {
        return StatusCode(StatusCodes.Status200OK, (await _requestBus.Send(searchProductsQuery)).Data);
    }


    /// <summary>
    /// returns details
    /// </summary>
    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _requestBus.Send(new GetProductDetailsQuery() { Id = id }));
    }


    /// <remarks>
    /// Note: Name must be unique. 
    /// 
    ///  
    ///     POST /product
    ///     {
    ///     "name": "test",
    ///     "url": "www.urlimg.com/5478"
    ///     }
    ///     
    /// </remarks>
    /// <summary>
    /// creates sector
    /// </summary>
    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Post([FromBody] CreateProductCommand createSectorCommand) =>
             Ok(await _requestBus.Send(createSectorCommand));

    /// <remarks>
    /// update product
    /// 
    ///     PUT /Sectors
    ///       {
    ///         "id": "eabec798-136e-44bf-8a8f-3d5838e89e64",
    ///         "name": "test",
    ///         "url": "sd"
    ///       }
    /// </remarks>
    /// <summary>
    /// update sector
    /// </summary>
    [HttpPut]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
       => Ok(await _requestBus.Send(updateProductCommand));

    /// <summary>
    /// delete sector by id
    /// </summary>
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _requestBus.Send(new DeleteProductCommand() { id = id });
        return NoContent();
    }
}
