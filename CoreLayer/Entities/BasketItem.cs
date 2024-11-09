using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public class BasketItem : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
