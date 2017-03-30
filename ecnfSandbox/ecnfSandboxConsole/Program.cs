using ecnfSandboxLib;
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

            Console.ReadKey();

        }

        private static void ExecuteEventExperiments()
        {
            Console.WriteLine("\n[Executing Event Experiments]");
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();

            //EventHandler registrieren:
            publisher.eventSent += subscriber.ReceiveEvent;
            publisher.eventSent += subscriber.IEatEventsTwo;

            //execute customly defined event:
            publisher.Publish();

            /********************* Predefined Event API **************************/


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
             **/

            Console.WriteLine("Leaving Event Experiments\n");
        }
        


        private static void ExecuteChainedDelegatesExperiments()
        {
            Console.WriteLine($"\n[Executing Chaineddelegates Experiment]");

            ChainedDelegates delegateObj = new ChainedDelegates(5, "Tim");
            int calcResult = delegateObj.doMaths(5);
            string concatResult = delegateObj.doConcatination("Tim");

            Console.WriteLine($"using 'int doMaths(int x)' chained delegate: Result = {calcResult}");
            Console.WriteLine($"using 'string doConcatination(string s)' chained delegate: Result = {concatResult}");

            /* Fazit:
             * Nur das return der zuletzt angehängten Methode wird vom delegate zurückgegeben.
             * 
             * Frage:
             * Gibt es ein Use Case, in welchem es sinnvoll ist, verkettete delegates zu benutzen?
             * Dabei sollten alle dem delegate angehängten Methoden ausgeführt werden.
             **/
            Console.WriteLine("Leaving ChainedDelegates Experiment \n");

        }

        public static bool OnlyOfLengthThree(string s)
        {
            return s.Length == 3;
        }

        private static void ExecuteWhyDelegatesExperiments()
        {
            Console.WriteLine("\n [Executing WhyDelegates Experiments]");
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

            Console.WriteLine("Leaving WhyDelegatesExperiments \n");
        }
    }
}
