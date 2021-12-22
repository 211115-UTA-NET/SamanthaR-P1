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
            string connnectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connnectionString); 
            //Fields
            string firstName;
            string lastName;
            string shippingAddress;
            string shippingCity;
            string shippingState;
            int userStatueSelection;
            int userDesiredQty;
            string[] stores = {"Seattle", "Portland", "Sacramento"};
            int storeChoice = 0;

            WriteLine("Welcome to the Garden Ceramics Store for Misfit Toys!");
            WriteLine("Please enter your first name.");
            firstName = ReadLine();
            WriteLine("Please enter your last name");
            lastName = ReadLine();

            connection.Open();
            string commandText = $"INSERT INTO Garden_Customer (Customer_First_Name, Customer_Last_Name, Shipping_Address, Shipping_City, Shipping_State) VALUES ('{firstName}', '{lastName}', '{shippingAddress}', '{shippingCity}', '{shippingState}');";
            using SqlCommand command1 = new(commandText, connection);
            connection.Close();
            WriteLine($"It's nice to meet you, {firstName} {lastName}! \nWhat store do you prefer to make your orders to? \nPlease select from the following:\nFor Seattle, enter 1 \nFor Portland, enter 2 \nFor Sacramento, enter 3");
            
            while(storeChoice != null)
            {
                try{
                    storeChoice = Convert.ToInt32(ReadLine());
                    WriteLine($"You have selected {stores[storeChoice-1]}. Excellent choice!");
                    break;
                }
                catch (IndexOutOfRangeException)
                {
                    WriteLine("Error: Options are from 1 to 3 \nPlease enter 1 for Seattle, 2 for Portland, or 3 for Sacramento.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Error: you did not enter a number. \nPlease enter 1 for Seattle, 2 for Portland, or 3 for Sacramento.");
                    continue;
                }
            }
            WriteLine("What is the first line of your address for shipping?");
            shippingAddress= ReadLine();
            WriteLine("What is your city?");
            shippingCity = ReadLine();
            WriteLine("What is your state?");
            shippingState = ReadLine();

            // do {
            //     WriteLine("");
            // }while();
            
            using SqlConnection connection = new(connnectionString); 
            connection.Open();
            commandText = "SELECT * FROM Statue;";
            
            //then insert those variables into the appropriate information by columns of the customer table
 
            using SqlCommand command2 = new(commandText, connection);
            //take this command and put it through this connection

            //input validation printline
            using SqlDataReader reader = command2.ExecuteReader();

            while (reader.Read()) //reads one row at a time, getting one value for each column, indexes at [0], you must know the type and the value that will come out of the database
            {
    
                int itemID = reader.GetInt32(0);

                string style = reader.GetString(1);
    
                decimal price = reader.GetDecimal(2);

                Console.WriteLine($"Enter {itemID} to select '{style}' for ${price}");
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