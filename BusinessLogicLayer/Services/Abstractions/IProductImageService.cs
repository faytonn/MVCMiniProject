using BusinessLogicLayer.DTOs.ProductImage;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface IProductImageService
    {
        Task<List<ProductImageDTO>> GetAllByProductIdAsync(int productId);
        Task<ProductImageDTO> GetByIdAsync(int id);
        Task CreateAsync(CreateProductImageDTO dto);
        void Update(UpdateProductImageDTO dto);
        void DeleteAsync(int id);
    }
}
