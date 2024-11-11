namespace BusinessLogicLayer.DTOs.BasketItem
{
    public class CreateBasketItemDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
    }
}
