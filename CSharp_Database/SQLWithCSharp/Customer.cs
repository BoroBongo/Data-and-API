// See https://aka.ms/new-console-template for more information
namespace SQLWithCSharp
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string City { get; set; }

        public string GetFullName()
        {
            return $"{ContactTitle} - {ContactName}";
        }

    }
}