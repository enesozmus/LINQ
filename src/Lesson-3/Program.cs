// See https://dotnettutorials.net/course/linq/ for more information
Console.WriteLine("Hello, World!");

#region interface IQueryable : IEnumerable

// namespace System.Linq
// {
//   public interface IQueryable : IEnumerable
//   { 
//     Type ElementType { get; } 
//     Expression Expression { get; } 
//     IQueryProvider Provider { get; }
//   }
// }


/*

  * IQueryable is an interface that is available in System.Linq namespace.
  * The IQuerable interface is a child of the IEnumerable interface.
  * So we can store IQuerable in a variable of type IEnumerable.
  * The IQuerable interface has a property called Provider which is of type IQueryProvider interface.
  * The methods provided by the IQueryProvider are used to create all Linq Providers.
  * So, this is the best choice for other data providers such as Linq to SQL, Linq to Entities, etc.

  + Provides functionality to evaluate queries against a specific data source wherein the type of the data is not specified.

  ? Type ElementType { get; }         → Gets the type of the element(s) that are returned when the expression tree associated with this instance of System.Linq.IQueryable is executed.
  ?                                   → Returns a System.Type that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.

  ? Expression Expression { get; }    → Gets the expression tree that is associated with the instance of System.Linq.IQueryable.
  ?                                   → Returns the System.Linq.Expressions.Expression that is associated with this instance of System.Linq.IQueryable.

  ? IQueryProvider Provider { get; }  → Gets the query provider that is associated with this data source.
  ?                                   → Returns the System.Linq.IQueryProvider that is associated with this data source.
*/
#endregion


#region  interface IQueryable<out T> : IEnumerable<T>, IEnumerable, IQueryable

// namespace System.Linq
// {   
//   public interface IQueryable<out T> : IEnumerable<T>, IEnumerable, IQueryable
//   {
//   }
// }


/*

  * The IQueryable<out T> is a generic interface that is available in System.Linq namespace.
  + Provides functionality to evaluate queries against a specific data source wherein the type of the data is known.
  ½ T: The type of the data in the data source.
*/
#endregion


#region an example to understand C# IQueryable interface
List<Student> studentList = new List<Student>()
{
    new Student(){ID = 1, Name = "James", Gender = "Male"},
    new Student(){ID = 2, Name = "Sara", Gender = "Female"},
    new Student(){ID = 3, Name = "Steve", Gender = "Male"},
    new Student(){ID = 4, Name = "Pam", Gender = "Female"}
};

//Linq Query to Fetch all students with Gender Male
IQueryable<Student> MethodSyntax = studentList
                                      .AsQueryable()
                                      .Where(std => std.Gender == "Male");

//Iterate through the collection
foreach (var student in MethodSyntax)
{
  Console.WriteLine($"ID : {student.ID}  Name : {student.Name}");
}

Console.ReadLine();

public class Student
{
  public int ID { get; set; }
  public string? Name { get; set; }
  public string? Gender { get; set; }
}
#endregion