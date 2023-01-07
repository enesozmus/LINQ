// See https://dotnettutorials.net/course/linq/ for more information
Console.WriteLine("Hello, World!");


#region interface IEnumerable

// namespace System.Collections
// {
//   public interface IEnumerable
//   {
//     IEnumerator GetEnumerator();
//   }
// }


/*

  * IEnumerable is an interface that is available in System.Collection namespace.
  * The IEnumerable interface is a type of iteration design pattern. It means we can iterate on the collection of the type IEnumerable.
  ? The IEnumerable interface has one method called GetEnumerator() which will return an IEnumerator that iterates through a collection.

  + Exposes an enumerator, which supports a simple iteration over a non-generic collection.
  + Returns an enumerator that iterates through a collection.

  ? IEnumerator GetEnumerator();  → An System.Collections.IEnumerator object that can be used to iterate through the collection.
*/
#endregion


#region interface IEnumerable<out T> : IEnumerable

// namespace System.Collections.Generic
// {
//   public interface IEnumerable<out T> : IEnumerable
//   { 
//     IEnumerator<T> GetEnumerator();
//   }
// }


/*

  * The IEnumerable interface has also a child generic interface.
  * The IEnumerable<out T> is a generic interface that is available in System.Collection.Generic namespace.
  ! The most important point that you need to remember is,
  ! ...in C#, all the collection classes (both generic and non-generic) implement the IEnumerable interface.

  + Exposes the enumerator, which supports a simple iteration over a collection of a specified type.
  + Returns an enumerator that iterates through the collection.
  ½ T: The type of objects to enumerate.
  ? IEnumerator<T> GetEnumerator()  → An enumerator that can be used to iterate through the collection.

  ! The IEnumerable or IEnumerable<T> interfaces should be used only for in-memory data objects.
*/
#endregion


#region an example to understand C# IEnumerable interface

List<Student> studentList = new List<Student>()
{
  new Student(){ID = 1, Name = "James", Gender = "Male"},
  new Student(){ID = 2, Name = "Sara", Gender = "Female"},
  new Student(){ID = 3, Name = "Steve", Gender = "Male"},
  new Student(){ID = 4, Name = "Pam", Gender = "Female"}
};

// Linq Query to Fetch all students with Gender Male
IEnumerable<Student> QuerySyntax = from student in studentList            // + remember → from (each) obj in IntegerList
                                   where student.Gender == "Male"
                                   select student;

// Iterate through the collection
foreach (var student in QuerySyntax)
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