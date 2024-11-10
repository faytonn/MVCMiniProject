namespace BusinessLogicLayer.DTOs.Category
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public int? ParentId { get; set; }
    }
}
