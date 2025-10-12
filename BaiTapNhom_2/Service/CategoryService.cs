using BaiTapNhom_2.Models;

namespace BaiTapNhom_2.Service
{
    public interface CategoryService
    {
        bool AddCategory(string categoryName);
        List<DanhMucSP> GetAll();
    }
}
