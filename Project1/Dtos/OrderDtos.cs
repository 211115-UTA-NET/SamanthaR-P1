using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Dtos
{
    internal class OrderDtos
    {
        public List<KeyValuePair<Statue, int>> item;
        public int quantity { get; set; }
        public StoreDtos? storeLocation { get; set; }
        public DateTime orderedOn { get; set; }
        public Customer? customerName { get; set; }
    }
}
