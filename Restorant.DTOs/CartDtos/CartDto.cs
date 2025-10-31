using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.DTOs.CartDtos
{
    public class CartDto
    {
        public double OrderTotalPrice { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string? UserId { get; set; }
    }
}
