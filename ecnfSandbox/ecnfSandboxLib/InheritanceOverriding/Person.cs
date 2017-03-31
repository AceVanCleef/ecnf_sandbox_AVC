using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib.InheritanceOverriding
{
    public class Person
    {
        private string FirstName;
        private string LastName;

        public Person(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public virtual void PrintPerson()
        {
            Console.WriteLine($"My name is: {FirstName} {LastName}");
        }
    }
}
