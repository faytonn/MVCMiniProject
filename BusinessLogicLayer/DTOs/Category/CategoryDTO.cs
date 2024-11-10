namespace BusinessLogicLayer.DTOs.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; } 
        public List<CategoryDTO> Children { get; set; } = new List<CategoryDTO>();
    }
}
