using BaiTapNhom_2.Models;
using BaiTapNhom_2.Service;
using BaiTapNhom_2.Service.Ipl;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace BaiTapNhom_2.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ProductService _productService;

        public SanPhamController(ProductService context)
        {
            _productService = context;
        }

        public IActionResult Products()
        {
            var list = _productService.GetAll();
            return View(list);
        }
    }
}
