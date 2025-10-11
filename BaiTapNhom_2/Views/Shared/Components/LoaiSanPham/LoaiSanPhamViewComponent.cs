using Microsoft.AspNetCore.Mvc;
using BaiTapNhom_2.Models;
using BaiTapNhom_2.Service.Ipl;
using BaiTapNhom_2.Service;

public class LoaiSanPhamViewComponent : ViewComponent
{
    private readonly CategoryService _categoryService;

    public LoaiSanPhamViewComponent(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IViewComponentResult Invoke()
    {
        var list = _categoryService.GetAll(); // List<DanhMucSP>
        return View(list);
    }
}
