using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Models
{
    public class Cart: BaseEntity
    {
        public double OrderTotalPrice { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? ReceiptDate { get; set; }
        public string? UserId { get; set; }
        public AppUser User { get; set; }
        public List<CartMenuItem> CartMenuItems { get; set; } = new();
    }
}
