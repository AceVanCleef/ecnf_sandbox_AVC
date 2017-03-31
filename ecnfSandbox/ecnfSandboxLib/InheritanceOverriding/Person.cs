using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib.InheritanceOverriding
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }

        private string favoriteFood = "Apple";

        private bool hasADog = true;

        public Person(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public virtual void PrintPerson()
        {
            Console.WriteLine($"My name is: {FirstName} {LastName}");
        }

        public virtual void PrintFavoriteFood()
        {
            Console.WriteLine($"{FirstName}'s favorite food is: {favoriteFood}");
        }

        public virtual void PrintHasADog()
        {
            Console.WriteLine($"Has {FirstName} a dog: {hasADog}. \t used: Person ___ = new {this.GetType().Name}()");
        }

        public virtual void PrintVirtualVsNewVirtual()
        {
            Console.WriteLine($"{FirstName} reports: Printed 'virtual void PrintVirtualVsNewVirtual().'");
        }
    }
}
