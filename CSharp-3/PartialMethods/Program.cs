using System;

namespace PartialMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //It is possible to split the definition of a class, a struct, an interface or a method 
            //over two or more source files.Each source file contains a section of the type or method 
            //definition, and all parts are combined when the application is compiled.

            //When working on large projects, spreading a class over separate files enables multiple 
            //programmers to work on it at the same time.

            //When working with automatically generated source, code can be added to the class without 
            //having to recreate the source file.Visual Studio uses this approach when it creates 
            //Windows Forms, Web service wrapper code, and so on.You can create code that uses these 
            //classes without having to modify the file created by Visual Studio.

            //If any part is declared abstract, then the whole type is considered abstract. 
            //If any part is declared sealed, then the whole type is considered sealed. If any 
            //part declares a base type, then the whole type inherits that class.

            //Important: At compile time, attributes of partial-type definitions are merged. 

            Coordinates coordinates = new Coordinates(20,30);

            coordinates.PlotCoordinates();
        }
    }
}
