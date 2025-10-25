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
    internal class MenuItemOrderConfig : IEntityTypeConfiguration<MenuItemOrder>
    {
        void IEntityTypeConfiguration<MenuItemOrder>.Configure(EntityTypeBuilder<MenuItemOrder> builder)
        {
            builder.HasKey(mo => new { mo.MenuItemId, mo.OrderId });
        }
    }
}
