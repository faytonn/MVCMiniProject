using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; } //isHover olsa idi daha yaxsi olardi
    }
}
