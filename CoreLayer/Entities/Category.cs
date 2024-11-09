using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public int? ParentId { get; set; }
        public Category Parent {  get; set; }
        public List<Category> Children { get; set; } = new List<Category>();
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
