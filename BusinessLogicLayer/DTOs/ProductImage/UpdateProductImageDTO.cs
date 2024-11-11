namespace BusinessLogicLayer.DTOs.ProductImage
{
    public class UpdateProductImageDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
    }
}
