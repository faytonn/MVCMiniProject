using AutoMapper;
using BusinessLogicLayer.DTOs.Product;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Services.Abstractions;
using BusinessLogicLayer.ViewModels.Common;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MVCMiniProject.DataAccessLayer;

namespace BusinessLogicLayer.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        private readonly AppDBContext _context;

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

        public async Task<ProductDTO> AddProductAsync(CreateProductDTO createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task UpdateProductAsync(UpdateProductDTO updateProductDto)
        {
            var product = await _repository.GetByIdAsync(updateProductDto.Id);
            if (product == null) return;

            _mapper.Map(updateProductDto, product);
            _repository.Update(product);
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

        public async Task<TPageableViewModel<ProductDTO>> GetPaginatedAllAsync(int pageIndex = 1, int pageSize = 10)
        {
            var paginatedData = await _repository.GetPaginatedAllAsync<Product>(pageIndex, pageSize);

            var dtoItems = paginatedData.Items.Select(item => _mapper.Map<ProductDTO>(item)).ToList();

            return new TPageableViewModel<ProductDTO>
            {
                Items = dtoItems,
                Index = paginatedData.Index,
                Size = paginatedData.Size,
                Count = paginatedData.Count,
                Pages = paginatedData.Pages,
                HasPrevious = paginatedData.HasPrevious,
                HasNext = paginatedData.HasNext
            };
        }

        public async Task<List<ProductDTO>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToListAsync();

            return products;
        }


    }
}
