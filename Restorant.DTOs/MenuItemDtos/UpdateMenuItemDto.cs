using Restorant.DTOs.CategoryDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.DTOs.MenuItemDtos
{
    public class UpdateMenuItemDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Must by More Than 5 Character ")]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Description Must by More Than 5 Character ")]
        [MaxLength(200)]
        [MinLength(5)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price Must by Grater Than 20 EGP ")]
        [Range(minimum: 20, maximum: 1000)]
        public double Price { get; set; }
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Category Must by Selected ")]
        public int CategoryId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public IEnumerable<GetAllCategoriesDto> Categories { get; set; }
    }
}
