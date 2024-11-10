using AutoMapper;
using BusinessLogicLayer.DTOs.Product;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Services.Abstractions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Implementations
{
        public class ProductService : IProductService
        {
            private readonly IRepository<Product> _repository;
            private readonly IMapper _mapper;

            public ProductService(IRepository<Product> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<ProductDTO>> GetAllProductsAsync()
            {
                var products = await _repository.GetAllAsync();
                return _mapper.Map<List<ProductDTO>>(products);
            }

            public async Task<ProductDTO> GetProductByIdAsync(int id)
            {
                var product = await _repository.GetByIdAsync(id);
                return _mapper.Map<ProductDTO>(product);
            }

            public async Task AddProductAsync(CreateProductDTO createProductDto)
            {
                var product = _mapper.Map<Product>(createProductDto);
                await _repository.AddAsync(product);
                await _repository.SaveChangesAsync();
            }

            public async Task UpdateProductAsync(UpdateProductDTO updateProductDto)
            {
                var product = await _repository.GetByIdAsync(updateProductDto.Id);
                if (product == null) return;

                _mapper.Map(updateProductDto, product);
                await _repository.SaveChangesAsync();
            }

            public async Task DeleteProductAsync(int id)
            {
                var product = await _repository.GetByIdAsync(id);
                if (product != null)
                {
                    _repository.Delete(product);
                    await _repository.SaveChangesAsync();
                }
            }


    }
}
