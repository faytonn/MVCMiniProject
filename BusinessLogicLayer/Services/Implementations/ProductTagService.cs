using AutoMapper;
using BusinessLogicLayer.DTOs.Product;
using BusinessLogicLayer.DTOs.ProductTag;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Services.Abstractions;
using CoreLayer.Entities;

namespace BusinessLogicLayer.Services.Implementations
{
    public class ProductTagService : IProductTagService
    {
        private readonly IRepository<ProductTag> _repository;
        private readonly IMapper _mapper;

        public ProductTagService(IRepository<ProductTag> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductTagDTO> CreateAsync(CreateProductTagDTO productTagDTO)
        {
            var productTag = _mapper.Map<ProductTag>(productTagDTO);
            await _repository.AddAsync(productTag);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ProductTagDTO>(productTag);
        }

        public async Task DeleteAsync(int id)
        {
            var productTag = await _repository.GetByIdAsync(id);
            if (productTag != null)
            {
                _repository.Delete(productTag);
                await _repository.SaveChangesAsync();
            }
        }

        public Task<List<ProductTagDTO>> GetAllAsync()
        {
            var productTags = _repository.GetAllAsync();

            return _mapper.Map<List<ProductTagDTO>>(productTags);
        }

        public async Task<ProductTagDTO> GetByIdAsync(int id)
        {
            var productTag = await _repository.GetByIdAsync(id);

            return _mapper.Map<ProductTagDTO>(productTag);
        }
        public void Update(UpdateProductTagDTO productTagDTO)
        {
            throw new NotImplementedException();
        }
    }
}
