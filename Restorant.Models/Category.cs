using System.ComponentModel.DataAnnotations;

namespace Restorant.Models
{
    public class Category: BaseEntity
    {

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string? ImageUrl { get; set; }
        
        public List<MenuItem> MenuItems { get; set; } = new();

    }
}
