using System;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            //References:   https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#pattern-matching
            //              https://docs.microsoft.com/en-us/dotnet/csharp/pattern-matching

            //Pattern matching is a feature that allows you to implement method dispatch on properties 
            //other than the type of an object. You're probably already familiar with method dispatch 
            //based on the type of an object. In object-oriented programming, virtual and override 
            //methods provide language syntax to implement method dispatching based on an object's type. 
            //Base and Derived classes provide different implementations. Pattern matching expressions 
            //extend this concept so that you can easily implement similar dispatch patterns for types 
            //and data elements that aren't related through an inheritance hierarchy.

            //In this code, we'll look at the new syntax to show you how it enables readable, 
            //concise code. Pattern matching enables idioms where data and the code are separated, 
            //unlike object-oriented designs where data and the methods that manipulate them are 
            //tightly coupled.

            //To illustrate these new idioms, let's work with structures that represent geometric 
            //shapes using pattern matching statements. You're probably familiar with building class 
            //hierarchies and creating virtual methods and overridden methods to customize object 
            //behavior based on the runtime type of the object.

            //Those techniques aren't possible for data that isn't structured in a class hierarchy. 
            //When data and methods are separate, you need other tools.The new pattern matching 
            //constructs enable cleaner syntax to examine data and manipulate control flow based on 
            //any condition of that data.You already write if statements and switch that test a 
            //variable's value. You write is statements that test a variable's type. Pattern matching 
            //adds new capabilities to those statements.

            //In this article, you'll build a method that computes the area of different geometric 
            //shapes. But, you'll do it without resorting to object-oriented techniques and 
            //building a class hierarchy for the different shapes.You'll use pattern matching instead. 
            //As you go through this sample, contrast this code with how it would be structured as an 
            //object hierarchy. When the data you must query and manipulate isn't a class hierarchy, 
            //pattern matching enables elegant designs.

            //Pattern matching supports is expressions and switch expressions.Each enables inspecting 
            //an object and its properties to determine if that object satisfies the sought pattern.
            //You use the when keyword to specify additional rules to the pattern.

            //Rather than starting with an abstract shape definition and adding different specific 
            //shape classes, let's start instead with simple data only definitions for each of the
            //geometric shapes:





        }


        //Before C# 7.0, you'd need to test each type in a series of if and is statements:
        //The code is a classic expression of the type pattern: You're testing a variable 
        //to determine its type and taking a different action based on that type.
        public static double ComputeArea(object shape)
        {
            if (shape is Square)
            {
                var s = (Square)shape;
                return s.Side * s.Side;
            }
            else if (shape is Circle)
            {
                var c = (Circle)shape;
                return c.Radius * c.Radius * Math.PI;
            }
            // elided
            throw new ArgumentException(
                message: "shape is not a recognized shape",
                paramName: nameof(shape));
        }

        //This code becomes simpler using extensions to the is expression to assign a 
        //variable if the test succeeds:

        //In this updated version, the is expression both tests the variable and assigns it to a 
        //new variable of the proper type.Also, notice that this version includes the Rectangle type, 
        //which is a struct. The new is expression works with value types as well as reference types.

        //Language rules for pattern matching expressions help you avoid misusing the results of a 
        //match expression.In the example above, the variables s, c, and r are only in scope and 
        //definitely assigned when the respective pattern match expressions have true results.
        //If you try to use either variable in another location, your code generates compiler errors.

        //Let's examine both of those rules in detail, beginning with scope. 
        //The variable c is in scope only in the else branch of the first if statement. 
        //The variable s is in scope in the method ComputeAreaModernIs. 
        //That's because each branch of an if statement establishes a separate scope for variables.
        //However, the if statement itself doesn't. That means variables declared in the if statement 
        //are in the same scope as the if statement (the method in this case.) 
        //This behavior isn't specific to pattern matching, but is the defined behavior for variable 
        //scopes and if and else statements.

        //The variables c and s are assigned when the respective if statements are true because of 
        //the definitely assigned when true mechanism.

        public static double ComputeAreaModernIs(object shape)
        {
            if (shape is Square s)
                return s.Side * s.Side;
            else if (shape is Circle c)
                return c.Radius * c.Radius * Math.PI;
            else if (shape is Rectangle r)
                return r.Height * r.Length;
            // elided
            throw new ArgumentException(
                message: "shape is not a recognized shape",
                paramName: nameof(shape));
        }


        //Using pattern matching switch statements

        //The traditional switch statement was a pattern expression: it supported the constant pattern. 
        //You could compare a variable to any constant used in a case statement:

        public static string GenerateMessage(params string[] parts)
        {
            switch (parts.Length)
            {
                case 0:
                    return "No elements to the input";
                case 1:
                    return $"One element: {parts[0]}";
                case 2:
                    return $"Two elements: {parts[0]}, {parts[1]}";
                default:
                    return $"Many elements. Too many to write";
            }
        }

        //The only pattern supported by the switch statement was the constant pattern. 
        //It was further limited to numeric types and the string type. Those restrictions 
        //have been removed, and you can now write a switch statement using the type pattern:

        public static double ComputeAreaModernSwitch(object shape)
        {
            switch (shape)
            {
                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Rectangle r:
                    return r.Height * r.Length;
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }


        //when clauses in case expressions
        //You can make special cases for those shapes that have 0 area by using a when clause 
        //on the case label.A square with a side length of 0, or a circle with a radius of 0 has a 0 area.
        //You specify that condition using a when clause on the case label:

        public static double ComputeArea_Version3(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                    return 0;

                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }

        //Having added those shapes with 0 area, let's add a couple more shape types: a rectangle and a triangle:
        //This set of changes adds case labels for the degenerate case, and labels and blocks 
        //for each of the new shapes.
        public static double ComputeArea_Version4(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Height == 0:
                    return 0;

                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Triangle t:
                    return t.Base * t.Height / 2;
                case Rectangle r:
                    return r.Length * r.Height;
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }

        //Finally, you can add a null case to ensure the argument isn't null:
        public static double ComputeArea_Version5(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Height == 0:
                    return 0;

                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Triangle t:
                    return t.Base * t.Height / 2;
                case Rectangle r:
                    return r.Length * r.Height;
                case null:
                    throw new ArgumentNullException(paramName: nameof(shape), message: "Shape must not be null");
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }

        //var declarations in case expressions

        //The introduction of var as one of the match expressions introduces new rules to the pattern match.

        //The first rule is that the var declaration follows the normal type inference rules: 
        //The type is inferred to be the static type of the switch expression.From that rule, 
        //the type always matches.

        //The second rule is that a var declaration doesn't have the null check that other type pattern 
        //expressions include. That means the variable may be null, and a null check is necessary in that case.

        //Those two rules mean that in many instances, a var declaration in a case expression matches 
        //the same conditions as a default expression.Because any non-default case is preferred to the 
        //default case, the default case will never execute.

        //The third rule introduces uses where a var case may be useful. Imagine that you're doing a pattern 
        //match where the input is a string and you're searching for known command values. You might write 
        //something like:

        //The var case matches null, the empty string, or any string that contains only white space.
        //Notice that the preceding code uses the ?. operator to ensure that it doesn't accidentally 
        //throw a NullReferenceException. The default case handles any other string values that aren't 
        //understood by this command parser.

        //This is one example where you may want to consider a var case expression that is distinct 
        //from a default expression.

        static object CreateShape(string shapeDescription)
        {
            switch (shapeDescription)
            {
                case "circle":
                    return new Circle(2);

                case "square":
                    return new Square(4);

                case "large-circle":
                    return new Circle(12);

                case var o when (o?.Trim().Length ?? 0) == 0:
                    // white space
                    return null;
                default:
                    return "invalid shape description";
            }
        }


        //Conclusions:
        //Pattern Matching constructs enable you to easily manage control flow among different variables 
        //and types that aren't related by an inheritance hierarchy. 
        //You can also control logic to use any condition you test on the variable. 
        //It enables patterns and idioms that you'll need more often as you build more distributed applications, 
        //where data and the methods that manipulate that data are separate.You'll notice that the shape 
        //structs used in this sample don't contain any methods, just read-only properties.
        //Pattern Matching works with any data type. You write expressions that examine the object, 
        //and make control flow decisions based on those conditions.

        //Compare the code from this sample with the design that would follow from creating a class 
        //hierarchy for an abstract Shape and specific derived shapes each with their own implementation 
        //of a virtual method to calculate the area.You'll often find that pattern matching expressions 
        //can be a very useful tool when you're working with data and want to separate the data storage 
        //concerns from the behavior concerns.


    }
}
