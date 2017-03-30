using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib
{
    /* -------------------------------------------------------------------
     *                              Structs:
     * -------------------------------------------------------------------
     * 
     *   [Why Structs]
     * - encapsulate small groups of related variables
     * - used for small, lightweight objects (an object with few fields)
     * - using many structs is more performant than many classes.
     * 
     *   [Value Type or Reference Type?]
     *   Structs are value type (classes are reference type).
     * 
     *   [What could be potentially used within a struct]
     * - can contain...
     *       constructors                   public MyStruct(a, b)
     *       constants                      readonly int value
     *       fields                         int value
     *       methods                        public void foo()
     *       properties                     public MyProperty { set; get; }
     *       indexers                       public this[index]
     *       operators                      +, -, +=, -=, ==, != overloading
     *       events                         public event Type EventName
     *       and nested types.
     *   But if struct gets too crowded with these stuffs, make it a normal class.
     *   
     *   [inheritance]
     * - can implement interfaces
     * - can't inherit from other structs, nor from classes (except from Object) 
     * - other classes can't inherit from a struct.
     * -> struct members never protected
     * 
     *   [usage tips]
     * - no parameterless constructor: Vector2D_Struct()
     * - initialize struct fields within constructor or individually (when?)
     * - no need to use 'new' to invoke a struct instance -> 
     *   but all fields must be initialized thought for usage
     * - reference type members must be invoked explicitely (use their constructor)
     * - 
     * 
     **/

    public struct Vector2D_Struct
    {
    }
}
