using BusinessLogicLayer.DTOs.ProductImage;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface IProductImageService : IRepository<ProductImage>
    {
        Task<List<ProductImageDTO>> GetAllByProductIdAsync(int productId);
        Task<ProductImageDTO> GetByIdAsync(int id);
        Task CreateAsync(CreateProductImageDTO dto);
        void Update(UpdateProductImageDTO dto);
        void DeleteAsync(int id);
    }
}
