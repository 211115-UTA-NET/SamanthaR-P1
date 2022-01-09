using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.Logic
{
    internal class Order
    {
        public List<KeyValuePair<Statue, int>> item;
        public int quantity { get; set; }
        public Store? storeLocation { get; set; }
        public DateTime orderedOn { get; set; }
        public Customer? customerName { get; set; }
    }
}
