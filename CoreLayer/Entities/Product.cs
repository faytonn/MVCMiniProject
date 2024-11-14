using CoreLayer.Entities;
using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public List<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

    }
}
