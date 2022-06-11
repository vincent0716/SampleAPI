using MySql.Data.MySqlClient;

namespace TryRESTAPI.WebConfig
{
    
    public class HttpDBConnection
    {
       
        public static MySqlConnection Conn()
        {
           string ConnectionString = "server=localhost;port=3306;database=app;username=root;password=;";
           MySqlConnection conn = new MySqlConnection(ConnectionString);
            return conn;
        }
    }
}
