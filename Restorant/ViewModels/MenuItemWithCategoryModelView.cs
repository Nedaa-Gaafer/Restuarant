using Restorant.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restorant.ViewModels
{
    public class MenuItemWithCategoryModelView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [MaxLength(200)]
        public string? Description { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "ImageUrlis Required")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Range(5, 99999)]
        public double Price { get; set; }
        //public Size? Size { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }


    }

    public enum BurgerSize
    {
        Single,
        Double,
        Triple
    }
}
