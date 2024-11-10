using BusinessLogicLayer.DTOs.Category;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CreateCategoryDTO createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDto);
        Task DeleteCategoryAsync(int id);

    }
}
