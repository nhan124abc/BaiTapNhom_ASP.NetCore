using BaiTapNhom_2.Models;
using BaiTapNhom_2.Service.Ipl;
using Microsoft.AspNetCore.Mvc;

public class TaiKhoanController : Controller
{
    private readonly ITaiKhoanService _taiKhoanService;

    public TaiKhoanController(ITaiKhoanService taiKhoanService)
    {
        _taiKhoanService = taiKhoanService;
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string tenDN, string matKhau)
    {
        if (string.IsNullOrWhiteSpace(tenDN) || string.IsNullOrWhiteSpace(matKhau))
        {
            ViewBag.Error = "Vui lòng nhập đầy đủ thông tin.";
            return View();
        }
       
        var tk = _taiKhoanService.DangNhap(tenDN, matKhau);

        if (tk != null)
        {
            // Lưu thông tin vào session
            HttpContext.Session.SetInt32("MaTK", tk.MaTK);
            HttpContext.Session.SetString("TenDN", tk.TenDN ?? "");
            HttpContext.Session.SetInt32("LoaiTK", tk.LoaiTK);

            // Chuyển hướng theo loại tài khoản
            if (tk.LoaiTK == 1)
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            else
                return RedirectToAction("Index", "Home", new { area = "" });
        }

        ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng.";
        return View();
    }

    public IActionResult Logout()
    {
        // Xóa toàn bộ session
        HttpContext.Session.Clear();

        // Quay về trang đăng nhập
        return RedirectToAction("Login", "TaiKhoan");
    }

}
