using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib
{
    /// <summary>
    /// Named parameters are an alternate parameter syntax. They sometimes
    /// result in easier to read and clearer code. They are checked for 
    /// correctness by the compiler. By specifying the formal parameter 
    /// name, we can reorder arguments.
    /// </summary>
    public class NamedParameters
    {
        public void PrintThese(string firstname, string lastname, string hobby, string syntaxmode)
        {
            Console.WriteLine($"My name is {firstname} {lastname} and my hobby is {hobby}. \t Used syntax style: {syntaxmode}.");
        }
    }
}
