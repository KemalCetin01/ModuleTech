using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Product.DTOs;
public class ProductDTO : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
}

