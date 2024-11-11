using AutoMapper;
using BusinessLogicLayer.DTOs.Setting;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Services.Abstractions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Setting> _repository;

        public SettingService(IMapper mapper, IRepository<Setting> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<SettingDTO>> GetAllAsync()
        {
            var settings = await _repository.GetAllAsync();
            return _mapper.Map<List<SettingDTO>>(settings);
        }

        public async Task<SettingDTO> GetByIdAsync(int id)
        {
            var setting = await _repository.GetByIdAsync(id);
            if (setting == null) throw new KeyNotFoundException("Setting not found");

            return _mapper.Map<SettingDTO>(setting);
        }

        public async Task CreateAsync(CreateSettingDTO dto)
        {
            var setting = _mapper.Map<Setting>(dto);
            await _repository.AddAsync(setting);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateSettingDTO dto)
        {
            var setting = await _repository.GetByIdAsync(dto.Id);
            if (setting == null) throw new KeyNotFoundException("Setting not found");

            _mapper.Map(dto, setting);
            _repository.Update(setting);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var setting = await _repository.GetByIdAsync(id);
            if (setting == null) throw new KeyNotFoundException("Setting not found");

            _repository.Delete(setting);
            await _repository.SaveChangesAsync();
        }
    }
}
