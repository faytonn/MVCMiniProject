using DataAccessLayer.Entities;

namespace MVCMiniProject.Views.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider>? Sliders { get; set; }
        public List<Product>? Products { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
