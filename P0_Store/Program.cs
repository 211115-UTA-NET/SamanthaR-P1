using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace P0Store
{
    
    class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Welcome to the Garden Ceramics Store for Misfit Toys!");
            WriteLine("What store do you prefer to make your orders to? \nPlease select from the following:\nFor")
            //Fields
            int userPreferredStore;
            int userStatueSelection;
            int userDesiredQty;
            do {
                WriteLine("")
            }while();
            
            string connnectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");

            using SqlConnection connection = new(connnectionString); //thisi s what's connecting to the database
            connection.Open(); //this opens the connection

            //************Ask the user to select a store: use the following lines of code to list options and take in user option as a variable that can be used later

            string commandText = "SELECT * FROM Statue;";
            //have a method come in to instruct the customer to enter their information
            //assign variables to the input
            //then insert those variables into the appropriate information by columns of the customer table
 
            using SqlCommand command = new(commandText, connection);
            //take this command and put it through this connection

            //input validation printline
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) //reads one row at a time, getting one value for each column, indexes at [0], you must know the type and the value that will come out of the database
            {
    
                int itemID = reader.GetInt32(0);

                string style = reader.GetString(1);
    
                decimal price = reader.GetDecimal(2);

                Console.WriteLine($"Select {itemID} for '{style}' at ${price}");
            }
            
            //decimal itemPrice
            //int quantity
            //decimal total = 0;
            connection.Close();
            //use a do-while loop -- so they can continue to shop if they want more items
            //have a readline for the user's desired option and quantity
            //want to take in a user option and quantity and create a statement that can 1. connection.open(), 2. reduce the inventory at the selected store by their quantity choice, 3. connection.close() 
            //total += qty*price
        } //(while the user's input != 1,2,3,4,or5)
            //
            /* connection.Open;
            
            
            
            
            
            
            
            
            
            Order thisOrder = new()
            string commandText = "SELECT  FROM ;";

            
            
            
            */
    }
}