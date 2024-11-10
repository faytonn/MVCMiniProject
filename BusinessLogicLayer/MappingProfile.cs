using AutoMapper;
using BusinessLogicLayer.DTOs.Category;
using BusinessLogicLayer.DTOs.Product;
using BusinessLogicLayer.DTOs.Tag;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<Tag, CreateTagDTO>().ReverseMap();
            CreateMap<Tag, UpdateTagDTO>().ReverseMap();
        }
    }
}

