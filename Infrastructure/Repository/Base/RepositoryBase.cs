using Contracts.Base;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext) =>         
            RepositoryContext = repositoryContext;


        public IQueryable<T> FindAll(bool trackChanges) =>
            trackChanges ? RepositoryContext.Set<T>() :
                RepositoryContext.Set<T>().AsNoTracking();


        public IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> condition, bool trackCahnges) =>
            trackCahnges ? RepositoryContext.Set<T>().Where(condition) :
                RepositoryContext.Set<T>().Where(condition).AsNoTracking();


        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);


        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

    }
}
