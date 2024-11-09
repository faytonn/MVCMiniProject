using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
