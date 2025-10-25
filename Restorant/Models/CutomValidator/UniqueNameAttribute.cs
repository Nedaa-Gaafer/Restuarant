using Microsoft.EntityFrameworkCore;
using Restorant.Data;
using System.ComponentModel.DataAnnotations;

namespace Restorant.Models.CutomValidator
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        //private readonly Type entityType;
        //private readonly string name;

        //public UniqueNameAttribute(Type entityType, string name)
        //{
        //    this.entityType = entityType;
        //    this.name = name;
        //}

        private readonly RestorantDbContext context;

        public UniqueNameAttribute(RestorantDbContext context)
        {
            this.context = context;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                string newName = value.ToString();
                
                var menuItemName = context.MenuItems.FirstOrDefault(x => x.Name == newName);
                 var dbContext = (RestorantDbContext)validationContext.GetService(typeof(RestorantDbContext));
                if (menuItemName != null)
                {
                    return new ValidationResult("name already Exist");
                }
                else
                {
                    return ValidationResult.Success;
                }
               
            }
        }
    }
}
