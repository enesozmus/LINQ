// See https://dotnettutorials.net/course/linq/ for more information
Console.WriteLine("Hello, World!");


Context.LINQDbContext _context = new();


#region Set Operators in LINQ:
/*

  * In LINQ, Set Operators are useful to return result set based on the presence or absence of equivalent elements within the same or separate collections.
  + Set operations in LINQ refer to query operations that produce a result set that is based on the presence or absence of equivalent elements within the same or separate collections (or sets).
  * These set operators will perform different operators like removing duplicate elements from the collections or combining all the elements of collections, or leaving some elements from the collection based on our requirements.
  * In LINQ, we have different types of set operators available those are:

      1. UNION
          - It combines multiple collections into a single collection and returns a resultant collection with unique elements.
          - This method is used to return all the elements which are present in either of the data sources.
          - That means it combines the data from both the data sources and produce a single result set.
      2. INTERSECT
          - Returns the set intersection, which means elements that appear in each of two collections.
          - It returns sequence elements that are common in both the input sequences.
          - This method is used to return the common elements from both the data sources i.e. the elements which exist in both the data set are going to returns as output.
      3. DISTINCT & DISTINCTBY
          - It removes duplicate elements from the collection and returns them with unique values.
          - We need to use the Distinct() method when we want to remove the duplicate data or records from a data source.
          - This method operates on a single data source.
      4. EXCEPT
          - Returns the set difference, which means the elements of one collection that do not appear in a second collection.
          - It returns sequence elements from the first input sequence not present in the second input sequence.
          - We need to use the Except() LINQ Extension method when we want to return all the elements from the first data source which do not exists in the second data source.
          - This method operates on two data sources.
*/
#endregion


#region Examples of Set Operations:
/*

  1. If we need to select the distinct records from a data source (No Duplicate Records) then we need to use Set Operators.
  2. Suppose we need to select all the Employees of a company except a particular department then you need to use Set Operations.
  3. If you have multiple classes and you want only to select all the toppers from all the classes then also you need to use Set Operations.
  4. Suppose we have different data sources with similar structure and if we want to combine all the data sources into a single data source then we need to use Set Operations.
*/
#endregion


#region Distinct Operator:
/*

  * public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source);
  * public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource>? comparer);
  
  + The one and the only difference between these two methods is the second overloaded version takes an IEqualityComparer as input which means the Distinct Operator can also be used with Comparer also.
*/
string[] planets = { "Mercury", "Venus", "Venus", "Venus", "Earth", "Mars", "Earth" };

IEnumerable<string> query = from planet in planets.Distinct()
                            select planet;

foreach (var str in query)
{
  Console.WriteLine(str);
}
Console.ReadLine();
#endregion


#region Distinct Operator with Complex Type

IQueryable<string>? students_unique_names = _context.People
                                                      .Select(x => x.FirstName)
                                                      .Distinct();

int x = 0;
foreach (string? name in students_unique_names)
{
  // veritabanımız 34 kişi olmasına rağmen 27 ad döner
  x = x + 1;
  Console.WriteLine("{0} {1}", x, name);
}
Console.ReadLine();
#endregion


#region IEqualityComparer<in T> Interface
/*

  ? IEqualityComparer<in T>             → Defines methods to support the comparison of objects for equality.
  ? IEqualityComparer                   → Defines methods to support the comparison of objects for equality.
  ? StringComparer                      → Represents a string comparison operation that uses specific case and culture-based or ordinal comparison rules.
  ? StringComparer.OrdinalIgnoreCase    → Gets a System.StringComparer object that performs a case-insensitive ordinal string comparison.

  ! The default comparer, which is used to filter the duplicate values is case-sensitive.
  ! If you want to make the comparison to be case-insensitive then you need to use the other overloaded version which takes IEqualityComparer as an argument.
  ! So here we need to pass a class that must implement the IEqualityComparer interface.

  * public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource>? comparer);
  
*/
string[] namesArray = { "Priyanka", "HINA", "hina", "Anurag", "Anurag", "ABC", "abc" };

IEnumerable<string>? distinctNames = namesArray.Distinct(StringComparer.OrdinalIgnoreCase);

foreach (string? name in distinctNames)
{
  Console.WriteLine(name);
}
Console.ReadLine();
#endregion


#region Code First
// dotnet add package Microsoft.EntityFrameworkCore --version 6.0.12
// dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.12
// dotnet ef migrations add [name]
// dotnet ef database update
#endregion