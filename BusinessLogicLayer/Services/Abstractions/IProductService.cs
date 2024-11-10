using BusinessLogicLayer.DTOs.Category;
using BusinessLogicLayer.DTOs.Product;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task AddProductAsync(CreateProductDTO createDTO);
        Task UpdateProductAsync(UpdateProductDTO updateDTO);
        Task DeleteProductAsync(int id);
    }
}
