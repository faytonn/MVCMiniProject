using BusinessLogicLayer.DTOs.Subscribe;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface ISubscribeService
    {
        Task<List<SubscribeDTO>> GetAllAsync();
        Task<SubscribeDTO> GetByIdAsync(int id);
        Task CreateAsync(CreateSubscribeDTO dto);
        Task UpdateAsync(UpdateSubscribeDTO dto);
        Task DeleteAsync(int id);
        Task<bool> IsEmailSubscribedAsync(string email);
    }
}
