using CoreLayer.Entities;
using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
