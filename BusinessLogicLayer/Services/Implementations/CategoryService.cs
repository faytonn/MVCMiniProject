using AutoMapper;
using BusinessLogicLayer.DTOs.Category;
using BusinessLogicLayer.DTOs.Product;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Services.Abstractions;
using BusinessLogicLayer.ViewModels.Common;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task AddCategoryAsync(CreateCategoryDTO createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDto)
        {
            var category = await _repository.GetByIdAsync(updateCategoryDto.Id);
            if (category == null) return;

            _mapper.Map(updateCategoryDto, category);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category != null)
            {
                _repository.Delete(category);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<TPageableViewModel<CategoryDTO>> GetPaginatedAllAsync(int pageIndex = 1, int pageSize = 10)
        {
            var paginatedData = await _repository.GetPaginatedAllAsync<Category>(pageIndex, pageSize);

            var dtoItems = paginatedData.Items.Select(item => _mapper.Map<CategoryDTO>(item)).ToList();

            return new TPageableViewModel<CategoryDTO>
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

    }
}
