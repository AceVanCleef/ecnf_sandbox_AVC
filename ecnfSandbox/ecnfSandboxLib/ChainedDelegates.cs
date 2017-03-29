using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib
{
    public class ChainedDelegates
    {
        public int Number { get; set; }
        public string Astring { get; set; }

        //delegates
        public delegate int ChainedCalculation(int x);
        public delegate string ChainedConcatination(string s);
        public ChainedCalculation doMaths;
        public ChainedConcatination doConcatination;


        public ChainedDelegates (int number, string str)
        {
            Number = number;
            Astring = str;
            doMaths += MultiplyBy5;
            doMaths += AddThree;
            doConcatination += ConcatHello;
            doConcatination += ConcatHowAreYou;
        }

        public int MultiplyBy5(int x)
        {
            return x * 5;
        }

        public int AddThree(int x)
        {
            return x + 3;
        }

        public string ConcatHello(string name)
        {
            return "Hello " + name;
        }

        public string ConcatHowAreYou(string moment)
        {
            return "how are you feeling " + moment;
        }
    }
}
