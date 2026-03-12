using ModuleTech.Application.Core.Infrastructure.Services.Category;
using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Application.Core.Persistence.UoW;
using ModuleTech.Application.DTOs.Category.Response;
using ModuleTech.Application.Handlers.Category.Commands;
using ModuleTech.Application.Handlers.Category.DTOs;
using ModuleTech.Core.Base.Dtos.Response;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Core.Caching.Interface;
using ModuleTech.Domain.EntityFilters;
using ModuleTech.Application.Exceptions;
using ModuleTech.Core.ExceptionHandling.Exceptions;
using AutoMapper;

namespace ModuleTech.Infrastructure.Services.Category;

public class CategoryService : ICategoryService
{
    public readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IModuleTechUnitOfWork _moduleTechUnitOfWork;
    private readonly IRedisCacheService _redisCacheService;

    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository, IModuleTechUnitOfWork moduleTechUnitOfWork, IRedisCacheService redisCacheService)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
        _moduleTechUnitOfWork = moduleTechUnitOfWork;
        _redisCacheService = redisCacheService;
    }

    public async Task<CategoryDTO> AddAsync(CreateCategoryCommand createCategoryCommand, CancellationToken cancellationToken)
    {
        await CategoryConflictControl(createCategoryCommand.Name, null, cancellationToken);

        var category = new ModuleTech.Domain.Category
        {
            Name = createCategoryCommand.Name,
            Description = createCategoryCommand.Description
        };

        await _categoryRepository.AddAsync(category, cancellationToken);
        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        var categoryDto = _mapper.Map<CategoryDTO>(category);

        var cacheKey = $"category:{category.Id}";
        var expireTime = TimeSpan.FromDays(14);
        await _redisCacheService.SetAsAsync(cacheKey, categoryDto, expireTime, cancellationToken);

        return categoryDto;
    }

    public async Task<PagedResponse<CategoryDTO>> SearchAsync(SearchQueryModel<SearchCategoryFilterModel> searchQuery, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.SearchAsync(searchQuery, cancellationToken);
        return _mapper.Map<PagedResponse<CategoryDTO>>(categories);
    }

    public async Task<GetAllCategoriesResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _redisCacheService.GetAsAsync<CategoryDTO>($"category:{id}");

        if (result == null)
        {
            var entity = await _categoryRepository.GetById(id, cancellationToken);
            var categoryDto = _mapper.Map<CategoryDTO>(entity);

            var cacheKey = $"category:{id}";
            var expireTime = TimeSpan.FromDays(14);
            await _redisCacheService.SetAsAsync(cacheKey, categoryDto, expireTime, cancellationToken);

            return _mapper.Map<GetAllCategoriesResponseDto>(categoryDto);
        }

        return _mapper.Map<GetAllCategoriesResponseDto>(result);
    }

    public async Task<CategoryDTO> UpdateAsync(UpdateCategoryCommand updateCategoryCommand, CancellationToken cancellationToken)
    {
        await CategoryConflictControl(updateCategoryCommand.Name, updateCategoryCommand.Id, cancellationToken);

        var category = await _categoryRepository.GetById(updateCategoryCommand.Id, cancellationToken);

        if (category == null)
            throw new ResourceNotFoundException(UserStatusCodes.CategoryNotFound.Message, UserStatusCodes.CategoryNotFound.StatusCode);

        category.Name = updateCategoryCommand.Name;
        category.Description = updateCategoryCommand.Description;

        _categoryRepository.Update(category);
        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        await _redisCacheService.RemoveAsync($"category:{updateCategoryCommand.Id}", cancellationToken);

        var cacheKey = $"category:{updateCategoryCommand.Id}";
        var expireTime = TimeSpan.FromDays(14);
        await _redisCacheService.SetAsAsync(cacheKey, category, expireTime, cancellationToken);

        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetById(id, cancellationToken);

        if (category == null)
            throw new ValidationException(UserStatusCodes.CategoryNotFound.Message, UserStatusCodes.CategoryNotFound.StatusCode);

        category.IsDeleted = true;
        _categoryRepository.Update(category);
        await _moduleTechUnitOfWork.CommitAsync(cancellationToken);

        await _redisCacheService.RemoveAsync($"category:{id}", cancellationToken);
    }

    public async Task<List<LabelValueResponse>> GetKeyValueAsync(CancellationToken cancellationToken)
        => await _categoryRepository.GetKeyValueAsync(cancellationToken);

    private async Task<bool> CategoryConflictControl(string name, Guid? id, CancellationToken cancellationToken)
    {
        var isCategoryExists = await _categoryRepository.HasCategoryExists(name, id, cancellationToken);
        if (isCategoryExists)
            throw new ConflictException("Eklemeye/güncellemeye çalıştığınız kategori '" + name + "' bazında zaten mevcut");
        return true;
    }
}
