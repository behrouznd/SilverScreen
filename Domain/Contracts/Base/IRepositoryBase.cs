using System.Linq.Expressions;

namespace Contracts.Base
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T,bool>> condition , bool trackCahnges);
        void Create(T entity);
        void Update(T entity);  
        void Delete(T entity);
    }
}
