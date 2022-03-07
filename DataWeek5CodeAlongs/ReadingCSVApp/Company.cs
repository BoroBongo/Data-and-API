using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCSVApp
{
    [Serializable]
    public class Company
    {
        public List<Employees> employees { get;} = new List<Employees>() { };

        public Company(List<Employees> employees)
        {
            this.employees = employees;
        }
    }
}
