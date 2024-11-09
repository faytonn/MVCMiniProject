using BusinessLogicLayer.Repositories.Specific.Abstractions;
using DataAccessLayer.Entities;
using MVCMiniProject.DataAccessLayer;

namespace BusinessLogicLayer.Repositories.Specific.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id) => await _context.Products.FindAsync(id);

        public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);

        public async Task UpdateAsync(Product product) => _context.Products.Update(product);

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null) _context.Products.Remove(product);
        }
    }
}