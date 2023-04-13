using Contracts.Categories;
using Entities.Categories;
using Microsoft.EntityFrameworkCore;
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
         

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Category> GetCategoryAsync(Guid id, bool trackChanges) =>
            await FindByCondition( c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Category>> GetCategoryByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(m=> ids.Contains(m.Id), trackChanges).ToListAsync();
         
    }
}
