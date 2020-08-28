using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            //A query is a set of instructions that describes what data to retrieve from a given 
            //data source(or sources) and what shape and organization the returned data should have. 
            //A query is distinct from the results that it produces.

            //From an application's viewpoint, the specific type and structure of the original 
            //source data is not important. The application always sees the source data as an 
            //IEnumerable<T> or IQueryable<T> collection. For example, in LINQ to XML, the source 
            //data is made visible as an IEnumerable<XElement>.

            //Retrieve a subset of the elements to produce a new sequence without modifying the 
            //individual elements. The query may then sort or group the returned sequence in various 
            //ways, as shown in the following example (assume scores is an int[]):

            IList<int> scores = new List<int> { 16, 2, 34, 50, 60, 75, 80, 85, 90, 92, 200 };

            IEnumerable<int> highScoresQuery =
                                            from score in scores
                                            where score > 80
                                            orderby score descending
                                            select score;

            //Retrieve a sequence of elements as in the previous example but transform them to a new 
            //type of object. For example, a query may retrieve only the last names from certain customer 
            //records in a data source. Or it may retrieve the complete record and then use it to construct 
            //another in-memory object type or even XML data before generating the final result sequence. 
            //The following example shows a projection from an int to a string. Note the new type of highScoresQuery.

            IEnumerable<string> highScoresQuery2 =
                                                from score in scores
                                                where score > 80
                                                orderby score descending
                                                select $"The score is {score}";

            //Or - Here no brackets around the query required.

            IEnumerable<int> highScoresQuery3 =
                                            from score in scores
                                            where score > 80
                                            select score;

            int scoreCount = highScoresQuery3.Count();


            //Retrieve a singleton value about the source data, such as:

            //* The number of elements that match a certain condition.

            //* The element that has the greatest or least value.

            //*The first element that matches a condition, or the sum of particular values in a specified 
            // set of elements.For example, the following query returns the number of scores greater 
            // than 80 from the scores integer array:

            int highScoreCount =
                            (from score in scores
                             where score > 80
                             select score)
                             .Count();

            //Query variable

            //In LINQ, a query variable is any variable that stores a query instead of the results of a 
            //query.More specifically, a query variable is always an enumerable type that will produce 
            //a sequence of elements when it is iterated over in a foreach statement or a direct call 
            //to its IEnumerator.MoveNext method.

            //The following code example shows a simple query expression with one data source, one 
            //filtering clause, one ordering clause, and no transformation of the source elements.
            //The select clause ends the query.

            //scoreQuery is a query variable, which is sometimes referred to as just a query. 
            //The query variable stores no actual result data, which is produced in the foreach loop.
            //And when the foreach statement executes, the query results are not returned through the 
            //query variable scoreQuery.Rather, they are returned through the iteration variable testScore. 
            //The scoreQuery variable can be iterated in a second foreach loop.
            //It will produce the same results as long as neither it nor the data source has been modified.


            // Data source.
            int[] scoresNew = { 90, 71, 82, 93, 75, 82 };

            // Query Expression.
            IEnumerable<int> scoreQuery = //query variable
                                        from score in scoresNew //required
                                        where score > 80 // optional
                                        orderby score descending // optional
                                        select score; //must end with select or group

            //Important
            //Execute the query to produce the results
            foreach (int testScore in scoreQuery)
            {
                Console.WriteLine(testScore);
            }


            //A query variable may store a query that is expressed in query syntax or method syntax, 
            //or a combination of the two. In the following examples, both queryMajorCities and 
            //queryMajorCities2 are query variables:
            //Query syntax

            IList<City> cities = new List<City> { new City {Name="A", Population=1000000 },
                                                  new City {Name="B", Population=10000 },
                                                  new City {Name = "C", Population = 1000 },
                                                  new City {Name = "D", Population = 1000000000 },
                                                  new City {Name = "E", Population = 100000 }};

            //Query syntax
            IEnumerable<City> queryMajorCities =
                                                from city in cities
                                                where city.Population > 100000
                                                select city;

            // Method-based syntax
            IEnumerable<City> queryMajorCities2 = cities.Where(c => c.Population > 100000);


            //On the other hand, the following two examples show variables that are not query 
            //variables even though each is initialized with a query. 
            //They are not query variables because they store results:

            int highestScore =
                                (from score in scores
                                 select score)
                                .Max();

            // or split the expression
            IEnumerable<int> scoreQuery2 =
                from score in scores
                select score;

            int highScoreMax = scoreQuery.Max();
            // the following returns the same result
            int highScoreMax2 = scores.Max();




            IList<Country> countries = new List<Country> {new Country {Name="Country1", Area = 10000000000, Cities= new List<City>{
                                                                                  new City {Name="A", Population=1000000 },
                                                                                  new City {   Name="B", Population=10000 },
                                                                                  new City {   Name = "C", Population = 1000 },
                                                                                  new City {  Name = "D", Population = 1000000000 },
                                                                                  new City {  Name = "E", Population = 100000 }} },

                                       new Country {Name="Country2", Area = 10000000000, Cities= new List<City>{
                                                                                  new City {Name="A", Population=1000000 },
                                                                                  new City {   Name="B", Population=10000 },
                                                                                  new City {   Name = "C", Population = 1000 },
                                                                                  new City {  Name = "D", Population = 1000000000 },
                                                                                  new City {  Name = "E", Population = 100000 }}},

                                       new Country {Name="Country3", Area = 10000000000, Cities= new List<City>{
                                                                                  new City {Name="A", Population=1000000 },
                                                                                  new City {   Name="B", Population=10000 },
                                                                                  new City {   Name = "C", Population = 1000 },
                                                                                  new City {  Name = "D", Population = 1000000000 },
                                                                                  new City {  Name = "E", Population = 100000 }}},

                                       new Country {Name="Country4", Area = 10000000000, Cities= new List<City>{
                                                                                  new City {Name="A", Population=1000000 },
                                                                                  new City {   Name="B", Population=10000 },
                                                                                  new City {   Name = "C", Population = 1000 },
                                                                                  new City {  Name = "D", Population = 1000000000 },
                                                                                  new City {  Name = "E", Population = 100000 }}},

                                       new Country {Name="Country5", Area = 10000000000, Cities= new List<City>{
                                                                                  new City {Name="A", Population=1000000 },
                                                                                  new City {   Name="B", Population=10000 },
                                                                                  new City {   Name = "C", Population = 1000 },
                                                                                  new City {  Name = "D", Population = 1000000000 },
                                                                                  new City {  Name = "E", Population = 100000 }}}

            };

            List<City> largeCitiesList =
                                (from country in countries
                                 from city in country.Cities
                                 where city.Population > 10000
                                 select city).ToList();

            // or split the expression
            IEnumerable<City> largeCitiesQuery =
                                        from country in countries
                                        from city in country.Cities
                                        where city.Population > 10000
                                        select city;

            List<City> largeCitiesList2 = largeCitiesQuery.ToList();



            //Explicit and implicit typing of query variables

            //you can also use the var keyword to instruct the compiler to infer the type of a query 
            //variable (or any other local variable) at compile time. For example, the query example 
            //that was shown previously in this topic can also be expressed by using implicit typing:

            // Use of var is optional here and in all queries.
            // queryCities is an IEnumerable<City> just as
            // when it is explicitly typed.
            var queryCities =
                            from city in cities
                            where city.Population > 100000
                            select city;



            //Starting a query expression

            //A query expression must begin with a from clause.It specifies a data source 
            //together with a range variable. The range variable represents each successive 
            //element in the source sequence as the source sequence is being traversed. The range 
            //variable is strongly typed based on the type of elements in the data source.
            //In the following example, because countries is an array of Country objects, the range variable 
            //is also typed as Country.Because the range variable is strongly typed, you can use the dot 
            //operator to access any available members of the type.

            //The range variable is in scope until the query is exited either with a semicolon or with a continuation clause.

            IEnumerable<Country> countryAreaQuery =
                                        from country in countries
                                        where country.Area > 500000 //sq km
                                        select country;



            //A query expression may contain multiple from clauses. Use additional from clauses when each 
            //element in the source sequence is itself a collection or contains a collection. 
            //For example, assume that you have a collection of Country objects, 
            //each of which contains a collection of City objects named Cities. 
            //To query the City objects in each Country, use two from clauses as shown here:



            IEnumerable<City> cityQuery =
                                    from country in countries
                                    from city in country.Cities
                                    where city.Population > 10000
                                    select city;


            //Ending a query expression

            //A query expression must end with either a group clause or a select clause.

            //group clause

            //Use the group clause to produce a sequence of groups organized by a key that you specify.
            //The key can be any data type.For example, the following query creates a sequence of groups 
            //that contains one or more Country objects and whose key is a char value.

            var queryCountryGroups =
                                    from country in countries
                                    group country by country.Name[0];



            //select clause

            //Use the select clause to produce all other types of sequences.A simple select clause just 
            //produces a sequence of the same type of objects as the objects that are contained in the data source.
            //In this example, the data source contains Country objects. The orderby clause just 
            //sorts the elements into a new order and the select clause produces a sequence of the 
            //reordered Country objects.

            IEnumerable<Country> sortedQuery =
                                            from country in countries
                                            orderby country.Area
                                            select country;

            //The select clause can be used to transform source data into sequences of new types.
            //This transformation is also named a projection. In the following example, 
            //the select clause projects a sequence of anonymous types which contains only a subset 
            //of the fields in the original element.
            //Note that the new objects are initialized by using an object initializer.

            // Here var is required because the query
            // produces an anonymous type.
            var queryNameAndPop =
                from country in countries
                select new { Name = country.Name, Pop = country.Population };


            //Continuations with "into"

            //You can use the into keyword in a select or group clause to create a temporary 
            //identifier that stores a query. Do this when you must perform additional query 
            //operations on a query after a grouping or select operation. In the following example 
            //countries are grouped according to population in ranges of 10 million.After these groups are created, 
            //additional clauses filter out some groups, and then to sort the groups in ascending order. 
            //To perform those additional operations, the continuation represented by countryGroup is required.


            // percentileQuery is an IEnumerable<IGrouping<int, Country>>
            var percentileQuery =
                from country in countries
                let percentile = (int)country.Population / 10_000_000
                group country by percentile into countryGroup
                where countryGroup.Key >= 20
                orderby countryGroup.Key
                select countryGroup;

            // grouping is an IGrouping<int, Country>
            foreach (var grouping in percentileQuery)
            {
                Console.WriteLine(grouping.Key);
                foreach (var country in grouping)
                    Console.WriteLine(country.Name + ":" + country.Population);
            }


            //Filtering, ordering, and joining

            //Between the starting from clause, and the ending select or group clause, 
            //all other clauses(where, join, orderby, from, let) are optional. 
            //Any of the optional clauses may be used zero times or multiple times in a query body.

            //where clause

            //Use the where clause to filter out elements from the source data based on one or more predicate expressions. 
            //The where clause in the following example has one predicate with two conditions.

            IEnumerable<City> queryCityPop =
                from city in cities
                where city.Population < 200000 && city.Population > 100000
                select city;


            //orderby clause

            //Use the orderby clause to sort the results in either ascending or descending order.
            //You can also specify secondary sort orders.The following example performs a primary 
            //sort on the country objects by using the Area property.It then performs a secondary 
            //sort by using the Population property.

            //The ascending keyword is optional; it is the default sort order if no order is specified.

            IEnumerable<Country> querySortedCountries =
                from country in countries
                orderby country.Area, country.Population descending
                select country;


            //join clause

            //Use the join clause to associate and / or combine elements from one data source with elements 
            //from another data source based on an equality comparison between specified keys in each element. 
            //In LINQ, join operations are performed on sequences of objects whose elements are different types. 
            //After you have joined two sequences, you must use a select or group statement to specify which 
            //element to store in the output sequence.You can also use an anonymous type to combine properties 
            //from each set of associated elements into a new type for the output sequence.The following example 
            //associates prod objects whose Category property matches one of the categories in the categories string array.
            //Products whose Category does not match any string in categories are filtered out. The select statement projects 
            //a new type whose properties are taken from both cat and prod.

            //You can also perform a group join by storing the results of the join operation into a 
            //temporary variable by using the into keyword

            //=====Make the code work

            //var categoryQuery =
            //     from cat in categories
            //     join prod in products on cat equals prod.Category
            //     select new { Category = cat, Name = prod.Name };



            //let clause

            //Use the let clause to store the result of an expression, such as a method call, 
            //in a new range variable.In the following example, the range variable firstName stores the first 
            //element of the array of strings that is returned by Split.

            string[] names = { "Svetlana Omelchenko", "Claire O'Donnell", "Sven Mortensen", "Cesar Garcia" };

            IEnumerable<string> queryFirstNames =
                from name in names
                let firstName = name.Split(' ')[0]
                select firstName;

            foreach (string s in queryFirstNames)
            {
                Console.Write(s + " ");
            }

            //Output: Svetlana Claire Sven Cesar


            //Subqueries in a query expression

            //A query clause may itself contain a query expression, which is sometimes referred to as a subquery.
            //Each subquery starts with its own from clause that does not necessarily point to the same 
            //data source in the first from clause.For example, the following query shows a query expression 
            //that is used in the select statement to retrieve the results of a grouping operation.


            //=====Make the code work

            //var queryGroupMax =
            //    from student in students
            //    group student by student.GradeLevel into studentGroup
            //    select new
            //    {
            //        Level = studentGroup.Key,
            //        HighestScore =
            //            (from student2 in studentGroup
            //             select student2.Scores.Average())
            //             .Max()
            //    };










            Console.ReadLine();



            //Source: https://docs.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics
        }
    }
}
