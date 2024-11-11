using AutoMapper;
using BusinessLogicLayer.DTOs.BasketItem;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Services.Abstractions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Implementations
{
    public class BasketItemService : IBasketItemService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BasketItem> _repository;

        public BasketItemService(IMapper mapper, IRepository<BasketItem> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<BasketItemDTO>> GetAllByUserIdAsync(string userId)
        {
            var basketItems = await _repository.FindAsync(item => item.UserId == userId);
            return _mapper.Map<List<BasketItemDTO>>(basketItems);
        }

        public async Task<BasketItemDTO> GetByIdAsync(int id)
        {
            var basketItem = await _repository.GetByIdAsync(id);
            if (basketItem == null) throw new KeyNotFoundException("Basket item not found");

            return _mapper.Map<BasketItemDTO>(basketItem);
        }

        public async Task CreateAsync(CreateBasketItemDTO dto)
        {
            var basketItem = _mapper.Map<BasketItem>(dto);
            await _repository.AddAsync(basketItem);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateBasketItemDTO dto)
        {
            var basketItem = await _repository.GetByIdAsync(dto.Id);
            if (basketItem == null) throw new KeyNotFoundException("Basket item not found");

            _mapper.Map(dto, basketItem);
            _repository.Update(basketItem);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var basketItem = await _repository.GetByIdAsync(id);
            if (basketItem == null) throw new KeyNotFoundException("Basket item not found");

            _repository.Delete(basketItem);
            await _repository.SaveChangesAsync();
        }
    }
}
