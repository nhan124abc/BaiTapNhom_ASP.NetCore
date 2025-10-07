using BaiTapNhom_2.Models;
using MySql.Data.MySqlClient;

namespace BaiTapNhom_2.Service.Ipl
{
    public class ITaiKhoanService : TaiKhoanSevice
    {
        private readonly DIConnectData _data;
        public ITaiKhoanService(DIConnectData di) { 
        _data = di;
        }
        public List<TaiKhoan> Getall()
        {
            return null;
        }
        public bool Add(TaiKhoan tk) {
           using var conn =_data.Connect();
            conn.Open();

            var cmd = new MySqlCommand(
               "INSERT INTO TaiKhoan (TenTK, LoaiTK, MatKhau, TrangThaiTK) VALUES (@TenTK, 0, @MatKhau, 1)", conn);
            cmd.Parameters.AddWithValue("@TenTK", tk.TenTK);
           
            cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
           
            return cmd.ExecuteNonQuery() > 0;
        }

    }
}
