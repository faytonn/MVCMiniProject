using AutoMapper;
using BusinessLogicLayer.DTOs.Tag;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Services.Abstractions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Implementations
{
    public class TagService:ITagService
    {
        private readonly IRepository<Tag> _repository;
        private readonly IMapper _mapper;

        public TagService(IRepository<Tag> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TagDTO>> GetAllTagsAsync()
        {
            var tags = await _repository.GetAllAsync();
            return _mapper.Map<List<TagDTO>>(tags);
        }

        public async Task<TagDTO> GetTagByIdAsync(int id)
        {
            var tag = await _repository.GetByIdAsync(id);
            return _mapper.Map<TagDTO>(tag);
        }

        public async Task AddTagAsync(CreateTagDTO createTagDto)
        {
            var tag = _mapper.Map<Tag>(createTagDto);
            await _repository.AddAsync(tag);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateTagAsync(UpdateTagDTO updateTagDto)
        {
            var tag = await _repository.GetByIdAsync(updateTagDto.Id);
            if (tag == null) return;

            _mapper.Map(updateTagDto, tag);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteTagAsync(int id)
        {
            var tag = await _repository.GetByIdAsync(id);
            if (tag != null)
            {
                _repository.Delete(tag);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
