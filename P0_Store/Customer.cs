using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace P0Store
{
    class Customer
    {
        private string? firstName;
        private string? lastName;
        private string? address;
        private string? city;
        private string? state;
        private int customerID;
        private Store store; //this gives customer access to printing store inventory and other functions of the Store class without having to bounce between classes in the program
           
        private List<KeyValuePair<Statue,int>> cart = new List<KeyValuePair<Statue,int>>();        

        public string? FirstName
        {
            get {return firstName;}
            set {firstName = value;}
        }
        public string? LastName
        {
            get {return lastName;}
            set {lastName = value;}
        }
        public string? Address
        {
            get {return address;}
            set {address = value;}
        }
        public string? City 
        {
            get {return city;}
            set {city = value;}
        }
        public string? State 
        {
            get {return state;}
            set {state = value;}
        }
        
        public List<KeyValuePair<Statue,int>> Cart
        {
            get { return cart; }
            set { cart = value; }
        }
        public int CustomerID
        {
            get { return customerID; }
            set { this.customerID = value;}
        }
        public Store Store
        {
            get { return store; }
            set { store = value; }
        }

        public Customer(string firstName, string lastName, string city, string state)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.City = city;
            this.State = state;
        }

        //Method
        //Create a list, then inside the method create a way to add items to the list
        public void AddToCart(Statue statue, int quantity)
        {
            cart.Add(new KeyValuePair<Statue, int>(statue, quantity));
        }
        public void ViewCart()
        {
            for(int i = 0; i<cart.Count(); i++)
            {
                WriteLine(cart[i]);/// make cart[i].Item_Name + " " cart[i].Quantity
            }
        }
        public void MakeAPurchase()
        {
            Order order = new(this.store, this);
        }




    }
}