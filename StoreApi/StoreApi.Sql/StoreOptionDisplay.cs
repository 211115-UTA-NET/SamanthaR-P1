using StoreApi.Dtos;
using System.Data.SqlClient;

namespace StoreApi.StoreApi.Sql
{
    public class StoreOptionDisplay
    {
        public static StoreDtos ReadStoreMenu(int storeID, string city)
        {
            string connectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connectionString);

            connection.Open();

            string displaySotresQuery = "SELECT * FROM Store"
        }
    }
}

//using SqlCommand cmd = new(
//                //       0          1        2        3         4
//                @"SELECT Timestamp, P1.Name, P2.Name, P1M.Name, P2M.Name
//                  FROM Rps.Round
//                      INNER JOIN Rps.Player AS P1 ON Player1 = P1.Id
//                      LEFT JOIN Rps.Player AS P2 ON Player2 = P2.Id
//                      INNER JOIN Rps.Move AS P1M ON Player1Move = P1M.Id
//                      INNER JOIN Rps.Move AS P2M ON Player2Move = P2M.Id
//                  WHERE P1.Name = @playername",
//                connection);

//cmd.Parameters.AddWithValue("@playername", name);

//using SqlDataReader reader = cmd.ExecuteReader();