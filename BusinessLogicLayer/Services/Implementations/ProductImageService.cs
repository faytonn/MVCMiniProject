using AutoMapper;
using BusinessLogicLayer.DTOs.ProductImage;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Services.Abstractions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Implementations;

public class ProductImageService : IProductImageService // bunu duzeldecem prosto umumiyyetle baxa bilersen? :D tamam butun sinif baxiriq YOX YOX YOX auwuiduawndaa YXO
{
    private readonly IMapper _mapper;
    private readonly IRepository<ProductImage> _repository;

    public ProductImageService(IMapper mapper, IRepository<ProductImage> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<ProductImageDTO>> GetAllByProductIdAsync(int productId)
    {
        var images = await _repository.FindAsync(img => img.ProductId == productId);
        return _mapper.Map<List<ProductImageDTO>>(images);
    }

    public async Task<ProductImageDTO> GetByIdAsync(int id)
    {
        var image = await _repository.GetByIdAsync(id);
        if (image == null) throw new KeyNotFoundException("Product image not found");

        return _mapper.Map<ProductImageDTO>(image);
    }

    public async Task CreateAsync(CreateProductImageDTO dto)
    {
        var image = _mapper.Map<ProductImage>(dto);
        await _repository.AddAsync(image);
    }

    public async void Update(UpdateProductImageDTO dto)
    {
        var image = await _repository.GetByIdAsync(dto.Id);
        if (image == null) throw new KeyNotFoundException("Product image not found");

        _mapper.Map(dto, image);
         _repository.Update(image);
        await _repository.SaveChangesAsync();
    }

    public async void DeleteAsync(int id)
    {
        var image =await _repository.GetByIdAsync(id);
        if (image == null) throw new KeyNotFoundException("Product image not found");

        _repository.Delete(image);
    }


}
