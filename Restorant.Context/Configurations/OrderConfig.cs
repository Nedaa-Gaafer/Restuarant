using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Context.Configurations
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        void IEntityTypeConfiguration<Order>.Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasMany(o => o.MenuItemOrders).WithOne(mi => mi.Order).HasForeignKey(mi => mi.OrderId);

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId);
            builder.Property(o => o.Status).HasConversion<string>();



        }
    }
}
