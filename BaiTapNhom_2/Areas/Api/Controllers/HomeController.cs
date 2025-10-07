using BaiTapNhom_2.Models;
using BaiTapNhom_2.Service;
using BaiTapNhom_2.Service.Ipl;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;

namespace BaiTapNhom_2.Areas.Api.Controllers
{
    [Area("Api")]
    public class HomeController : Controller
    {
        private readonly DIConnectData _data;
        private readonly TaiKhoanSevice Itk;
        public HomeController(DIConnectData _di,TaiKhoanSevice taiKhoanSevice) { 
        Itk = taiKhoanSevice;
        _data = _di;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(TaiKhoan tk)
        {
            if (Itk.Add(tk))
            {
                return Ok("add okkk");
            }
            else {
                return Ok("nooooooooo");
            }
           
        }
    }
}
