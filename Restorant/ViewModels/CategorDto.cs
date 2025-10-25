using Restorant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restorant.ViewModels
{
    public class CategorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
