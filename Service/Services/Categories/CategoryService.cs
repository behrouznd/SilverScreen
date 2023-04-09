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

        public CategoryDto CreateCategory(CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _repository.Category.CreateCategory(categoryEntity);
            _repository.Save();
            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public IEnumerable<CategoryDto> GetAllCategories(bool trackChanges)
        {
 
            var categories = _repository.Category.GetAllCategories(trackChanges);
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public IEnumerable<CategoryDto> GetCategoriesByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null)
                throw new IdParametersBadRequestException();

            var categoriesEntity = _repository.Category.GetCategoryByIds(ids, trackChanges);
            if (categoriesEntity.Count() != ids.Count())
                throw new CollectionByIdsBadRequestException();
            return _mapper.Map<IEnumerable< CategoryDto>>(categoriesEntity);
        }

        public CategoryDto GetCategoryById(Guid id, bool trackChanges)
        {
            var category = _repository.Category.GetCategory(id, trackChanges);
            if (category == null)
                throw new CategoryNotFoundException(id);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
