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
    public class CartOrdersConfig: IEntityTypeConfiguration<CartMenuItem>
    {
        void IEntityTypeConfiguration<CartMenuItem>.Configure(EntityTypeBuilder<CartMenuItem> builder)
        {
            builder.HasKey(mo => new { mo.MenuItemId, mo.CartId });
        }
    }
}
