using Microsoft.AspNetCore.Mvc;

namespace BaiTapNhom_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly DIProduct _diProduct;
        public HomeController(DIProduct diProduct)
        {
            _diProduct = diProduct;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products(int page = 1)
        {
            int pageSize = 9;
            var Product = _diProduct.products;
            var products = Product
                           .Skip((page - 1) * pageSize) // bỏ qua sản phẩm trước đó
                           .Take(pageSize)              // lấy đúng số lượng
                           .ToList();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)Product.Count / pageSize);
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
