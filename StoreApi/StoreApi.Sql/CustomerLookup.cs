//using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Logging;
using StoreApi.Dtos;
using System.Data.SqlClient;

namespace StoreApi.Sql
{
    public class CustomerLookup
    {
        public static CustomerDtos ReadCustomers(string firstName, string lastName)
        {
            string connectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connectionString);

            connection.Open();

            string findUserQuery = $"SELECT * FROM Garden_Customer WHERE Customer_First_Name = '{firstName}' AND Customer_Last_Name = '{lastName}';";
            using SqlCommand findUserCommand = new(findUserQuery, connection);
            using SqlDataReader reader = findUserCommand.ExecuteReader();
            reader.Read();
            CustomerDtos customerDtos = new CustomerDtos();
            customerDtos.customerID = reader.GetInt32(0);
            customerDtos.firstName = reader.GetString(1);
            customerDtos.lastName = reader.GetString(2);
            customerDtos.address = reader.GetString(3);
            customerDtos.city = reader.GetString(4);
            customerDtos.state = reader.GetString(5);
            //also read in the store ID
            
            connection.Close();
            
            return customerDtos;
        }
    }

    

        
}
