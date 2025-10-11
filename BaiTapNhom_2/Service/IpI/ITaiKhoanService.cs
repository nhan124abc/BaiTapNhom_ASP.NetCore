using BaiTapNhom_2.Models;
using MySql.Data.MySqlClient;

namespace BaiTapNhom_2.Service.Ipl
{
    public interface ITaiKhoanService
    {
        List<TaiKhoan> GetAll();
        TaiKhoan? GetByTenDN(string tenDN);
        TaiKhoan? DangNhap(string tenDN, string matKhau);
        bool Add(TaiKhoan tk);
        bool Update(TaiKhoan tk);
        bool Delete(int maTK);


    }
}
