namespace BusinessLogicLayer.DTOs.ProductTag
{
    public class ProductTagDTO
    {
        public int Id {  get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public string TagName { get; set; }
    }
}
