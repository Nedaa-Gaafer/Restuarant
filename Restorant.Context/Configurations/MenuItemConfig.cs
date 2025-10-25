using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Context.Configurations
{
    internal class MenuItemConfig : IEntityTypeConfiguration<MenuItem>
    {
        void IEntityTypeConfiguration<MenuItem>.Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasOne(m => m.Category).WithMany(c => c.MenuItems).HasForeignKey(m => m.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(m => m.PizzaSize).HasConversion<string>();
            builder.Property(m => m.BurgerSize).HasConversion<string>();
            builder.HasQueryFilter(m => !m.IsDeleted);
            builder.HasMany(m => m.MenuItemOrders).WithOne(mi => mi.MenuItem).HasForeignKey(mi => mi.MenuItemId);
            builder.HasData(
                new MenuItem
                {
                    Id = 1,
                    Name = "Air Mega",
                    Description = "Crispy chicken breasted with American cheese,chedder sauce,garlic sauce and ketchup",
                    CategoryId = 1,
                    Price = 58.0,

                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Round Classic",
                    Description = "Crispy chicken breasted with lattuce,temato,pickles,chedder sauce,BBQ sauce and garlic sauce ",
                    CategoryId = 1,
                    Price = 58.0,

                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Chicken Madness",
                    Description = "Crispy chicken breasted with cheese,chedder sauce,ranch sauce and ranch sauce andspicy",
                    CategoryId = 1,
                    Price = 58.0,

                }
            );
        

           

          
        }
    }
}
