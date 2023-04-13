using Shared.DataTransferObjects.Categories;

namespace Service.Contracts.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);

        Task<CategoryDto> GetCategoryByIdAsync(Guid id, bool trackChanges);

        Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto category);

        Task<IEnumerable<CategoryDto>> GetCategoriesByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    }
}
