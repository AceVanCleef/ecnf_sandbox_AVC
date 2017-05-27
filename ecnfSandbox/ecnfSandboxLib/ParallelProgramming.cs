using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ecnfSandboxLib
{
    public class ParallelProgramming
    {

        private static int[] CalculatePrimesSequential(int range)
        {
            var results = new List<int>();
            for (var number = 3; number < range; number++)
            {
                var foundPrime = true;
                for (var divisor = 2; divisor * divisor <= number; divisor++)
                    if (number % divisor == 0) foundPrime = false;
                if (foundPrime) results.Add(number);
            }
            return results.ToArray();
        }

        private static int[] CalculatePrimesMultithreadedManual(int range)
        {

            var barrier = new Barrier(2);
            var results = new ConcurrentBag<int>();

            //todo


            return results.ToArray();
        }

        //public static int[] CalculatePrimeAsMultirheadedByPLING(int range)
        //{
        //    IEnumerable<int> numbers = Enumerable.Range(3, range);
        //    var results = numbers.AsParallel()
        //        .Where(??)
        //        .ToArray();

        //    return results;
        //}
    }
}
