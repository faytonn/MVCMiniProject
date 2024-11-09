using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public class Subscribe : BaseEntity
    {
        public string Email { get; set; }
        public DateTime SubscribedAt { get; set; }
        public bool ConfirmsSubscription { get; set; }
    }
}
