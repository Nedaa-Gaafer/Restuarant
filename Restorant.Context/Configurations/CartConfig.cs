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
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        void IEntityTypeConfiguration<Cart>.Configure(EntityTypeBuilder<Cart> builder)
        {

            builder.HasMany(o => o.CartMenuItems).WithOne(mi => mi.Cart).HasForeignKey(mi => mi.CartId);

            builder.HasOne(o => o.User)
                   .WithMany(u => u.CartOrders)
                   .HasForeignKey(o => o.UserId);
            builder.Property(o => o.Status).HasConversion<string>();



        }
    }
}
