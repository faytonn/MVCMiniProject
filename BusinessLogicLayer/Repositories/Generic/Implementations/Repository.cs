using BusinessLogicLayer.Repositories.Generic.Abstractions;
using Microsoft.EntityFrameworkCore;
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

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}