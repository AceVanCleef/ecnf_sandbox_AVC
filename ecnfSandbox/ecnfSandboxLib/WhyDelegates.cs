using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib
{
    /// <summary>
    /// Source: https://www.youtube.com/watch?v=rxLNJ8jCN1c
    /// </summary>
    public class WhyDelegates
    {
        //define the delegate (?)
        public delegate bool MeDelegate(int n);

        //Who is the delegate named gauntlet?
        //MeDelegate gauntlet = GreaterThanTen; //use it within a method or as obj. attribute
        //or externally: WhyDelegates.MeDelegate gauntlet = WhyDelegates.Function

        //The method using the delegate
        public static IEnumerable<int> ConsumeDelegate(IEnumerable<int> numbers,
            MeDelegate gauntlet)
        {
            foreach (int number in numbers){
                if (gauntlet(number))
                {
                    yield return number;
                }
            }
        }

        //delegateable methods:
        public static bool GreaterThanTen(int x)
        {
            return x > 10;
        }

        public static bool LessThanTen(int x)
        {
            return x < 10;
        }

        public static bool EqualsTen(int x)
        {
            return x == 10;
        }

        public static bool IsMultipleOfTen(int x)
        {
            return x % 10 == 0;
        }
    }
}
