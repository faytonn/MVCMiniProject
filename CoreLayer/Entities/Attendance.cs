using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public class Attendance : BaseEntity
    {
        public int Id { get; set; }
        public string Icon { get; set; } //can be image url or something from the assets files
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
