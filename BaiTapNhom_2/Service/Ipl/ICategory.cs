using BaiTapNhom_2.Models;
using MySql.Data.MySqlClient;

namespace BaiTapNhom_2.Service.Ipl
{
    public class ICategory :CategoryService
    {
        private readonly DIConnectData _connection;
        public ICategory(DIConnectData connectData) {
            _connection = connectData;
        }
        public bool AddCategory(string name)
        {
            using(var conn = _connection.Connect())
            {
              
                string query = "Insert into danhmucsp (TenDM,TrangThaiDM) values(@name,1)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@name", name);
                return cmd.ExecuteNonQuery()>0;
            }

        }
        public List<DanhMucSP> GetAll()
        {
            var list = new List<DanhMucSP>();
            using (var conn = _connection.Connect())
            {
                string query = "SELECT * FROM DanhMucSP Where TrangThaiDM=1 ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new DanhMucSP
                    {
                        MaDM = reader.GetInt32("MaDM"),
                        TenDM=reader.GetString("TenDM")
                        
                    });
                }
            }
            return list;
        }
    }
}
