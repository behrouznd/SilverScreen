using Entities.Categories;

namespace Contracts.Categories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetCategoryAsync(Guid id, bool trackChanges);

        void CreateCategory(Category category);
        Task<IEnumerable<Category>> GetCategoryByIdsAsync(IEnumerable<Guid> ids , bool trackChanges);
    }
}
