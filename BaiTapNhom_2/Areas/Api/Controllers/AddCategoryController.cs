using BaiTapNhom_2.Models;
using BaiTapNhom_2.Service;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapNhom_2.Areas.Api.Controllers
{
    [Area("Api")]
    public class AddCategoryController : Controller
    {
        private readonly CategoryService _categoryService;
        public AddCategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }


    
        public IActionResult GetAll()
        {
            var list = _categoryService.GetAll();
                

            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddCategory([FromForm] string TenDanhMuc)
        {
            var dm = new DanhMucSP { TenDM = TenDanhMuc };
            _categoryService.AddCategory(TenDanhMuc);


            return Ok(new { success = true });
        }
    }
}
