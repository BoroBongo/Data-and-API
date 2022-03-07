using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCSVApp
{
    [Serializable]
    public class Employees
    {
        public int Emp_ID { get; init; }
        public string NamePrefix { get; init; }
        public string FirstName { get; init; }
        public string MiddleInitial { get; init; }
        public string LastName { get; init; }
        public char Gender { get; init; }
        public string EMail { get; init; }
        public DateTime DateOfBirth { get; init; }
        public DateTime DateOfJoining { get; init; }
        public string Salary { get; init; }

        public Employees(string[] input)
        {
            Emp_ID = int.Parse(input[0]);
            NamePrefix = input[1];
            FirstName = input[2];
            MiddleInitial = input[3];
            LastName = input[4];
            Gender = char.Parse(input[5]);
            EMail = input[6];
            string[] tempDate = input[7].Split("/");
            DateOfBirth = Convert.ToDateTime($"{tempDate[1]}/{tempDate[0]}/{tempDate[2]}");
            tempDate = input[8].Split("/");
            DateOfJoining = Convert.ToDateTime($"{tempDate[1]}/{tempDate[0]}/{tempDate[2]}");
            Salary = input[9];
        }
    }
}
//Emp ID, Name Prefix, First Name, Middle Initial, Last Name, Gender, E Mail, Date of Birth, Date of Joining, Salary
