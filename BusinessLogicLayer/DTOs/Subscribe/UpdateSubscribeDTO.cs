using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.Subscribe
{
    public class UpdateSubscribeDTO
    {
        public int Id { get; set; }
        public bool ConfirmsSubscription { get; set; }
    }
}
