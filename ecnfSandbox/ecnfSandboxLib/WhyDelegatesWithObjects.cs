using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib
{
    public class WhyDelegatesWithObjects
    {
        public delegate bool MeDelegate(string s);
        public MeDelegate _MyDelegate;

        private string[] _names;

        public WhyDelegatesWithObjects(string[] names)
        {
            _names = names;
        }

        /// <summary>
        /// expects an impementation of bool MeDelegate(string s)
        /// and returns the names based on the delegate implementation.
        /// </summary>
        /// <param name="gauntlet"></param>
        /// <returns></returns>
        public IEnumerable<string> GetNamesOfLength3(MeDelegate gauntlet)
        {
            
            foreach (string name in _names)
            {
                if (gauntlet(name))
                {
                    yield return name;
                }
            }
        }

        public IEnumerable<string> GetNamesOfLength4()
        {
            _MyDelegate = OnlyOfLengthFour;
            //_MyDelegate = gauntlet;
            foreach (string name in _names)
            {
                if (_MyDelegate(name))
                {
                    yield return name;
                }
            }
        }

        public bool LenghtEqualsFive(string s)
        {
            return s.Length == 5;
        }

        public static bool OnlyOfLengthFour(string s)
        {
            return s.Length == 4;
        }
    }
}
