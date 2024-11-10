using BusinessLogicLayer.DTOs.Tag;

namespace BusinessLogicLayer.Services.Abstractions
{
    public interface ITagService
    {
        Task<List<TagDTO>> GetAllTagsAsync();
        Task<TagDTO> GetTagByIdAsync(int id);
        Task AddTagAsync(CreateTagDTO createTagDto);
        Task UpdateTagAsync(UpdateTagDTO updateTagDto);
        Task DeleteTagAsync(int id);

    }
}
