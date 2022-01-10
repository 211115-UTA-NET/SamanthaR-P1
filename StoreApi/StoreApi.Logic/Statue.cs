using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using StoreApi.Dtos;

namespace StoreApi.Logic
{
    public class Statue
    {
        private int itemID;
        private string? style;
        private decimal price;

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

        public Statue(StatueDtos quantity, StoreDtos storeID, StatueDtos itemID)
        {
            StatueDtos statueDtos = new StatueDtos();
            StoreDtos storeDtos = new StoreDtos();
            statueDtos.quantity = quantity;
            storeDtos.storeID = storeID;

        }
    }
}