using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Dtos
{
    public class StoreDtos
    {
        public int StoreID { get; set; }

        public string? StoreLocation { get; set; }

        public StoreDtos() { }
        
        public StoreDtos(int storeID, string storeLocation)
        {
            StoreID = storeID;
            StoreLocation = storeLocation;
        }
    }
}
