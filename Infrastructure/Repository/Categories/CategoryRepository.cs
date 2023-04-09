using Contracts.Categories;
using Entities.Categories;
using Repository.Base;
using Repository.Context;

namespace Repository.Categories
{
    public class CategoryRepository : RepositoryBase<Category> , ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCategory(Category category) =>
            Create(category);
         

        public IEnumerable<Category> GetAllCategories(bool trackChanges) =>
            FindAll(trackChanges).ToList();

        public Category GetCategory(Guid id, bool trackChanges) =>
            FindByCondition( c => c.Id.Equals(id), trackChanges).SingleOrDefault();

        public IEnumerable<Category> GetCategoryByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(m=> ids.Contains(m.Id), trackChanges).ToList();
         
    }
}
