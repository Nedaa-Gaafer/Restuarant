using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restorant.Models;

namespace Restorant.Data
{
    public class RestorantDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartMenuItem> CartMenuItems { get; set; }
        public DbSet<MenuItemOrder> MenuItemOrders { get; set; }
        public RestorantDbContext(DbContextOptions<RestorantDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestorantDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;
            foreach (var entityEntry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Entity.UpdatedAt = now;
                    entityEntry.Entity.UpdatedAt = null;
                }

                 else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Entity.UpdatedAt= now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);

        }

    }
}
