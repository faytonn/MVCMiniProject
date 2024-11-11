using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.Subscribe
{
    public class SubscribeDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime SubscribedAt { get; set; }
        public bool ConfirmsSubscription { get; set; }
    }
}
