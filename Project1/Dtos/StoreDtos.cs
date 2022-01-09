using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Dtos
{
    internal class StoreDtos
    {
        private int storeID;

        private string? storeLocation;

        private Dictionary<Statue, int> itemQuantity = new();
    }
}
