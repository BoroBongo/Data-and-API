using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SouthwindContext())
            {
                //db.Add(new Customer { CustomerId = "MART", City = "London", ContactName = "Martin", PostalCode = "SE1" });
                //db.Add(new Customer { CustomerId = "ADAM", City = "London", ContactName = "Adam", PostalCode = "W3" });
                //db.Add(new Customer { CustomerId = "AARO", City = "London", ContactName = "Aaron", PostalCode = "XX" });
                //db.Add(new Customer { CustomerId = "MICH", City = "New York", ContactName = "Michael", PostalCode = "SW8" });
                foreach(var cust in db.Customers) {
                if(cust.Country == null)
                    {
                        cust.Country = "United Kingdom";
                    }
                }


                db.SaveChanges();
            }
        }
    }
}
