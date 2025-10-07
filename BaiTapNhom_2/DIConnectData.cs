using MySql.Data.MySqlClient;
namespace BaiTapNhom_2
{
    public class DIConnectData
    {
        private readonly string _connection;
        public DIConnectData(IConfiguration configuration) {
            _connection = configuration.GetConnectionString("MySqlConnection");
            
        }
        public MySqlConnection Connect()
        {
            return new MySqlConnection(_connection);
        }

    }
}
