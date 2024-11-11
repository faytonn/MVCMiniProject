using AutoMapper.Features;
using DataAccessLayer.Entities;

namespace MVCMiniProject.Views.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> FeaturedProducts { get; set; }

        public List<Product> NewProducts { get; set; }

        public List<Product> DiscountedProducts { get; set; }

        public List<Slider> Sliders { get; set; }

    }
}
