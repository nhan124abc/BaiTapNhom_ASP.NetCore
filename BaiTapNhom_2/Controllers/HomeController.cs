using BaiTapNhom_2.Service;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace BaiTapNhom_2.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProductService _productSV;
        public HomeController(DIProduct diProduct, ProductService product)
        {
           
            _productSV = product;
        }
        public IActionResult Index()
        {
            return View();
        }
      

        public IActionResult Products(int page = 1)
        {
            int pageSize = 9;
            var list = _productSV.GetAll();
            var products = list
                           .Skip((page - 1) * pageSize) // bỏ qua sản phẩm trước đó
                           .Take(pageSize)              // lấy đúng số lượng
                           .ToList();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)list.Count / pageSize);

           
            return View(products);
        }
       

        public IActionResult Search(String Text)
        {
           
            return View();
        }

        public IActionResult Cart()
        {

            return View();
        }
        public IActionResult Contact()
        {

            return View();
        }
    }
}
