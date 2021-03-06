using StoreApi.Dtos;
using StoreApi.Logic;
using System.Data.SqlClient;

namespace StoreApi.Sql
{
    public class UpdateQuantity
    {
        public async Task UpdateItemQuantity(int quantity, int storeID, int itemID)
        {
            string connectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connectionString);
            

            await connection.OpenAsync();
            StoreDtos store = new StoreDtos();
            string modifyInventory = $"UPDATE Statue_Store_Inventory SET Qty = Qty - {quantity} WHERE Store_ID = {storeID} AND Item_ID = {itemID}";
            using SqlCommand command = new(modifyInventory, connection);
            using SqlDataReader reader = command.ExecuteReader();
            

            await connection.CloseAsync();
        }
    }
}
