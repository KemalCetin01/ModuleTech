using ModuleTech.Application.DTOs.Product.Response;
using ModuleTech.Application.Handlers.Product.Commands;
using ModuleTech.Application.Handlers.Product.DTOs;
using ModuleTech.Core.Base.IoC;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Infrastructure.Services.Product;
public interface IProductService : IScopedService
{
    Task<PagedResponse<ProductDTO>> SearchAsync(SearchQueryModel<SearchProductFilterModel> searchQuery, CancellationToken cancellationToken);
    Task<GetAllProductsResponseDto?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<ProductDTO> AddAsync(CreateProductCommand createProductCommand, CancellationToken cancellationToken);
    Task<ProductDTO> UpdateAsync(UpdateProductCommand updateProductCommand, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
