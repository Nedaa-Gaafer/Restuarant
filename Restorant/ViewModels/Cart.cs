using Restorant.Models;

namespace Restorant.ViewModels
{
    public  class Cart
    {

        public MenuItem MenuItem = new();
        public int Quantity { get; set; } = 1;
        public double Price { get; set; }

        public static List<Cart> AllOrderItem = new();
    }

}
