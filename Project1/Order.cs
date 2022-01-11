using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace Project1
{
    public class Order
    {
        //Fields - details about the order
        private List<KeyValuePair<Statue, int>> item;
        private int quantity;
        private Store? storeLocation;
        private DateTime orderedOn;
        private Customer? customerName;

        //Properties
        public List<KeyValuePair<Statue, int>> Item
        {
            get { return item; }
            set { item = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public Store? StoreLocation
        {
            get { return storeLocation; }
            set { storeLocation = value; }
        }
        public DateTime OrderedOn
        {
            get { return orderedOn; }
            set { orderedOn = value; }
        }
        public Customer? CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        //Constructor 
        public Order(Store storeLocation, Customer customerName)
        {
            this.item = customerName.Cart;
            this.storeLocation = storeLocation;
            this.orderedOn = DateTime.Now;
            this.customerName = customerName;
        }

        //Methods
        public void SaveOrderIntoDB()
        {
            string connnectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connnectionString);
            connection.Open(); //this opens the connection

            string commandText = $"INSERT INTO Orders (Customer_ID, Store_ID, Ordered_On) VALUES ({customerName.CustomerID}, {storeLocation.StoreID}, {DateTime.Now});";

            using SqlCommand command = new(commandText, connection);

            using SqlDataReader reader = command.ExecuteReader();
            connection.Close();
            for (int i = 0; i < item.Count(); i++)
            {
                connection.Open();
                commandText = $"INSERT INTO ";///put the stuff going into the linq table and whereevr storing the purchased items
                using SqlCommand command2 = new(commandText, connection);

                using SqlDataReader reader2 = command.ExecuteReader();
                connection.Close();
            }
        }
        public void PrintOrderInfo()
        {
            WriteLine($"{CustomerName} purchases {Quantity} {Item} on {OrderedOn}");
        }

    }
}