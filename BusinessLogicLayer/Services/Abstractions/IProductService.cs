using BusinessLogicLayer.DTOs.Product;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<ProductDTO> AddProductAsync(CreateProductDTO createDTO);
        Task UpdateProductAsync(UpdateProductDTO updateDTO);
        Task DeleteProductAsync(int id);
    }
}
