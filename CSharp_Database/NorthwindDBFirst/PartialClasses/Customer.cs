// See https://aka.ms/new-console-template for more information

namespace NorthwindDBFirst
{
    public partial class Customer
    {
        public string GetFullName()
        {
            return $"{ContactTitle} - {ContactName}";
        }

    }
}