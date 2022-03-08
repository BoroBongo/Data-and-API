// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

namespace SQLWithCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //List where we will eventually add customer objects to
            var customers = new List<Customer>();

            var newCustomer = new Customer()
            {
                CustomerID = "MANDA",
                ContactName = "Nish Mandal",
                City = "Birmingham",
                CompanyName = "ToysRUs"
            };

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                //Testing our connection is open
                connection.Open();
                Console.WriteLine(connection.State);

                using (var command = new SqlCommand("select cs.CustomerID, cs.ContactName, cs.CompanyName, cs.City, cs.ContactTitle from Customers cs", connection))
                {
                    //command.Connection = connection;
                    //SQL reader Provides a way of reading a forward-only stream of rows from a SQL Server database. 
                    SqlDataReader sqlReader = command.ExecuteReader();

                    // loop while the reader has more data to read. The typical method of reading from the data stream returned by the SqlDataReader is to iterate through each row with a while loop
                    while (sqlReader.Read())
                    {

                        //creating variables for customer
                        var customerID = sqlReader["CustomerID"].ToString();
                        var contactName = sqlReader["ContactName"].ToString();
                        var companyName = sqlReader["CompanyName"].ToString();
                        var city = sqlReader["City"].ToString();
                        var contactTitle = sqlReader["ContactTitle"].ToString();

                        //new customer object
                        var customer = new Customer() { ContactTitle = contactTitle, CustomerID = customerID, ContactName = contactName, City = city, CompanyName = companyName };

                        customers.Add(customer);
                    }

                    // iterate over and output all customers
                    foreach (var c in customers)
                    {
                        Console.WriteLine($"Customer {c.GetFullName()} has ID {c.CustomerID} and lives in {c.City}");
                    }
                    // Close the reader
                    sqlReader.Close();
                }
                string sqlDeleteString = $"DELETE from Customers where CustomerID = 'MANDA'";
                int affected = 0;
                using (var command4 = new SqlCommand(sqlDeleteString, connection))
                {
                    // if successful, this should equal 1
                    affected = command4.ExecuteNonQuery();
                }
                string sqlString = $"INSERT INTO Customers(CustomerID, ContactName, City, CompanyName) VALUES ('{newCustomer.CustomerID}', '{newCustomer.ContactName}', '{newCustomer.City}','{newCustomer.CompanyName}')";
                // execute insert SQL command
                using (var command2 = new SqlCommand(sqlString, connection))
                {
                    //Executes a Transact-SQL statement against the connection and returns the number of rows affected.
                    affected = command2.ExecuteNonQuery();
                }
                //NOTE: ExecuteNonQuery used for executing queries that does not return any data. It is used to execute the sql statements like update, insert, delete etc. ExecuteNonQuery executes the command and returns the number of rows affected.

                //    string sqlUpdateString = $"?????";

                //    using (var command3 = new SqlCommand(sqlUpdateString, connection))
                //    {
                //        affected = command3.ExecuteNonQuery();
                //    }
                //    using (var updateCustomerCommand = new SqlCommand("UpdateCustomer", connection))
                //    {
                //        // Using System.Data;
                //        updateCustomerCommand.CommandType = CommandType.StoredProcedure;
                //        // add parameters
                //        updateCustomerCommand.Parameters.AddWithValue("???, ???");
                //        updateCustomerCommand.Parameters.AddWithValue("???", "???");
                //        // run the update
                //        affected = updateCustomerCommand.ExecuteNonQuery();

                //    }
                connection.Close();
        }


    }
    }
}
