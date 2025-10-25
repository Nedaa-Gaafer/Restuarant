using Microsoft.AspNetCore.Identity;

namespace Restorant.Models
{
    public class AppUser: IdentityUser
    {
        public string?  Address { get; set; }
        public string? City { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Order> Orders { get; set; }
        public List<Cart> CartOrders { get; set; }
    }
}
