using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp
{
    public class Trainee
    {
        public string? FirstName { get; init; }
        public string LastName { get; init; } = String.Empty;
        public int SpartaNo { get; init; }
        public string FullName => $"{this.FirstName} {this.LastName}";

        public override string? ToString()
        {
            return $"{this.SpartaNo} - {this.FullName}";
        }
    }
}
