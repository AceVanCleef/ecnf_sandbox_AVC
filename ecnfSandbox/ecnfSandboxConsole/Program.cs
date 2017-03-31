using ecnfSandboxLib;
using ecnfSandboxLib.InheritanceOverriding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world");
            /* Executing experiments: */
            ExecuteWhyDelegatesExperiments();
            ExecuteChainedDelegatesExperiments();
            ExecuteEventExperiments();
            ExecuteStructExperiments();
            ExecuteOverrideVirtualExperiments();

            Console.ReadKey();

        }


        /******************** Test Area ***********************/

        private static void ExecuteOverrideVirtualExperiments()
        {
            PrintIntroText("Override - Virtual (Inheritance)");

            /********************** Test Data *********************/
            //Create ofType Person
            Person personA = new Person("(P) Tim", "Meier");
            Person personB = new Employee("(P) Rolf", "Könner", "Finance");
            Person personC = new Manager("(P) Hans", "Vader", "Steering Committee Board", "CEO");

            //introducing more specific ref.types
            Employee personD = new Employee("(E) Walter", "Denzler", "Research");
            Employee personE = new Manager("(E) John", "Travolta", "Research", "Lead Physicist");

            //introducing a most specific ref.type
            Manager personF = new Manager("(M) Cloud", "Strife", "FinalFantasy7", "Infantryman");


            /********************** Testing Area *********************/

            //all 'override'
            Console.WriteLine("\n PrintPerson() \n Combo: override, override, override");
            personA.PrintPerson();
            personB.PrintPerson();
            personC.PrintPerson();
            //using more specific ref.types (Employee)
            personD.PrintPerson();
            personE.PrintPerson();
            //using a most specific ref.type (Manager)
            personF.PrintPerson();

            //all 'virtual'
            Console.WriteLine("\n PrintFavoriteFood() \n Combo: virtual, virtual, virtual");
            personA.PrintFavoriteFood();
            personB.PrintFavoriteFood();
            personC.PrintFavoriteFood();
            //using more specific ref.types (Employee)
            personD.PrintFavoriteFood();
            personE.PrintFavoriteFood();
            //using a most specific ref.type (Manager)
            personF.PrintFavoriteFood();

            //virtual, override, virtual
            Console.WriteLine("\n HasADog() \n Combo: virtual, override, virtual':");
            personA.PrintHasADog();
            personB.PrintHasADog();
            personC.PrintHasADog();
            //using more specific ref.types (Employee)
            personD.PrintHasADog();
            personE.PrintHasADog();
            //using a most specific ref.type (Manager)
            personF.PrintHasADog();

            //virtual vs. new virtual
            Console.WriteLine("\n PrintVirtualVsNewVirtual() \n Combo: 'virtual vs. new virtual':");
            personA.PrintVirtualVsNewVirtual();
            personB.PrintVirtualVsNewVirtual();

            Console.WriteLine("Glossary: \n (P) means 'Person ___ = new Person/Employee/Manager()'." +
                                " \n (E) means 'Employee ___ = new Employee/Manager().'" +
                                " \n (M) means 'Manager ___ = new Manager()'");


            /*                          Fazit:
             * [override, overide, override]
             * 1) Der Konstruktortyp bestimmt, welche Version ausgeführt wird:
             *      Person ___ = new <was hier steht, bestimmt, was ausgeführt wird>()
             *      -> normale Polymorphie
             * 
             * [virtual, virtual, virtual]
             * 1) Der Referenztyp bestimmt, welche Version ausgeführt wird.
             *      <was hier steht, beeinflusst, was ausgeführt wird> ___ = new Person/Employee/Manager()
             * 
             * [virtual, override, virtual]
             * 1) Bei Person ___ = <bel. Konstruktortyp>() fungiert 'override'
             *    als neuer Ankertyp für alle darunter nachfolgenden Kinder.
             * 1.b) Bei virtual, override, virtual, override überschreibt das 
             *      zweite override das vorhergehende.
             * Note: Hier achten, ob Ref.Typ oder Konstruktortyp relevant ist.
             *    
             * [virtual vs. new virtual]
             * - new virtual has no overriding effect.
             * - new is meant to be a diversifier:
             * "So, if you are doing real polymorphism you SHOULD ALWAYS 
             *  OVERRIDE. The only place where you need to use "new" is 
             *  when the method is not related in any way to the base class 
             *  version." (albertein: http://stackoverflow.com/questions/159978/c-sharp-keyword-usage-virtualoverride-vs-new)
             * 
             *  -> This would be appropriate if you create a method with the same name
             *     as the one in the base class, but implement it totally differently.
             *     this way, you set up a NEW INHERITANCE ANCHOR FOR CHILDREN CLASSES.
             **/


            PrintOutroText("Override - Virtual (Inheritance)");
        }


        private static void ExecuteEventExperiments()
        {
            PrintIntroText("Event");
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();

            //EventHandler registrieren:
            publisher.eventSent += subscriber.ReceiveEvent;
            publisher.eventSent += subscriber.IEatEventsTwo;

            //execute customly defined event:
            publisher.Publish();

            /** Event Api  **/
            publisher.ApiEvent += subscriber.ConsumeApiEvent;

            //execute Api defined event:
            publisher.PublishApiEvent();

            /*                          Fazit
          * [Customly Defined Event]
          * 1) delegate definiert Signatur (Rückgabetyp, Parameterliste)
          * 2) Eventhandler müssen die vom delegate vordefinierte Sig erfüllen.
          * 3) EventHandler werden in der Main() o.ä. registriert (event += handlermethod)
          * 4) ob ich "public void MyEvent(object sender, string argument)
          *    oder   "     ...    My Event(object sender, StringEventArgs argObj)
          *    mache, ist mir überlassen. Zweiteres lässt einem mehr Werte übermitteln.
          * 5) by using +=, you can register multiple EventHandlers (= methods)
          * 
          * [Predefined Event API]
          * 1) public event EventHandler<StringEventArgs> ApiEvent; belongs to 
          *    the subscriber and implicitely defines the event signature (see 2) ).
          * 1.b) It saves the 'public delegate void MyEventDefinitioin(...)' - line
          * 2) The EventHandlingMethod must conform this signatur:
          *    - return: void
          *    - parameter list: (object sender, xyEventArgs args)
          *    Note, that sender won't deliver the fields from its 
          *    children class - meaning the publisher.
          *    Possible work around: add the publisher instance to args.
          * 3) Anything else just like @<[Customly Defined Event]
          **/


            PrintOutroText("Event");
        }
        
        private static void ExecuteStructExperiments()
        {
            PrintIntroText("Struct");
            Vector2D_Struct vector1 = new Vector2D_Struct(5, 2);
            Console.WriteLine($"vector1's coordinates are: ({vector1.x}|{vector1.y})");

            //Überschreiben eines Feldes
            vector1.x = 0;
            //Addieren auf einem Feld
            vector1.y += 7;
            Console.WriteLine($"and after changing its values using '=' and '+=': ({vector1.x}|{vector1.y})");

            //Felderinitialisierung ohne Konstruktor
            Vector2D_Struct vector2;
            vector2.x = 15;
            vector2.y = 12;
            Console.WriteLine($"vector2's coordinates are: ({vector2.x}|{vector2.y})." + 
                    "\n You don't have to use a constructor if you... \n 1.) declare the struct instance and \n 2.) initialize its fields where you're going to use it.");

            //operator overloading:
            Vector2D_Struct vector3 = vector1 + vector2;
            Console.WriteLine($"vector3's coordinates using operator+ overloading are: \n " +
                $"({vector1.x}|{vector1.y}) + ({vector2.x}|{vector2.y}) = ({vector3.x}|{vector3.y})");
            vector3 += vector3;
            Console.WriteLine($"vector3 += vector3 = ({vector3.x}|{vector3.y})");

            //Zuweisung:
            vector3 = vector2;
            Console.WriteLine($"'vector3 = vector2' = ({vector3.x}|{vector3.y})");


            /* Fazit:
             * [Innerhalb des Structs]
             * 1) illegal: public int x = 0; -> Error
             * 2) Kontruktor immer mit Parameter! Sonst Error.
             * 3) Operator overloading kann ganz nützlich sein:
             *      vector3 = vector1 + vector2   statt
             *      vector3.x = vector1.x + vector2.x; und das selbe für y.
             * 
             * [Beim Structaufrufer (invoker)]
             * 1) Structfelder initialisieren via Konstruktor oder...
             * 2) ...so:
             *      Vector2D struct;
             *      struct.x = 3; struct.y = 5;
             * 3) Felder können überschrieben werden: vector1.x = 2;
             * 4) Auf Feldern kann gerechnet werden: vector1.x += 7;
             * 
             **/


            PrintOutroText("Struct");
        }


        private static void ExecuteChainedDelegatesExperiments()
        {
            PrintIntroText("ChainedDelegates");
            ChainedDelegates delegateObj = new ChainedDelegates(5, "Tim");
            int calcResult = delegateObj.doMaths(5);
            string concatResult = delegateObj.doConcatination("Tim");

            Console.WriteLine($"using 'int doMaths(int x)' chained delegate: Result = {calcResult}");
            Console.WriteLine($"using 'string doConcatination(string s)' chained delegate: Result = {concatResult}");

            /*                      Fazit:
             * Nur das return der zuletzt angehängten Methode wird vom delegate zurückgegeben.
             * 
             * Frage:
             * Gibt es ein Use Case, in welchem es sinnvoll ist, verkettete delegates zu benutzen?
             * Dabei sollten alle dem delegate angehängten Methoden ausgeführt werden.
             **/
            PrintOutroText("ChainedDelegates");
        }

        public static bool OnlyOfLengthThree(string s)
        {
            return s.Length == 3;
        }

        private static void ExecuteWhyDelegatesExperiments()
        {
            PrintIntroText("WhyDelegates");
            /********** A) WhyDelegates *************/
            Console.WriteLine("WhyDelegates results: ");
            int[] numbers = new[] { 5, 15, 10, 25, 8, 20 };


            /********** B) Exeriment mit externer Methodenreferenzzuweisung *************/
            //Who is the delegate named gauntlet?
            /* Braucht es wohl gar nicht? Könnte direkt WhyDelegates.GreaterThanTen als Param. übergeben */
            WhyDelegates.MeDelegate gauntlet = WhyDelegates.GreaterThanTen;
            IEnumerable<int> result = WhyDelegates.ConsumeDelegate(numbers, gauntlet);
            foreach (int n in result)
            {
                Console.WriteLine($"Using local 'gauntlet = ...' and Foo(numbers, gauntlet): {n}");
            }
            /* Fazit: Machbar, aber wo macht dieser Fall überhaupt Sinn? Hm, vielleicht 
             * bei mehrfacher wiederverwendung von gauntlet.
             **/


            /********** C)WhyDelegatesWithObjects: Experimente mit Objekten *************/
            Console.WriteLine("WhyDelegatesWithObject result:");
            // C) - 1: instanciating object + local static method als Parameter.
            string[] names = new[] { "Tim", "Donald", "Tom", "Ronald", "Anna", "Roger" };
            WhyDelegatesWithObjects delegateObj = new WhyDelegatesWithObjects(names);
            IEnumerable<string> _myStringsL3 = delegateObj.GetNamesOfLength3(OnlyOfLengthThree);
            foreach (string n in _myStringsL3)
            {
                Console.WriteLine($"using local static function as parameter [foo(localStatic)]: {n}");
            }
            /* Fazit: Egal woher, eine Methode kann von beliebig wo übergeben werden.
             *        Wichtig nur, es muss den geforderte Rückgabewerte und 
             *        die Parameterliste erfüllen (siehe if(gauntlet(string))
             **/


            Console.WriteLine("----");


            // C) - 2: Delegate = MethodXY innerhalb der Objektmethode.
            IEnumerable<string> _myStringsL4 = delegateObj.GetNamesOfLength4();
            foreach (string n in _myStringsL4)
            {
                Console.WriteLine($"When delegate was initialized locally within method: {n}");
            }
            /* Fazit: 
             * Delegatezuweisungen können auch innerhalb einer anderswo 
             * befindlichen Methode durchgeführt werden. 
             * Vielleicht etwas schlecht für die Lesbarkeit. Man sieht nicht,
             * was geschieht. */
            Console.WriteLine("----");




            /**** D) Trying: array -> filtered IEnumerable<string> + direct method call by reference ****/
            IEnumerable<string> CollectionByLinq = names.Where(OnlyOfLengthThree);
            foreach (string n in CollectionByLinq)
            {
                Console.WriteLine($"Linq filtered names are: {n} by lenght of {n.Length}");
            }
            /* Fazit: Funktionsreferenz kann direkt übergeben werden *

            /**** E) Objektmethode als Parameter ****/
            IEnumerable<string> namesWithLenghtOfFive = delegateObj.GetNamesOfLength3(delegateObj.LenghtEqualsFive);
            foreach (string name in namesWithLenghtOfFive)
            {
                Console.WriteLine($"Names filtered by Objektmethod as Param [myObj.foo(otherObj.method)]: {name} by lenght of {name.Length}");
            }
            /* Gehen nur statische Funktionen? Können auch Objektmethoden 
             * übergeben werden?   
             * Fazit: Objektmethoden gehen auch. 
             **/

            PrintOutroText("WhyDelegates");
        }

        private static void PrintIntroText(string testname)
        {
            Console.WriteLine($"\n[Executing {testname} Experiments]");
        }

        private static void PrintOutroText(string testname)
        {
            Console.WriteLine($"Leaving {testname} Experiments. \n");
        }
    }
}
