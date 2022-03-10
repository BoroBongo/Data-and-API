// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using NorthwindDBFirst;
using System.Data;
using System.Data.SqlClient;

namespace SQLWithCSharp
{
    public class Program
    {
        // LINQ exercise
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        // Create a data source by using a collection initializer.
        static List<Student> students = new List<Student>
{
    new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
    new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
    new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
    new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
    new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
    new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
    new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
    new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
    new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
    new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
    new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
    new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
};




        static void Main(string[] args)
        {
            //    //List where we will eventually add customer objects to
            //    var customers = new List<Customer>();

            //    var newCustomer = new Customer()
            //    {
            //        CustomerId = "MANDA",
            //        ContactName = "Nish Mandal",
            //        City = "Birmingham",
            //        CompanyName = "ToysRUs"
            //    };

            //    using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            //    {
            //        //Testing our connection is open
            //        connection.Open();
            //        Console.WriteLine(connection.State);

            //        using (var command = new SqlCommand("select cs.CustomerID, cs.ContactName, cs.CompanyName, cs.City, cs.ContactTitle from Customers cs", connection))
            //        {
            //            //command.Connection = connection;
            //            //SQL reader Provides a way of reading a forward-only stream of rows from a SQL Server database. 
            //            SqlDataReader sqlReader = command.ExecuteReader();

            //            // loop while the reader has more data to read. The typical method of reading from the data stream returned by the SqlDataReader is to iterate through each row with a while loop
            //            while (sqlReader.Read())
            //            {

            //                //creating variables for customer
            //                var customerID = sqlReader["CustomerID"].ToString();
            //                var contactName = sqlReader["ContactName"].ToString();
            //                var companyName = sqlReader["CompanyName"].ToString();
            //                var city = sqlReader["City"].ToString();
            //                var contactTitle = sqlReader["ContactTitle"].ToString();

            //                //new customer object
            //                var customer = new Customer() { ContactTitle = contactTitle, CustomerId = customerID, ContactName = contactName, City = city, CompanyName = companyName };

            //                customers.Add(customer);
            //            }

            //            // iterate over and output all customers
            //            foreach (var c in customers)
            //            {
            //                Console.WriteLine($"Customer {c.GetFullName()} has ID {c.CustomerId} and lives in {c.City}");
            //            }
            //            // Close the reader
            //            sqlReader.Close();
            //        }
            //        string sqlDeleteString = $"DELETE from Customers where CustomerID = 'MANDA'";
            //        int affected = 0;
            //        using (var command4 = new SqlCommand(sqlDeleteString, connection))
            //        {
            //            // if successful, this should equal 1
            //            affected = command4.ExecuteNonQuery();
            //        }
            //        string sqlString = $"INSERT INTO Customers(CustomerID, ContactName, City, CompanyName) VALUES ('{newCustomer.CustomerId}', '{newCustomer.ContactName}', '{newCustomer.City}','{newCustomer.CompanyName}')";
            //        // execute insert SQL command
            //        using (var command2 = new SqlCommand(sqlString, connection))
            //        {
            //            //Executes a Transact-SQL statement against the connection and returns the number of rows affected.
            //            affected = command2.ExecuteNonQuery();
            //        }
            //        //NOTE: ExecuteNonQuery used for executing queries that does not return any data. It is used to execute the sql statements like update, insert, delete etc. ExecuteNonQuery executes the command and returns the number of rows affected.

            //        string sqlUpdateString = $"UPDATE CUSTOMERS SET City='Berlin' WHERE CustomerID='MANDA'";

            //        using (var command3 = new SqlCommand(sqlUpdateString, connection))
            //        {
            //            affected = command3.ExecuteNonQuery();
            //        }
            //        using (var updateCustomerCommand = new SqlCommand("UpdateCustomer", connection))
            //        {
            //            // Using System.Data;
            //            updateCustomerCommand.CommandType = CommandType.StoredProcedure;
            //            // add parameters
            //            updateCustomerCommand.Parameters.AddWithValue("@ID", "MANDA");
            //            updateCustomerCommand.Parameters.AddWithValue("@NewName", "Mandela Nilsh");
            //            // run the update
            //            affected = updateCustomerCommand.ExecuteNonQuery();

            //        }
            //        connection.Close();
            //    }
            
            //using (var db = new NorthwindContext())
            //{
            //    Console.WriteLine(db.ContextId);
            //    // Read
            //    // query syntax
            //    foreach(var c in db.Customers)
            //    {
            //        Console.WriteLine($"{c.CompanyName}, {c.CustomerId}");
            //    }
            //    Console.WriteLine("--------------------------------------------------------------------");

            //    // Alternative list (method syntax)

            //    db.Customers.ToList().ForEach(c => Console.WriteLine($"{c.CompanyName}, {c.CustomerId}"));

            //    var selectedCustomer = db.Customers.Where(c=>c.CustomerId=="BLOGG").FirstOrDefault();

            //    if (selectedCustomer != null)
            //    {
            //        db.Customers.RemoveRange(selectedCustomer);
            //    }
            //    db.SaveChanges();

            //    Console.WriteLine("--------------------------------------------------------------------");
            //    db.Customers.ToList().ForEach(c => Console.WriteLine($"{c.CompanyName}, {c.CustomerId}"));
            //    Console.WriteLine("--------------------------------------------------------------------");

            //    var newCustomer = new Customer
            //    {
            //        CustomerId = "BLOGG",
            //        ContactName = "Joe Bloggs",
            //        CompanyName = "UKSA"
            //    };
            //    db.Customers.Add(newCustomer);
            //    db.SaveChanges();

            //    db.Customers.ToList().ForEach(c => Console.WriteLine($"{c.CompanyName}, {c.CustomerId}"));

            //    // UPDATE

            //    selectedCustomer = db.Customers.Where((c) => c.CustomerId == "BLOGG").FirstOrDefault();

            //    if(selectedCustomer != null)
            //    {
            //        selectedCustomer.City = "London";
            //        db.SaveChanges();
            //    }

            //    //alternative find
            //    var p = db.Customers.Find("BLOGG");

            //    Console.WriteLine($"{p.CustomerId}, {p.ContactName}, {p.CompanyName}, {p.City}");
            //    Console.WriteLine("--------------------------------------------------------------------");

            //    //define a query expression
            //    var myQuery = db.Customers.Where(c => c.CustomerId == "BONAP");
            //    //OR
            //    var mySelectedCustomer = db.Customers.Find("BONAP");

            //    // EXECUTE the query

            //    mySelectedCustomer = myQuery.FirstOrDefault(); //without FirstOrDefault myQuery is just an IQuerable<Customer>

            //    IEnumerable<Customer> query3 =
            //        from c in db.Customers
            //        where c.City == "London"
            //        select c;

            //    //iterate - execute the query 
            //    foreach (var c in query3)
            //    {
            //        Console.WriteLine($"Customer {c.GetFullName()} lives in {c.City}");
            //    }

            //    // call an aggregation function - Count, Max, Average, First, FirstOrDefault
            //    int numCustomersInLondon = query3.Count();

            //    //convert to an Array or List
            //    var londonCustomerList = query3.ToList();
            //    var londonCustomerArray = query3.ToArray();

            //    Console.WriteLine(numCustomersInLondon);

            //    // more query syntax
            //    var myList = new List<int> { 2, 5, 6 };
            //    var numQuery = from number in myList select number;
            //    foreach(var c in numQuery)
            //    {
            //        Console.WriteLine($"{c}");
            //    }

            //    IEnumerable<Customer> query4 =
            //       from c in db.Customers
            //       where c.City == "London" || c.City == "Berlin"
            //       orderby c.ContactName ascending
            //       select c;

            //    foreach( var c in query4)
            //    {
            //        Console.WriteLine($"{c.GetFullName()} lives in {c.City}");
            //    }

            //    var query5 =
            //       from c in db.Customers
            //       where c.City == "London" || c.City == "Berlin"
            //       orderby c.ContactName descending
            //       select new { Name = c.CompanyName, Country = c.Country };

            //    //  execute
            //    foreach( var c in query5)
            //    {
            //        Console.WriteLine($"{c.Name}, {c.Country}, {c}");
            //    }

            //    // Create the query.
            //    // The first line could also be written as "var studentQuery ="
            //    IEnumerable<Student> studentQuery =
            //        from student in students
            //        where student.Scores[0] > 90
            //        select student;
            //    Console.WriteLine("--------------------------------------------------------------------");

            //    foreach (Student student in studentQuery)
            //    {
            //        Console.WriteLine("{0}, {1}", student.Last, student.First);
            //    }

            //    var studentQuery2 =
            //        from student in students
            //        group student by student.Last[0];


            //    foreach(var studentGroup in studentQuery2)
            //    {
            //        Console.WriteLine(studentGroup.Key);
            //        foreach(var student in studentGroup)
            //        {
            //            Console.WriteLine("   {0}, {1}",
            //                student.Last, student.First);
            //        }
            //    }

            //    var studentQuery5 =
            //    from student in students
            //    let totalScore = student.Scores[0] + student.Scores[1] +
            //    student.Scores[2] + student.Scores[3]
            //    where totalScore / 4 < student.Scores[0]
            //    select student.Last + " " + student.First;

            //    foreach (string s in studentQuery5)
            //    {
            //        Console.WriteLine(s);
            //    }

            //    var Query4Method = db.Customers.Where(c => c.City == "London").OrderBy(c => c.ContactName);
            //
            //
            //}


            using (var db = new NorthwindContext())
            {
                var ordersQuery = from Order in db.Orders.Include(ord=>ord.Customer).Include(ord=>ord.OrderDetails).ThenInclude(od=>od.Product)
                                  where Order.Freight > 750
                                  select Order;

                foreach(var order in ordersQuery)
                {
                    if(order.Customer != null)
                    {
                        Console.WriteLine($"{order.Customer.ContactName} of {order.Customer.City} paid {order.Freight} for shipping");
                    }
                }
                Console.WriteLine("----------------------------------------------------");
                foreach(var order in ordersQuery)
                {
                    if(order.Customer != null)
                    {
                        Console.WriteLine($"{order.Customer.ContactName} of {order.Customer.City} paid {order.Freight} for shipping");
                    }
                    foreach(var oD in order.OrderDetails)
                    {
                        if(oD.Order != null)
                        {
                            Console.WriteLine($"\tProduct ID: {oD.ProductId}, Product Name: {oD.Product.ProductName}, Quantity: {oD.Quantity}");
                        }
                    }
                }

                Console.WriteLine("----------------------------------------------------");
                var orderQueryUsingJoin = from Ord in db.Orders
                                          where Ord.Freight > 750
                                          join Customer in db.Customers on Ord.CustomerId equals Customer.CustomerId
                                          select new
                                          {
                                              CustomerContactName = Customer.ContactName,
                                              City = Customer.City,
                                              Freight = Ord.Freight
                                          };
                foreach(var result in orderQueryUsingJoin)
                {
                    Console.WriteLine($"{result.CustomerContactName} of {result.City} paid {result.Freight} for shipping");
                }


                int a = 0;
            }
            //end of <using>

        }
    }
}
