using Entities.Categories;

namespace Contracts.Categories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        Category GetCategory(Guid id, bool trackChanges);

        void CreateCategory(Category category);
        IEnumerable<Category> GetCategoryByIds(IEnumerable<Guid> ids , bool trackChanges);
    }
}
