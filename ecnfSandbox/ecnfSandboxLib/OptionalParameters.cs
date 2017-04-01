using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib
{
    /// <summary>
    /// [4 Ways of having optional parameters]
    ///   1) use parameter arrays(params keyword)
    ///   2) Method overloading
    ///   3) Specify parameter defaults
    ///   4) use OptionalAttribute that is present in System.Runtime.InteropServices namespace
    ///   
    ///   In this class, I will focus on 1), 2) and 3).
    /// </summary>
    public class OptionalParameters
    {
        

        public int AddIntegersByParamsArray(int a, int b, params int[] restOfNumbers)
        {
            int sum = a + b;
            if(restOfNumbers != null)
            {
                foreach(int i in restOfNumbers)
                {
                    sum += i;
                }
            }
            return sum;
        }

        public int AddIntsByMethodOverload(int a, int b)
        {
            return a + b;
        }
        /// <summary>
        /// Compared to its brother int Add..(int a, int b), int c is 
        /// the optional parameter.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddIntsByMethodOverload(int a, int b, int c)
        {
            return a + b + c;
        }

        public int AddIntsUsingDefaultParams(int a, int b, int c = 0, int d = 0)
        {
            return a + b + c + d;
        }
    }

}
