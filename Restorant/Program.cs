using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restorant.Application.Contracts;
using Restorant.Application.IServices;
using Restorant.Application.Services;
using Restorant.Data;
using Restorant.Infrastructure;
using Restorant.Models;

namespace Restorant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            var conn = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<RestorantDbContext>(options =>
            
                options.UseSqlServer(conn),
                ServiceLifetime.Transient
            );

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("PasswordRequirements:RequireConfirmedEmail");
                options.Password.RequireDigit = builder.Configuration.GetValue<bool>("PasswordRequirements:RequireDigit");
                options.Password.RequiredLength = builder.Configuration.GetValue<int>("PasswordRequirements:MinimumLength");
                options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("PasswordRequirements:RequireSpecialCharacter");
                options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("PasswordRequirements:RequireUppercase");
                options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("PasswordRequirements:RequireLowercase");
                options.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("PasswordRequirements:RequireUniqueEmail");

            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<RestorantDbContext>();

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ICartIMenuitemRepository, CartIMenuitemRepository>();
            builder.Services.AddScoped<IUserCartRepository, UserCartRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IMenuitemOrderRepository, MenuitemOrderRepository>();












            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //builder.Services.AddIdentity<Models.AppUser, Microsoft.AspNetCore.Identity.IdentityRole>()
            //    .AddEntityFrameworkStores<Data.RestorantDbContext>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
