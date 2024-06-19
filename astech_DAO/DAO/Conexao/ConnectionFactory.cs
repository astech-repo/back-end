using MySql.Data.MySqlClient;

namespace astech_DAO.DAO.Conexao
{
    public class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            string connectionstring = "Server=astech-bd.mysql.database.azure.com;Uid=mustech_db;Database=astech_db;Pwd=#Nunesdb12";
            return new 
                MySqlConnection(connectionstring);
        }
    }
}
