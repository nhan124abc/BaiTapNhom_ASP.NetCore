using BaiTapNhom_2.Service;
using Microsoft.AspNetCore.Mvc;
namespace BaiTapNhom_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly DIProduct _diProduct;
        private readonly ProductService _productSV;
        public HomeController(DIProduct diProduct, ProductService product)
        {
            _diProduct = diProduct;
            _productSV = product;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products(int page = 1)
        {

            var list = _productSV.GetAll();
            return View(list);
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
