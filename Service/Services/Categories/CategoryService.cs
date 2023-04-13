using AutoMapper;
using Contracts.Base;
using Contracts.Logger;
using Entities.Categories;
using Entities.Exceptions;
using Service.Contracts.Categories;
using Shared.DataTransferObjects.Categories;

namespace Services.Categories
{
    internal sealed class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repositoryManager,
            ILoggerManager loggerManager,
            IMapper mapper)
        {
            this._repository = repositoryManager;
            this._logger = loggerManager;
            this._mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _repository.Category.CreateCategory(categoryEntity);
            await _repository.SaveAsync();
            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
        {
 
            var categories = await _repository.Category.GetAllCategoriesAsync(trackChanges);
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null)
                throw new IdParametersBadRequestException();

            var categoriesEntity = await _repository.Category.GetCategoryByIdsAsync(ids, trackChanges);
            if (categoriesEntity.Count() != ids.Count())
                throw new CollectionByIdsBadRequestException();
            return _mapper.Map<IEnumerable< CategoryDto>>(categoriesEntity);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id, bool trackChanges)
        {
            var category = await _repository.Category.GetCategoryAsync(id, trackChanges);
            if (category == null)
                throw new CategoryNotFoundException(id);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
