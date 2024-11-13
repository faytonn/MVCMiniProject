using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MVCMiniProject.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories.Generic.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDBContext _context;

        public Repository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
            await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<TPageableViewModel<T>> GetPaginatedAllAsync<T>
            (
            int pageIndex = 1,
            int pageSize = 10,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null
            )
            where T : class
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if(orderBy != null)
            {
                query = orderBy(query);
            }

            int totalItems = await query.CountAsync();

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new TPageableViewModel<T>
            {
                Items = items,
                Index = pageIndex,
                Size = pageSize,
                Count = totalItems,
                Pages = (int)Math.Ceiling(totalItems / (double)pageSize),
                HasPrevious = pageIndex > 1,
                HasNext = pageIndex < (int)Math.Ceiling(totalItems / (double)pageSize)
            };

        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}