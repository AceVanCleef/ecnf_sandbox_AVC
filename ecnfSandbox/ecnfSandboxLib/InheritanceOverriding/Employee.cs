using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib.InheritanceOverriding
{
    public class Employee : Person
    {
        public string Department { get; }


        private string favoriteFood = "Noodles";

        private bool hasADog = false;


        public Employee(string firstname, string lastname, string department) : base(firstname, lastname)
        {
            Department = department;
        }

        public override void PrintPerson()
        {
            Console.WriteLine($"My name is: {base.FirstName} {base.LastName} and I work for the: {Department} Department.");
            
        }

        public virtual void PrintFavoriteFood()
        {
            Console.WriteLine($"{base.FirstName}'s favorite food is: {favoriteFood}");
            // Note: base.Property works (Property is public)
            //       favoriteFood is private attribute: without override, Person.favoriteFood will be printed.
        }

        public override void PrintHasADog()
        {
            Console.WriteLine($"Has {base.FirstName} a dog: {hasADog}. \t used: Employee ___ = new {this.GetType().Name}()");
        }

        public new virtual void PrintVirtualVsNewVirtual()
        {
            Console.WriteLine($"{base.FirstName} reports: Printed 'new virtual void PrintVirtualVsNewVirtual().'");
        }
    }
}
