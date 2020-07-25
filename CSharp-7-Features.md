7.1 Features
------------

out variables					- Done
You can declare out values inline as arguments to the method where they're used.

Tuples							- Done
You can create lightweight, unnamed types that contain multiple public fields. Compilers and IDE tools understand the semantics of these types.

Discards						- Done
Discards are temporary, write-only variables used in assignments when you don't care about the value assigned. They're most useful when deconstructing tuples and user-defined types, as well as when calling methods with out parameters.

Pattern Matching				- Done
You can create branching logic based on arbitrary types and values of the members of those types.

ref locals and returns
Method local variables and return values can be references to other storage.

Local Functions					- Done
You can nest functions inside other functions to limit their scope and visibility.

More expression-bodied members	- Done
The list of members that can be authored using expressions has grown.

throw Expressions				- Done
You can throw exceptions in code constructs that previously weren't allowed because throw was a statement.

Generalized async return types
Methods declared with the async modifier can return other types in addition to Task and Task<T>.

Numeric literal syntax improvements
New tokens improve readability for numeric constants.