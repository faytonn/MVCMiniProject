using BusinessLogicLayer.DTOs.Setting;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface ISettingService
    {
        Task<List<SettingDTO>> GetAllAsync();
        Task<SettingDTO> GetByIdAsync(int id);
        Task CreateAsync(CreateSettingDTO dto);
        Task UpdateAsync(UpdateSettingDTO dto);
        Task DeleteAsync(int id);
    }
}
