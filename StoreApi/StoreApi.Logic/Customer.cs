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
    public class Customer
    {
        private string? firstName;
        private string? lastName;
        private string? address;
        private string? city;
        private string? state;
        private int customerID;
        private Store store; 
        private List<KeyValuePair<Statue, int>> cart = new List<KeyValuePair<Statue, int>>();

        public string? FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string? LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string? Address
        {
            get { return address; }
            set { address = value; }
        }
        public string? City
        {
            get { return city; }
            set { city = value; }
        }
        public string? State
        {
            get { return state; }
            set { state = value; }
        }

        public List<KeyValuePair<Statue, int>> Cart
        {
            get { return cart; }
            set { cart = value; }
        }
        public int CustomerID
        {
            get { return customerID; }
            set { this.customerID = value; }
        }
        public Store Store
        {
            get { return store; }
            set { store = value; }
        }

        public Customer(CustomerDtos customer)
        {
            this.firstName = customer.firstName;
            this.lastName = customer.lastName;
            this.city = customer.city;
            this.state = customer.state;
        }

        //Method
        //Create a list, then inside the method create a way to add items to the list
        
        public void MakeAPurchase()
        {
            //Order order = new(this.store, this);
        }




    }
}