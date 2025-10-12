using BaiTapNhom_2.Models;

using BaiTapNhom_2.Service.Ipl;

using BaiTapNhom_2.Service;

using Microsoft.AspNetCore.Mvc;

namespace BaiTapNhom_2.Areas.Api.Controllers
{
    [Area("Api")]
    public class HomeController : Controller
    {
        private readonly DIConnectData _data;
        private readonly TaiKhoanSevice Itk;
        public HomeController(DIConnectData _di,TaiKhoanSevice taiKhoanService) { 
        Itk = taiKhoanService;
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
                return Ok(tk);
            }
            else {
                return Ok("nooooooooo");
            }
           
        }
        [HttpPost]
        public IActionResult login(TaiKhoan tk)
        {
            if (Itk.Add(tk))
            {
                return Ok(tk);
            }
            else
            {
                return Ok("nooooooooo");
            }

        }
        [HttpGet]
        public IActionResult login()
        {
            return View();

        }
    }
}
