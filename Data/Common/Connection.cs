using MySql.Data.MySqlClient;

namespace Shop_Chernyshkov_Final.Data.Common
{
    public class Connection
    {
        readonly static string ConnectionData = "server=127.0.0.1;uid=root;pwd=;database=Shop;";

        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(ConnectionData);  
            connection.Open();

            return connection;
        }

        public static MySqlDataReader GetQuery(string SQL, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand(SQL, connection);
            return command.ExecuteReader();
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);   
        }
    }
}
