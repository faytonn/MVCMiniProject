using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
