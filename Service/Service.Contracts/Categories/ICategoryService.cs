using Shared.DataTransferObjects.Categories;

namespace Service.Contracts.Categories
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories(bool trackChanges);

        CategoryDto GetCategoryById(Guid id, bool trackChanges);

        CategoryDto CreateCategory(CategoryForCreationDto category);

        IEnumerable<CategoryDto> GetCategoriesByIds(IEnumerable<Guid> ids, bool trackChanges);
    }
}
