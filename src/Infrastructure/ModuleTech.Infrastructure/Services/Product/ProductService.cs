using ModuleTech.Application.Core.Infrastructure.Services.Product;
using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Application.Core.Persistence.UoW;
using ModuleTech.Application.DTOs.Product.Response;
using ModuleTech.Application.Handlers.Product.Commands;
using ModuleTech.Application.Handlers.Product.DTOs;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Core.Caching.Interface;
using ModuleTech.Domain.EntityFilters;
using ModuleTech.Application.Exceptions;
using ModuleTech.Core.ExceptionHandling.Exceptions;
using AutoMapper;

namespace ModuleTech.Infrastructure.Services.Product;
public class ProductService : IProductService
{
    public readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IModuleTechUnitOfWork _moduleTechUnitOfWork;
    private readonly IRedisCacheService _redisCacheService;
    public ProductService(IMapper mapper, IProductRepository productRepository, IModuleTechUnitOfWork moduleTechUnitOfWork, IRedisCacheService redisCacheService)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _moduleTechUnitOfWork = moduleTechUnitOfWork;
        _redisCacheService = redisCacheService;
    }
    public async Task<ProductDTO> AddAsync(CreateProductCommand createProductCommand, CancellationToken cancellationToken)
    {
        await ProductConflictControl(createProductCommand.Name, null, cancellationToken);

        var product = new ModuleTech.Domain.Product() { Name = createProductCommand.Name, Url = createProductCommand.Url };

        await _productRepository.AddAsync(product, cancellationToken);
        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        var productDto = _mapper.Map<ProductDTO>(product);

        var cacheKey = $"product:{product.Id}";
        var expireTime = TimeSpan.FromDays(14); // Cache süresi 
        await _redisCacheService.SetAsAsync(cacheKey, productDto, expireTime, cancellationToken);


        return productDto;
    }

    public async Task<PagedResponse<ProductDTO>> SearchAsync(SearchQueryModel<SearchProductFilterModel> searchQuery, CancellationToken cancellationToken)
    {
        var products = await _productRepository.SearchAsync(searchQuery, cancellationToken);

        return _mapper.Map<PagedResponse<ProductDTO>>(products);
    }

    public async Task<GetAllProductsResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {

        var result = await _redisCacheService.GetAsAsync<ProductDTO>($"productTest:{id}");

        if (result == null)
        {
            var result2 = await _productRepository.GetById(id, cancellationToken);
            var resultProductDto = _mapper.Map<ProductDTO>(result2);

            var cacheKey = $"productTest:{id}";
            var expireTime = TimeSpan.FromDays(14); // Cache süresi 
            await _redisCacheService.SetAsAsync(cacheKey, resultProductDto, expireTime, cancellationToken);

            return _mapper.Map<GetAllProductsResponseDto>(resultProductDto);

        }

        return _mapper.Map<GetAllProductsResponseDto>(result);
    }


    public async Task<ProductDTO> UpdateAsync(UpdateProductCommand updateProductCommand, CancellationToken cancellationToken)
    {
        await ProductConflictControl(updateProductCommand.name,updateProductCommand.id,cancellationToken);

        var result = await _redisCacheService.GetAsAsync<Domain.Product>($"product:{updateProductCommand.id}");
        var product = new Domain.Product() { };
        if (result == null)
        {
            product = await _productRepository.GetById(updateProductCommand.id, cancellationToken);

            if (product == null)
                throw new ResourceNotFoundException(UserStatusCodes.ProductNotFound.Message, UserStatusCodes.ProductNotFound.StatusCode);


            product.Name = updateProductCommand.name;
            product.Url = updateProductCommand.url;

        }
        else
        {
            result.Name = updateProductCommand.name;
            result.Url = updateProductCommand.url;


        }

        _productRepository.Update(result);
        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        await _redisCacheService.RemoveAsync($"productTest:{updateProductCommand.id}", cancellationToken);

        var cacheKey = $"productTest:{updateProductCommand.id}";
        var expireTime = TimeSpan.FromDays(14); // Cache süresi 
        await _redisCacheService.SetAsAsync(cacheKey, result, expireTime, cancellationToken);
        return _mapper.Map<ProductDTO>(product);
    }


    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var product=await _productRepository.GetById(id, cancellationToken);
        if(product == null)
            throw new ValidationException(UserStatusCodes.ProductNotFound.Message,UserStatusCodes.ProductNotFound.StatusCode);
        product.IsDeleted = true;
        _productRepository.Update(product);
        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        await _redisCacheService.RemoveAsync($"productTest:{id}", cancellationToken);
    }

    private async Task<bool> ProductConflictControl(string name, Guid? id, CancellationToken cancellationToken)
    {
        var isProductExists = await _productRepository.HasProductExits(name, id, cancellationToken);
        if (isProductExists)
         throw new ConflictException("Eklemeye/güncellemeye çalıştığınız ürün '" + name + "' bazında zaten mevcut");
        return true;
    }

}

