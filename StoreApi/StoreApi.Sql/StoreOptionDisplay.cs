using StoreApi.Dtos;
using System.Data.SqlClient;

namespace StoreApi.Sql
{
    public static class StoreOptionDisplay
    {
        public static List<StoreDtos> ReadStoreMenu()
        {
            string connectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connectionString);

            List<StoreDtos> storeList = new List<StoreDtos>();

            connection.Open();

            string displayStoresQuery = "SELECT * FROM Store";

            using SqlCommand displayStoreCommand = new(displayStoresQuery, connection);
            using SqlDataReader reader = displayStoreCommand.ExecuteReader();
            while (reader.Read())
            {
                StoreDtos storeDtos = new StoreDtos();
                int storeID = reader.GetInt32(0); 
                string storeLocation = reader.GetString(1);
                storeDtos.storeID = storeID;
                storeDtos.storeLocation = storeLocation;
                storeList.Add(storeDtos);
            }


            connection.Close();
            return storeList;

        }
    }
}