using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClasses
{
    //The following example shows that nested types can be partial, 
    //even if the type they are nested within is not partial itself.
    internal class Container
    {
        partial class Nested
        {
            void Test() { }
        }
        partial class Nested
        {
            void Test2() { }
        }
    }
}
