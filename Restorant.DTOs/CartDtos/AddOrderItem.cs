using Restorant.DTOs.MenuItemDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.DTOs.CartDtos
{
    public class AddOrderItem
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }
        public PizzaSize? PizzaSize { get; set; }
        public BurgerSize? BurgerSize { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; } = 1;
        public int Id { get; set; }

        public string UserId { get; set; }
    }
}
