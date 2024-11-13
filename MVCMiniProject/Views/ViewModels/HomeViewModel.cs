using AutoMapper.Features;
using BusinessLogicLayer.DTOs.Slider;
using DataAccessLayer.Entities;

namespace MVCMiniProject.Views.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> FeaturedProducts { get; set; }

        public List<Product> NewProducts { get; set; }

        public List<Product> DiscountedProducts { get; set; }

        public List<SliderDTO> Sliders { get; set; }

    }
}
