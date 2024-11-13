using BusinessLogicLayer.DTOs.ProductTag;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface IProductTagService
    {
        Task<List<ProductTagDTO>> GetAllAsync();
        Task<ProductTagDTO> GetByIdAsync(int id);
        Task<ProductTagDTO> CreateAsync(CreateProductTagDTO productTagDTO);
        void Update(UpdateProductTagDTO productTagDTO);
        Task DeleteAsync(int id);
    }
}
