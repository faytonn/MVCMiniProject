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
        public Category Category { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        public bool IsFeatured { get; set; }
        public bool IsBestSeller { get; set; }
        public bool IsNew {  get; set; }
    }
}
