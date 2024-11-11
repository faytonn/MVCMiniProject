using AutoMapper;
using BusinessLogicLayer.DTOs.BasketItem;
using BusinessLogicLayer.DTOs.Category;
using BusinessLogicLayer.DTOs.Product;
using BusinessLogicLayer.DTOs.ProductImage;
using BusinessLogicLayer.DTOs.Service;
using BusinessLogicLayer.DTOs.Setting;
using BusinessLogicLayer.DTOs.Slider;
using BusinessLogicLayer.DTOs.Subscribe;
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

            CreateMap<Slider, SliderDTO>().ReverseMap();
            CreateMap<Slider, CreateSliderDTO>().ReverseMap();
            CreateMap<Slider, UpdateSliderDTO>().ReverseMap();

            CreateMap<Attendance, AttendanceDTO>().ReverseMap();
            CreateMap<Attendance, CreateAttendanceDTO>().ReverseMap();
            CreateMap<Attendance, UpdateAttendanceDTO>().ReverseMap();

            CreateMap<ProductImage, ProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDTO>().ReverseMap();

            CreateMap<BasketItem, BasketItemDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ReverseMap();
            CreateMap<BasketItem, CreateBasketItemDTO>().ReverseMap();
            CreateMap<BasketItem, UpdateBasketItemDTO>().ReverseMap();


            CreateMap<Setting, SettingDTO>().ReverseMap();
            CreateMap<Setting, CreateSettingDTO>().ReverseMap();
            CreateMap<Setting, UpdateSettingDTO>().ReverseMap();

            CreateMap<Subscribe, SubscribeDTO>().ReverseMap();
            CreateMap<Subscribe, CreateSubscribeDTO>().ReverseMap();
            CreateMap<Subscribe, UpdateSubscribeDTO>().ReverseMap();

        }
    }
}

