using BaiTapNhom_2.Models;
using BaiTapNhom_2.Service.Ipl;
using MySql.Data.MySqlClient;

namespace BaiTapNhom_2.Service
{

    public interface TaiKhoanSevice
    {

        List<TaiKhoan> GetAll();
        bool Add(TaiKhoan t);
        bool Update(TaiKhoan t);
        public TaiKhoan? GetByTenDN(string tenDN);
        public TaiKhoan? DangNhap(string tenDN, string matKhau);


        
    }
   }

       

