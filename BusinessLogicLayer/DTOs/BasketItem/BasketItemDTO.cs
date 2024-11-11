namespace BusinessLogicLayer.DTOs.BasketItem
{
    public class BasketItemDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
