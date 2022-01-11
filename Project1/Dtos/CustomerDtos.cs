using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Dtos
{
    public class CustomerDtos
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public int customerID { get; set; }
        public StoreDtos store { get; set; } 

        public List<KeyValuePair<Statue, int>> cart { get; set; } = new List<KeyValuePair<Statue, int>>();
    }
}
