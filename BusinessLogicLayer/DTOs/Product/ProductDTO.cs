using BusinessLogicLayer.DTOs.Category;
using BusinessLogicLayer.DTOs.ProductImage;
using BusinessLogicLayer.DTOs.ProductTag;

namespace BusinessLogicLayer.DTOs.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public List<string> ProductImages { get; set; }
        public List<string> ProductTags { get; set; }
    }
}
