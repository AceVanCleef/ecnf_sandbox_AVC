using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib.InheritanceOverriding
{
    public class Employee : Person
    {
        private string Department;

        public Employee(string firstname, string lastname, string department) : base(firstname, lastname)
        {
            Department = department;
        }

        public override void PrintPerson()
        {
            Console.WriteLine($"base.PrintPerson(){Department}");
            
        }
    }
}
