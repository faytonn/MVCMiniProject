using BusinessLogicLayer.DTOs.Category;
using BusinessLogicLayer.ViewModels.Common;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CreateCategoryDTO createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task<TPageableViewModel<CategoryDTO>> GetPaginatedAllAsync(int pageIndex = 1, int pageSize = 10)

    }
}
