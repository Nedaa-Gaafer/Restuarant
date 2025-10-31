using Restorant.DTOs.CartDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.DTOs.OrderDtos
{
    public class GetUserOrdersDto
    {
        public int Id { get; set; }
        public double OrderTotalPrice { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string? UserId { get; set; }
        public IEnumerable<AddOrderItem> OrderItems { get; set; }
    }
}
