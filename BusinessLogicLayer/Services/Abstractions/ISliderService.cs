using BusinessLogicLayer.DTOs.Slider;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface ISliderService
    {
        Task<List<SliderDTO>> GetAllAsync();               
        Task<SliderDTO> GetByIdAsync(int id);              
        Task CreateAsync(CreateSliderDTO dto);             
        Task Update(UpdateSliderDTO dto);             
        Task Delete(int id);
    }
}
