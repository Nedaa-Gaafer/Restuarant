using Restorant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.DTOs.MenuItemDtos
{
    public class GetAllMenuItemDtos
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }
        public PizzaSize? PizzaSize { get; set; }
        public BurgerSize? BurgerSize { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
