using MySql.Data.MySqlClient;

namespace AsTech_API.Conexao
{
    public class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            string connectionstring = "Server=astech.mysql.database.azure.com;Uid=astech;Database=astech_database;Pwd=#astech";
            return new 
                MySqlConnection(connectionstring);
        }
    }
}
