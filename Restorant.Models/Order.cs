using System.ComponentModel.DataAnnotations;

namespace Restorant.Models
{
    public class Order: BaseEntity
    {

        public double OrderTotalPrice { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string? UserId { get; set; }
        public AppUser User { get; set; }
        public List<MenuItemOrder> MenuItemOrders { get; set; } = new();

    }



    public enum OrderStatus
    {
        Pending = 0,
        Confirmed = 1,
        Shipped = 2,
        Delivered = 3,
        Cancelled = 4
    }
}
