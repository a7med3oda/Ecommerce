using Ecommerce.Data.Cart;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Configure DbContext
            builder.Services.AddDbContext<EcommerceDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));     // adding connection string (after appsettings step) step:2
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICategoryServices,CategoryServices>();               // AddScoper for DI Lifetime
            builder.Services.AddScoped<IProductServices,ProductServices>();                 // AddScoper for DI Lifetime
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();     // Sessions
            builder.Services.AddScoped(x => ShoppingCart.GetShoppingCart(x));
            builder.Services.AddSession();
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            //Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<EcommerceDbContext>();
            builder.Services.AddMemoryCache();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            builder.Services.AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();       // Sessions
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}");

            app.Run();
        }
    }
}