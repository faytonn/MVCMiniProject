using DataAccessLayer.Entities;

namespace MVCMiniProject.Views.ViewModels
{
    public class ShopViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
