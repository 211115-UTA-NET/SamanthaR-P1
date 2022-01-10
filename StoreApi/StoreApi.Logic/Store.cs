using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace StoreApi.Logic
{
    public class Store
    {
        
        //Properties
        public int StoreID { get; set; }
        public string? StoreLocation { get; set; }
        public Dictionary<Statue, int> ItemQuantity { get; set; }
        //Constructor
        public Store(int storeID, string storeLocation)
        {
            this.StoreID = storeID;
            this.StoreLocation = storeLocation;
        }

        public Store()
        {
        }

        //Method
        public void PrintInventry()
        {
            int i = 0;
            foreach (KeyValuePair<Statue, int> entry in this.ItemQuantity)
            {
                Console.WriteLine(i + ". " + entry.Key + " " + entry.Value);
                i++;
            }
        }

        public static implicit operator int(Store v)
        {
            throw new NotImplementedException();
        }
        //        // public void DecrementInventory(List<KeyValuePair<Statue,int>> Item)
        //        // {
        //        //   string connnectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
        //        //     using SqlConnection connection = new(connnectionString); 

        //        //     for(int i = 0; i < Item.Count(); i++)
        //        //     {
        //        //         connection.Open();
        //        //         string commandText = $"UPDATE  ";//calculate the number that you're updating the value to/have the store give you the quantity, then do the math, then stuff the resutl into the string
        //        //         using SqlCommand command = new(commandText, connection);

        //        //         using SqlDataReader reader = command.ExecuteReader();
        //        //         connection.Close();
        //        //     }   
        //        // }
    }
}
