using BusinessLogicLayer.ViewModels.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Repositories.Generic.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<TPageableViewModel<T>> GetPaginatedAllAsync<T>
            (
            int pageIndex = 1,
            int pageSize = 10,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null
            )
            where T : class;
        Task SaveChangesAsync();
    }
}
