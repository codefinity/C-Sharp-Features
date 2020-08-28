using System;
using System.Collections.Generic;
using System.Text;

namespace AutoImplementedProperties
{
    internal class Customer : ICustomer
    {
        //When you declare a property as shown in the following example, 
        //the compiler creates a private, anonymous backing field that can 
        //only be accessed through the property's get and set accessors.
        public double TotalPurchases { get; set; }
        public string Name { get; set; }

        public int CustomerId { get; set; }

        // Constructor
        public Customer(double purchases, string name, int id)
        {
            TotalPurchases = purchases;
            Name = name;
            CustomerId = id;
        }

        // Methods
        public string GetContactInfo() { return "ContactInfo"; }
        public string GetTransactionHistory() { return "History"; }

        // .. Additional methods, events, etc.
    }

}
