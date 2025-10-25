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
    public class CreateMenuItemDto
    {
        [Required (ErrorMessage = " Require Name Must by More Than 5 Character ")]
        [MaxLength(50)]
        [MinLength(5)]
        // [ReqularExpression("[a-zA-Z]{5,50}")]
        //[UniqueName]
        public string Name { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Require Description Must by More Than 5 Character ")]
        [MaxLength(200)]
        [MinLength(5)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Require Price Must by Grater Than 20 EGP ")]
        [Range(minimum:20,maximum:1000)] // =[Range(20,1000)]
        public double Price { get; set; }
        //[Required]
        // [ReqularExpression(@"\w+\.(jpg|png)")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Category Must by Selected ")]
        public int CategoryId { get; set; }
        public List<GetAllCategoriesDto> Categories { get; set; } = new();
    }
}
