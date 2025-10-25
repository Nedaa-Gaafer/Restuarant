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
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasQueryFilter(c => !c.IsDeleted);
            builder.HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Chicken Burgers",
                     Description = "Delicious grilled burgers"
                },
                new Category
                {
                    Id = 2,
                    Name = "Beef Burgers",
                    Description = "Juicy beef burgers"
                },
                new Category
                {
                    Id = 3,
                    Name = "Pizza",
                    Description = "Delicious grilled pizza"
                }


            );
        }
    }
}
