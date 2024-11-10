namespace BusinessLogicLayer.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public int? ParentId { get; set; }
    }
}
