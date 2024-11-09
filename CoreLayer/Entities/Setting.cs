using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public class Setting : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
