using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BaiTapNhom_2.Middlewares
{
    public class AdminAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString().ToLower();

            // Kiểm tra nếu truy cập vào khu vực Admin
            if (path.StartsWith("/admin"))
            {
                var tenDN = context.Session.GetString("TenDN");
                var loaiTK = context.Session.GetInt32("LoaiTK") ?? 0;

                // Nếu chưa đăng nhập hoặc không phải admin => chuyển hướng
                if (string.IsNullOrEmpty(tenDN) || loaiTK != 1)
                {
                    context.Response.Redirect("/TaiKhoan/Login");
                    return;
                }
            }

            await _next(context);
        }

    }

    // Hàm mở rộng để đăng ký Middleware trong Program.cs
    public static class AdminAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAdminAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AdminAuthMiddleware>();
        }
    }
}
