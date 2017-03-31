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
     * - encapsulate small groups of related variables (max. 4 integers <= 16 bytes)
     * - used instead of small objects (with few fields) to save memory.
     * - using many structs is more performant than many classes.
     * 
     *   Note: structs are more lightweight than objects (see Value Type or Reference Type).
     * 
     *   [Value Type or Reference Type?]
     *   Structs are value type (classes are reference type).
     *   Note: Value type lives on the stack, 
     *         reference type lives on the heap, 
     *         having a reference to it on the stack.
     *         Structs avoid memory overhead.
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
        public int x;
        public int y; // public int y = 0; -> Error: direct initialization is illegal

        public Vector2D_Struct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2D_Struct operator +(Vector2D_Struct a, Vector2D_Struct b)
        {
            return new Vector2D_Struct(a.x + b.x, a.y + b.y);
        }
    }
}
