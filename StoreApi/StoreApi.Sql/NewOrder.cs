using StoreApi.Dtos;
using System.Data.SqlClient;
using StoreApi.Logic;

namespace StoreApi.StoreApi.Sql
{
    public class NewOrder
    {
        public static OrderDtos PlaceNewOrder(OrderDtos order)
        {
            string connectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connectionString);

            connection.Open();

            CustomerDtos customerDtos = new CustomerDtos();
            StatueDtos statueDtos = new StatueDtos();
            string commandText = $"INSERT INTO Orders (Customer_First_Name, Customer_Last_Name, Ordered_On) VALUES ({customerDtos.firstName}, {customerDtos.lastName}, {statueDtos.itemID});";


            connection.Close();
            return order;
        }

        //use this method to add the order to the database using a crontroller
    }
}
