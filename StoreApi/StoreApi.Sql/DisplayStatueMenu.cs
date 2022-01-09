using StoreApi.Dtos;
using System.Data.SqlClient;

namespace StoreApi.StoreApi.Sql
{
    public class DisplayStatueMenu
    {
        public static List<StatueDtos> ReadStatueMenu(int storeID)
        {
            string connectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connectionString);

            List<StatueDtos> statueList = new List<StatueDtos>();
            connection.Open();

            string displayMenuQuery = $"  SELECT Statue.Item_ID, Statue.Style, Statue.Price, Statue_Store_Inventory.Qty \nFROM Statue \nJOIN Statue_Store_Inventory \nON Statue.Item_ID = Statue_Store_Inventory.Item_ID \nJOIN Store \nON Statue_Store_Inventory.Store_ID = Store.Store_ID \nWHERE Store.Store_ID = 80;";

            using SqlCommand displayMenuCommand = new(displayMenuQuery, connection);
            using SqlDataReader reader = displayMenuCommand.ExecuteReader();
            while (reader.Read())
            {
                int itemID = reader.GetInt32(0);
                string style = reader.GetString(1);
                decimal price = reader.GetDecimal(2);
                int quantity = reader.GetInt32(3);
                StatueDtos statueDtos = new StatueDtos();
                statueDtos.itemID = itemID;
                statueDtos.style = style;
                statueDtos.price = price;
                statueDtos.quantity = quantity;
                statueList.Add(statueDtos);
            }
            
            connection.Close();

            return statueList;
        }
    }
}
