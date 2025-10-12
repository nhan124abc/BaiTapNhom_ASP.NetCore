using BaiTapNhom_2.Models;
using BaiTapNhom_2.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text.Json;

namespace BaiTapNhom_2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DIProduct dIProduct;
        private readonly string path;
        private readonly ILogger<HomeController> _logger;

        // Constructor Injection
        private readonly CategoryService categoryService;
        private readonly ProductService productService;
               
        public HomeController(ILogger<HomeController> logger, CategoryService _categoryService,ProductService Pservice)
        {
            
            _logger = logger;
            categoryService = _categoryService;
            productService = Pservice;
        }

        public IActionResult Index()
        {
            var product = productService.GetAll();

            return View(product);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product )
        {
            
            
            return RedirectToAction("Index");
          
        }
        [HttpGet]
        public IActionResult AddProduct( )
        {
            return View();

        }
        
        




    }
}
