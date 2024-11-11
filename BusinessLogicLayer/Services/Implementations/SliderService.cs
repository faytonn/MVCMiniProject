using AutoMapper;
using BusinessLogicLayer.DTOs.Slider;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Services.Abstractions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Slider> _repository;

        public SliderService(IMapper mapper, IRepository<Slider> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<SliderDTO>> GetAllAsync()
        {
            var sliders = await _repository.GetAllAsync();
            return _mapper.Map<List<SliderDTO>>(sliders);
        }

        public async Task<SliderDTO> GetByIdAsync(int id)
        {
            var slider = await _repository.GetByIdAsync(id);
            if (slider == null) throw new KeyNotFoundException("Slider not found");

            return _mapper.Map<SliderDTO>(slider);
        }

        public async Task CreateAsync(CreateSliderDTO dto)
        {
            var slider = _mapper.Map<Slider>(dto);
            await _repository.AddAsync(slider);
        }

        public async Task Update(UpdateSliderDTO dto)
        {
            var slider = await _repository.GetByIdAsync(dto.Id);
            if (slider == null) throw new KeyNotFoundException("Slider not found");

            _mapper.Map(dto, slider);
             _repository.Update(slider);
             
        }

        public async Task Delete(int id)
        {
            var slider = await _repository.GetByIdAsync(id);
            if (slider == null) throw new KeyNotFoundException("Slider not found");

             _repository.Delete(slider);
        }
    }
}
