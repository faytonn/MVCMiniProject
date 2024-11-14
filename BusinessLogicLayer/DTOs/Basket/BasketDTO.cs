using BusinessLogicLayer.DTOs.BasketItem;

namespace BusinessLogicLayer.DTOs.Basket
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public ICollection<BasketItemDTO> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
