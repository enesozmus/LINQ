// See https://dotnettutorials.net/course/linq/ for more information
Console.WriteLine("Hello, World!");


Context.LINQDbContext _context = new();


#region What is Filtering?
/*

  * Filtering is nothing but the process to get only those elements from a data source that satisfied the given condition.
  * It is also possible to fetch the data from a data source with more than one condition as per our business requirement.
  * For example:

      1. Employees having a salary greater than 50000.
      2. Students Having Marks greater than 80% from a particular batch.
      3. Employees having experience more than 6 Years and the department is IT, etc.

  ? What are the Filtering methods available in LINQ?

      1. Where        → The Where operator filters the collection based on a predicate function.
      2. OfType       → The OfType operator filters the collection based on a given type
*/
#endregion


#region Where Operator:
/*

  * We can use the where standard query operator in LINQ when we need to filter the data from a data source based on some condition(s).
  * The “where” always expects at least one condition and we can specify the condition(s) using predicates.
  * Returns values from the collection based on a predicate function.
  ½ The criteria can be specified as lambda expression or Func delegate type.
  * The conditions can be written using the following symbols:

    - ==, >=, <=, &&, ||, >, <, etc.

  * There are two overloaded versions of the “where” operator is available.

    - public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
    - public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
*/
#endregion


#region What is a Predicate?
/*

  * A predicate is nothing but a function that is used to test each and every element for a given condition.
  * 

  + In the below example, the Lambda expression (num => num > 5) runs for each and every element present in the “intList” collection.
  + Then it will check, whether the number is greater than 5 or not.
  + If the number value is greater than 5, then a boolean value true is returned otherwise false.

  ½ The Func is a generic delegate that takes one or more input parameters and returns one out parameter.
  ½ The last parameter is considered as the return value.
  ½ The return type is mandatory but the input parameter is not.
  ! https://dotnettutorials.net/lesson/generic-delegates-csharp/
*/
// List
List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//Method Syntax
IEnumerable<int> filteredData = intList.Where(num => num > 5);

//Query Syntax
IEnumerable<int> filteredResult = from num in intList
                                  where num > 5
                                  select num;
#endregion


#region Using multiple conditions

IQueryable<Entities.Person>? students = _context.People
                                                  .Where(x => x.Discriminator == "Student" && x.PersonId < 10);

foreach (var item in students)
{
  Console.WriteLine(item.FirstName);
}
Console.ReadLine();
#endregion


#region OfType Operator:
/*

  * The OfType Operator in LINQ is used to filter specific type data from a data source based on the data type we passed to this operator.
  ½ Returns values from the collection based on a specified type. However, it will depend on their ability to cast to a specified type.
  * For example, if we have a collection that stores both integer and string values and if we need to fetch either only the integer values or only the string values from that collection then we need to use the OfType operator.

    - public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source);

  + Let say, we have a collection of type object.
  + As we know the object class is the superclass of all data types so we can store any type of values in it like below.
  + Now our requirement is to fetch all the integer values from the collection by ignoring the string values.
*/
List<object> dataSource = new List<object>()
{
  "Tom", "Mary", 50, "Prince", "Jack", 10, 20, 30, 40, "James"
};

List<int> intData = dataSource.OfType<int>().ToList();

var stringData = (from name in dataSource
                  where name is string
                  select name).ToList();

foreach (int number in intData)
{
  Console.Write(number + " ");
}
Console.ReadLine();

foreach (string name in stringData)
{
  Console.Write(name + " ");
}
Console.ReadLine();
#endregion


#region OfType and is Operator with a condition
var intDataWithCondition = dataSource.OfType<int>().Where(num => num > 30).ToList();

foreach (int number in intData)
{
  Console.Write(number + " ");
}
Console.ReadLine();

var stringDataWithCondition = (from name in dataSource
                               where name is string && name.ToString()?.Length > 3
                               select name).ToList();
foreach (string name in stringData)
{
  Console.Write(name + " ");
}
Console.ReadLine();
#endregion


#region OfType Examples
var stringResult = from s in dataSource.OfType<string>()
                   select s;
var intResult = from s in dataSource.OfType<int>()
                select s;
foreach (var item in stringResult)
{
  Console.Write(item + " ");
}
Console.WriteLine("over");
#endregion


#region Code First
// dotnet add package Microsoft.EntityFrameworkCore --version 6.0.12
// dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.12
// dotnet ef migrations add [name]
// dotnet ef database update
#endregion