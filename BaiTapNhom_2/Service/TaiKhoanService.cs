using BaiTapNhom_2.Models;
using BaiTapNhom_2.Service.Ipl;
using MySql.Data.MySqlClient;

namespace BaiTapNhom_2.Service
{


    public class TaiKhoanService : TaiKhoanSevice
    {
        private readonly DIConnectData _data;

        public TaiKhoanService(DIConnectData di)
        {
            _data = di;
        }

        public List<TaiKhoan> GetAll()
        {
            var list = new List<TaiKhoan>();
            using var conn = _data.Connect();
            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM TaiKhoan", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapToTaiKhoan(reader));
            }
            return list;
        }

        public TaiKhoan? GetByTenDN(string tenDN)
        {
            using var conn = _data.Connect();
            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM TaiKhoan WHERE TenDN = @TenDN", conn);
            cmd.Parameters.AddWithValue("@TenDN", tenDN);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
                return MapToTaiKhoan(reader);

            return null;
        }

        public TaiKhoan? DangNhap(string tenDN, string matKhau)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenTK = @TenDN AND MatKhau = @MatKhau";
            using var conn = _data.Connect();
            conn.Open();

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TenDN", tenDN);
            cmd.Parameters.AddWithValue("@MatKhau", matKhau);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new TaiKhoan
                {
                    MaTK = reader.GetInt32("MaTK"),
                    TenTK = reader.GetString("TenTK"),
                    LoaiTK = reader.GetInt32("LoaiTK")
                };
            }
            return null;
        }

        public bool Add(TaiKhoan tk)
        {
            using var conn = _data.Connect();
            conn.Open();

            var cmd = new MySqlCommand(
                "INSERT INTO TaiKhoan (TenTK, LoaiTK, MatKhau, TrangThai) VALUES (@TenDN, @LoaiTK, @MatKhau, @TrangThai)",
                conn);
            cmd.Parameters.AddWithValue("@TenDN", tk.TenTK);
            cmd.Parameters.AddWithValue("@LoaiTK", tk.LoaiTK);
            cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
            cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(TaiKhoan tk)
        {
            using var conn = _data.Connect();
            conn.Open();

            var cmd = new MySqlCommand(
                "UPDATE TaiKhoan SET TenTK=@TenDN, LoaiTK=@LoaiTK, MatKhau=@MatKhau, TrangThai=@TrangThai WHERE MaTK=@MaTK",
                conn);
            cmd.Parameters.AddWithValue("@TenDN", tk.TenTK);
            cmd.Parameters.AddWithValue("@LoaiTK", tk.LoaiTK);
            cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
            cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);
            cmd.Parameters.AddWithValue("@MaTK", tk.MaTK);

            return cmd.ExecuteNonQuery() > 0;
        }

      

        private TaiKhoan MapToTaiKhoan(MySqlDataReader reader)
        {
            return new TaiKhoan
            {
                MaTK = reader.GetInt32("MaTK"),
                TenTK = reader["TenTK"].ToString(),
                LoaiTK = Convert.ToInt32(reader["LoaiTK"]),
                MatKhau = reader["MatKhau"].ToString(),
                TrangThai = Convert.ToInt32(reader["TrangThai"])
            };
        }

    }
}


