using AutoMapper;
using BusinessLogicLayer.DTOs.Subscribe;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Services.Abstractions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Implementations
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Subscribe> _repository;

        public SubscribeService(IMapper mapper, IRepository<Subscribe> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<SubscribeDTO>> GetAllAsync()
        {
            var subscriptions = await _repository.GetAllAsync();
            return _mapper.Map<List<SubscribeDTO>>(subscriptions);
        }

        public async Task<SubscribeDTO> GetByIdAsync(int id)
        {
            var subscription = await _repository.GetByIdAsync(id);
            if (subscription == null) throw new KeyNotFoundException("Subscription not found");

            return _mapper.Map<SubscribeDTO>(subscription);
        }

        public async Task CreateAsync(CreateSubscribeDTO dto)
        {
            if (await IsEmailSubscribedAsync(dto.Email))
                throw new InvalidOperationException("Email is already subscribed.");

            var subscription = _mapper.Map<Subscribe>(dto);
            subscription.SubscribedAt = DateTime.UtcNow;
            subscription.ConfirmsSubscription = false;

            await _repository.AddAsync(subscription);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateSubscribeDTO dto)
        {
            var subscription = await _repository.GetByIdAsync(dto.Id);
            if (subscription == null) throw new KeyNotFoundException("Subscription not found");

            _mapper.Map(dto, subscription);
            _repository.Update(subscription);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subscription = await _repository.GetByIdAsync(id);
            if (subscription == null) throw new KeyNotFoundException("Subscription not found");

            _repository.Delete(subscription);
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> IsEmailSubscribedAsync(string email)
        {
            var subscriptions = await _repository.FindAsync(s => s.Email == email && s.ConfirmsSubscription);
            return subscriptions.Any();
        }
    }
}
