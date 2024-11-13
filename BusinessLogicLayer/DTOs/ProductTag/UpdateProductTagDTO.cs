namespace BusinessLogicLayer.DTOs.ProductTag
{
    public class UpdateProductTagDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public string TagName { get; set; }
    }
}
