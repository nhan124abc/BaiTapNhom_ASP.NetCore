using BaiTapNhom_2.Models;
using BaiTapNhom_2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
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
        private readonly DIConnectData _db;
        private readonly IWebHostEnvironment _env;


        // Constructor Injection
        private readonly CategoryService categoryService;
        private readonly ProductService productService;

        public HomeController(ILogger<HomeController> logger, CategoryService _categoryService, ProductService Pservice, DIConnectData db, IWebHostEnvironment env)
        {

            _logger = logger;
            categoryService = _categoryService;
            productService = Pservice;
            _db = db;
            _env = env;
        }

        public IActionResult Index()
        {
            var product = productService.GetAll();

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, List<IFormFile> HinhAnhFiles)
        {
            if (!ModelState.IsValid)
            {
                var danhMucList = productService.GetAll();
                return View(product);
            }


            if (HinhAnhFiles != null && HinhAnhFiles.Count > 0)
            {
                // Thư mục lưu ảnh trong wwwroot/img
                var uploadFolder = Path.Combine(_env.WebRootPath, "img");
                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                var imageNames = new List<string>();

                foreach (var file in HinhAnhFiles)
                {
                    if (file.Length > 0)
                    {
                        // Tạo tên file duy nhất
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        // Lưu file vào server
                        var filePath = Path.Combine(uploadFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // Thêm tên file vào list
                        imageNames.Add(fileName);
                    }
                }

                // Lưu tên file vào database, nối bằng ;
                product.HinhAnh = string.Join(";", imageNames);
            }


            using (var conn = _db.Connect())
            {
                conn.Open();
                string query = @"INSERT INTO SanPham 
                         (TenSP, MoTa, Gia, MaDM, HinhAnh, SoLuong, TrangThaiSP)
                         VALUES (@TenSP, @MoTa, @Gia, @MaDM, @HinhAnh, @SoLuong, 1)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSP", product.TenSP);
                    cmd.Parameters.AddWithValue("@MoTa", product.MoTa ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Gia", product.Gia);
                    cmd.Parameters.AddWithValue("@MaDM", product.MaDM);
                    cmd.Parameters.AddWithValue("@HinhAnh", product.HinhAnh ?? string.Empty);
                    cmd.Parameters.AddWithValue("@SoLuong", product.SoLuong);

                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();

        }






    }
}
