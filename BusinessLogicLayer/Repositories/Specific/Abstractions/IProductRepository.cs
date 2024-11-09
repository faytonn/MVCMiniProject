using BusinessLogicLayer.Repositories.Generic.Abstractions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Repositories.Specific.Abstractions
{
    public interface IProductRepository
    {
            Task<IEnumerable<Product>> GetAllAsync();
            Task<Product> GetByIdAsync(int id);
            Task AddAsync(Product product);
            Task UpdateAsync(Product product);
            Task DeleteAsync(int id);
        
    }
}
