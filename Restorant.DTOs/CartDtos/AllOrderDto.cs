using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.DTOs.CartDtos
{
    public class AllOrderDto
    {
        public int OrderId { get; set; }
        public double OrderTotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public string? UserId { get; set; }
        public AppUser User { get; set; }
        public List<AddOrderItem> AddOrderItems { get; set; } = new();
    }
}
