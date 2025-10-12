using BaiTapNhom_2.Service;
using BaiTapNhom_2.Service.Ipl;

namespace BaiTapNhom_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<DIProduct>();
            builder.Services.AddScoped<DIConnectData>();
            builder.Services.AddScoped<TaiKhoanSevice, ITaiKhoanService>();
            builder.Services.AddScoped<ProductService, IProductService>();
            builder.Services.AddScoped<CategoryService, ICategory>();
            builder.Services.AddControllersWithViews();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
            

            app.Run();
        }
    }
}
