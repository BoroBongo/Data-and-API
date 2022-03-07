using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCSVApp
{
    public class Employees
    {
        private int Emp_ID { get; init; }
        private string NamePrefix { get; init; }
        private string FirstName { get; init; }
        private string MiddleInitial { get; init; }
        private string LastName { get; init; }
        private char Gender { get; init; }
        private string EMail { get; init; }
        private DateTime DateOfBirth { get; init; }
        private DateTime DateOfJoining { get; init; }
        private string Salary { get; init; }

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
