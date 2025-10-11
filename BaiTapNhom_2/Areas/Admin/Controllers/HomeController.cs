using BaiTapNhom_2.Models;
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
               
        public HomeController(ILogger<HomeController> logger,DIProduct dIProduct,IWebHostEnvironment env)
        {
            this.dIProduct = dIProduct;
            path = Path.Combine(env.ContentRootPath, "db.json");
            _logger = logger;
        }

        public IActionResult Index()
        {
            var product = dIProduct.products;


            return View(product);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product )
        {
            
            var jsondata= System.IO.File.ReadAllText(path);
            var products= JsonSerializer.Deserialize<List<Product>>(jsondata);
            product.MaSP= products.Max(p => p.MaSP) + 1;

            products.Add(product);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJson = JsonSerializer.Serialize(products, options);
            System.IO.File.WriteAllText(path, updatedJson);
            _logger.LogInformation("Sản phẩm mới đã được thêm: MaSP={MaSP}, TenSP={TenSP}",
                              product.MaSP, product.TenSP);
            return RedirectToAction("Index");
          
        }
        [HttpGet]
        public IActionResult AddProduct( )
        {

           

            return View();

        }
       




    }
}
