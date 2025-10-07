using BaiTapNhom_2.Models;
using System.Text.Json;

namespace BaiTapNhom_2.Middleware
{
    public class LoadProductsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string path;
        public LoadProductsMiddleware(RequestDelegate next,IWebHostEnvironment env)
        {
            _next = next;
            path=Path.Combine(env.ContentRootPath, "db.json");

        }
        public async Task InvokeAsync(HttpContext context, DIProduct dIProduct)
        {
            var json = File.ReadAllText(path);
            var products= JsonSerializer.Deserialize<List<Product>>(json);
            dIProduct.products = products;
            await _next(context);
        }
    }
}
