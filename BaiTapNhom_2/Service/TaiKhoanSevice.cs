using BaiTapNhom_2.Models;

namespace BaiTapNhom_2.Service
{
    public interface TaiKhoanSevice
    {
        List<TaiKhoan> Getall();
        bool Add(TaiKhoan t);
        bool Login(TaiKhoan t);
    }
}
