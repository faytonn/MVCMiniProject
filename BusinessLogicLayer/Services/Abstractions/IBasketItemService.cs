using BusinessLogicLayer.DTOs.BasketItem;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface IBasketItemService
    {
        Task<List<BasketItemDTO>> GetAllByUserIdAsync(string userId);
        Task<BasketItemDTO> GetByIdAsync(int id);
        Task CreateAsync(CreateBasketItemDTO dto);
        Task UpdateAsync(UpdateBasketItemDTO dto);
        Task DeleteAsync(int id);
    }
}
