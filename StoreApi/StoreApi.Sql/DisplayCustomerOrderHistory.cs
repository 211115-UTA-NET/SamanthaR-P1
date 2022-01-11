using StoreApi.Dtos;
using System.Data.SqlClient;
using StoreApi.Logic;

namespace StoreApi.Sql
{
    public class DisplayCustomerOrderHistory
    {
        public static List<OrderDtos> ReadOrderHistory(string customerFirstName, string customerLastName)
        {
            string connectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connectionString);

            List<OrderDtos> orderList = new List<OrderDtos>();

            connection.Open();

            string displayCustomerHistory = $"SELECT Statue_Orders.Order_ID, Store.Location_City, Statue_Orders.Ordered_On, Statue.Style FROM Statue_Orders JOIN Statue ON Statue_Orders.Style = Statue.Style JOIN Store ON Statue_Orders.Store_ID = Store.Store_ID JOIN Garden_Customer ON Statue_Orders.Customer_ID = Garden_Customer.Customer_ID WHERE Garden_Customer.Customer_First_Name = '{customerFirstName}' AND Garden_Customer.Customer_Last_Name = '{customerLastName}'";

            using SqlCommand displayCustomerOrderHistory = new(displayCustomerHistory, connection);
            using SqlDataReader reader = displayCustomerOrderHistory.ExecuteReader();
            while (reader.Read())
            {
                int orderID = reader.GetInt32(0);
                string locationCity = reader.GetString(1);
                DateTime orderedOn = reader.GetDateTime(2);
                string style = reader.GetString(3);
                StatueDtos statueDtos = new StatueDtos();
                StoreDtos storeDtos = new StoreDtos();
                OrderDtos order = new OrderDtos();
                order.orderID = orderID;
                order.storeLocation = locationCity;
                order.orderedOn = orderedOn;
                orderList.Add(order);
            }

            connection.Close();

            return orderList;
        }
    }
}
