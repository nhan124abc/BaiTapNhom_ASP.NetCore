using BaiTapNhom_2.Models;
using MySql.Data.MySqlClient;
namespace BaiTapNhom_2.Service.Ipl
{
    public class IProductService : ProductService
    {
        private readonly DIConnectData _connectData;
        public IProductService(DIConnectData connectData)
        {
            _connectData = connectData;
        }
        public List<Product> GetAll()
        {
            var list = new List<Product>();
            using (var conn = _connectData.Connect())
            {
                string query = "SELECT * FROM SanPham";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Product
                    {
                        MaSP = reader.GetInt32("MaSP"),
                        TenSP = reader.GetString("TenSP"),
                        DonGia = reader.GetFloat("Gia"),
                        HinhAnh = reader.GetString("HinhAnh")
                    });
                }
            }
            return list;
        }
        public Product GetById(int id)
        {
            Product product = new Product();
            using (var conn = _connectData.Connect())
            {
                string query = "SELECT * FROM SanPham WHERE MaSP = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    product = new Product
                    {
                        MaSP = reader.GetInt32("MaSP"),
                        TenSP = reader.GetString("TenSP"),
                        DonGia = reader.GetFloat("Gia"),
                        HinhAnh = reader.GetString("HinhAnh")
                    };
                }
            }
            return product;
        }
    }
}
