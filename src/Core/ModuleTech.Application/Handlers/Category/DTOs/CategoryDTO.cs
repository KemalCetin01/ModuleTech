using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Category.DTOs;

public class CategoryDTO : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
