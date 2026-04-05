using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Shop_Chernyshkov_Final.Data.Common;
using Shop_Chernyshkov_Final.Data.Interfaces;
using Shop_Chernyshkov_Final.Data.Models;
using System.Linq;

namespace Shop_Chernyshkov_Final.Data.DataBase
{
    public class DBItems : IItems
    {
        public ICategorys ICategorys = new DBCategorys();
        public IEnumerable<Items> AllItems
        {
            get
            {
                List<Items> allItems = new List<Items>();

                MySqlConnection connection = Connection.OpenConnection();

                MySqlDataReader dbItems = Connection.GetQuery("SELECT * FROM 'Items' ORDER BY 'Name'", connection);
                while (dbItems.Read())
                {
                    allItems.Add(new Items()
                    {
                        Id = dbItems.IsDBNull(0) ? -1 : dbItems.GetInt32(0),
                        Name = dbItems.IsDBNull(1) ? null : dbItems.GetString(1),
                        Description = dbItems.IsDBNull(2) ? null : dbItems.GetString(2),
                        Img = dbItems.IsDBNull(3) ? null : dbItems.GetString(3),
                        Price = dbItems.IsDBNull(4) ? 0 : dbItems.GetInt32(4),
                        Category = dbItems.IsDBNull(5) ? null : ICategorys.AllCategorys.Where(x => x.Id == dbItems.GetInt32(5)).First()
                    });
                }

                Connection.CloseConnection(connection);

                return allItems;
            }
        }
        
    }
}
