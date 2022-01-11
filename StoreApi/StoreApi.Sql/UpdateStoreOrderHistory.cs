﻿using StoreApi.Dtos;
using System.Data.SqlClient;
using StoreApi.Logic;

namespace StoreApi.StoreApi.Sql
{
    public class UpdateStoreOrderHistory
    {
        public async Task AddNewOrder(int customerID, int storeID, DateTime dateTime)
        {
            string connectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connectionString);

            await connection.OpenAsync();

            string newOrder = $"INSERT INTO Statue_Orders (Customer_ID, Store_ID, Ordered_On) VALUES ({customerID}, {storeID}, {dateTime});";

            using SqlCommand newOrderCommand = new(newOrder, connection);
            using SqlDataReader reader = newOrderCommand.ExecuteReader();

            await connection.CloseAsync();


        }
    }
}
