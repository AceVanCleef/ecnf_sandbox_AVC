using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib.InheritanceOverriding
{
    public class Manager : Employee
    {
        public string ManagerType { get; }

        private string favoriteFood = "Steak";

        private bool hasADog = true;


        public Manager(string firstname, string lastname, string department, string managertype) 
            : base(firstname, lastname, department)
        {
            ManagerType = managertype;
        }

        public override void PrintPerson()
        {
            Console.WriteLine($"My name is: {base.FirstName} {base.LastName} and I work for the: {Department} Department as a {ManagerType}.");
        }

        public virtual void PrintFavoriteFood()
        {
            Console.WriteLine($"{base.FirstName}'s favorite food is: {favoriteFood}");
            // Note: base.Property works (Property is public)
            //       favoriteFood is private attribute: without override, Person.favoriteFood will be printed.
        }

        public virtual void PrintHasADog()
        {
            Console.WriteLine($"Has {base.FirstName} a dog: {hasADog}. \t used: Manager ___ = new {this.GetType().Name}()");
        }
    }
}
