using StoreApi.Dtos;
using System.Data.SqlClient;

namespace StoreApi.Sql
{
    public class StoreOptionDisplay : IRepository
    {
        public async Task<List<StoreDtos>> ReadStoreMenu()
        {
            string connectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connectionString);

            List<StoreDtos> storeList = new List<StoreDtos>();

            await connection.OpenAsync();

            string displayStoresQuery = "SELECT * FROM Store";

            using SqlCommand displayStoreCommand = new(displayStoresQuery, connection);
            using SqlDataReader reader = displayStoreCommand.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int storeID = reader.GetInt32(0); 
                string storeLocation = reader.GetString(1);
                StoreDtos storeDtos = new StoreDtos(storeID, storeLocation);
                storeList.Add(storeDtos);
            }


            await connection.CloseAsync();
            return storeList;

        }
    }
}