using StoreApi.Dtos;
using System.Data.SqlClient;
using StoreApi.Logic;

namespace StoreApi.Sql
{
    public class AddCustomer
    {
        public async Task<CustomerDtos> AddNewCustomer(CustomerDtos customer)
        {
            string connectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connectionString);
            
            await connection.OpenAsync();
            
            string newUser = $"INSERT INTO Garden_Customer (Customer_First_Name, Customer_Last_Name, Shipping_Address, Shipping_City, Shipping_State) VALUES ('{customer.firstName}', '{customer.lastName}', '{customer.address}', '{customer.city}', '{customer.state}');";

            using SqlCommand newUserCommand = new(newUser, connection);
            using SqlDataReader reader = newUserCommand.ExecuteReader();

            await connection.CloseAsync();

            return customer;
        }
        //to call in the main method, AddCustomer.AddNewCustomer(CustomerDtos object that has already been instantiated)
    }
}


