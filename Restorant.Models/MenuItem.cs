using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restorant.Models
{
    public class MenuItem: BaseEntity
    {
        [MaxLength(50)]
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [MaxLength(200)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Range(5,99999)]
        public double Price { get; set; }
        public PizzaSize? PizzaSize { get; set; }
        public BurgerSize? BurgerSize { get; set; }

        [MaxLength(50)]
        public string? ImageUrl { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<MenuItemOrder> MenuItemOrders { get; set; } = new();
        public List<CartMenuItem> CartMenuItems { get; set; } = new();
    }

   public enum PizzaSize
   {
        Small,
        Medium,
        Large
   }

    public enum BurgerSize
    {
        Single,
        Double,
        Triple
    }

}
