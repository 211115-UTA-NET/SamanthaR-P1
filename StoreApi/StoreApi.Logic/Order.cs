using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.Logic
{
    public class Order
    {
        
        private Customer firstName;
        private Customer lastName;
        private DateTime orderedOn;
        private Store storeLocation;
        private List<KeyValuePair<Statue, int>> item;
        public static int quantity { get; set; }
        public static Store? StoreLocation { get; set; }
        public static DateTime OrderedOn { get; set; }
        public static Customer? FirstName { get; set; }
        public static Customer? LastName { get; set; }
        public static List<KeyValuePair<Statue, int>> Item { get; set; }



        string commandText = $"INSERT INTO Orders (Customer_First_Name, Customer_Last_Name, Ordered_On) VALUES ({FirstName}, {LastName}, {Item});";
    }



}
