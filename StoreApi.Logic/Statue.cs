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
    class Statue
    {
        //What fields should be here?
        private int itemID;
        private string? style;
        private decimal price;

        //Properties
        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        public string? Style
        {
            get { return style; }
            set { style = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        //Constructor
        public Statue(int itemID, string style, decimal price)
        {
            this.itemID = itemID;
            this.style = style;
            this.price = price;
        }
    }
}