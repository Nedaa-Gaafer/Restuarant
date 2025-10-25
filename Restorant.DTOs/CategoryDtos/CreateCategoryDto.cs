using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.DTOs.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = " Require Name")]
        [MaxLength(50)]
        [MinLength(5, ErrorMessage = " Require Name Must by More Than 5 Character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Require Description")]
        [MaxLength(200)]
        [MinLength(5, ErrorMessage = " Require Description Must by More Than 5 Character")]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}
