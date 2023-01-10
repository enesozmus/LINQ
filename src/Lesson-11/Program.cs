// See https://dotnettutorials.net/course/linq/ for more information
Console.WriteLine("Hello, World!");


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


#region Intersect Operator:
/*

    * The Intersect extension method requires two collections.
    * It returns a new collection that includes common elements that exists in both the collection.

    ! The Intersect extension method doesn't return the correct result for the collection of complex types.
    ! You need to implement IEqualityComparer interface in order to get the correct result from Intersect method.
*/

IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

IEnumerable<string>? result = strList1.Intersect(strList2, StringComparer.OrdinalIgnoreCase);

foreach (string str in result)
  Console.WriteLine(str);
Console.ReadLine();
#endregion


#region Using Anonymous Type for Intersect Operation
IList<Student> studentList1 = new List<Student>() {
        new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
        new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
        new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
    };

IList<Student> studentList2 = new List<Student>() {
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
        new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
    };

var MS = studentList1
                .Select(x => new { x.StudentID, x.StudentName, x.Age })
                .Intersect(studentList2.Select(x => new { x.StudentID, x.StudentName, x.Age }));

foreach (var std in MS)
  Console.WriteLine(std.StudentName);
Console.ReadLine();
#endregion


#region Using IEqualityComparer with Intersect

IEnumerable<Student>? resultedCol = studentList1.Intersect(studentList2, new StudentComparer());

foreach (Student std in resultedCol)
  Console.WriteLine(std.StudentName);

// ! Now, you can pass above StudentComparer class in the Intersect extension method in order to get the correct result:
class StudentComparer : IEqualityComparer<Student>
{
  public bool Equals(Student? x, Student? y)
  {
    if (x?.StudentID == y?.StudentID &&
                    x?.StudentName?.ToLower() == y?.StudentName?.ToLower())
      return true;

    return false;
  }

  public int GetHashCode(Student obj)
  {
    return obj.StudentID.GetHashCode();
  }
}
class Student
{
  public int StudentID { get; set; }
  public string? StudentName { get; set; }
  public int Age { get; set; }
}
#endregion


#region Code First
// dotnet add package Microsoft.EntityFrameworkCore --version 6.0.12
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.12
// dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.12
// dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.12
// dotnet ef migrations add [name]
// dotnet ef database update
#endregion