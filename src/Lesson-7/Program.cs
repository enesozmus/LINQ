// See https://dotnettutorials.net/course/linq/ for more information
Console.WriteLine("Hello, World!");


#region What is Projection?
/*

  * Projection is nothing but the mechanism which is used to select the data from a data source.

      1. You can select the data in the same form
      2. It is also possible to create a new form of data by performing some operations on it.
*/
#endregion


#region What are Projection Methods or Operators available in LINQ?
/*

  * There are two methods available in projection.
  * They are as follows:

      1. Select
      2. SelectMany
*/
#endregion


#region An example of 'Select()' to understand the topic
Context.LINQDbContext _context = new();

var students = _context.People
                        .Where(x => x.Discriminator == "Student")
                        .Select(x => new { x.FirstName, x.StudentGrades });

// foreach (var student in students)
// {
//   Console.WriteLine("{0}", student.FirstName);
//   foreach (var grade in student.StudentGrades)
//   {
//     Console.WriteLine("\t\t {0} {1}", grade.StudentId, grade.Grade);
//   }
// }
// Console.ReadLine(); 
#endregion


#region SelectMany Operator:
/*

  * The SelectMany in LINQ projects each element of a sequence to an IEnumerable<T> 
  * ...and helps flattens out the collection of collections into one single collection of objects.

  ! Now let use re write the above query using the selectMany

     + 1. In the example below 'People' is the first or outer collection so firstly, We use the SelectMany method on the 'People collection'.

          - var selectMany = _context.People

     + 2. We need to choose the second or inner collection as the first argument to the SelectMany, which is 'StudentGrades'.

          - var selectMany = _context.People
                                      .SelectMany(c => c.StudentGrades);

     + 3. Next, we need to choose the shape of our output using a projection query.


     + 4. The lambda expression gets two arguments.
     
          - The first argument is a reference to the outer collection (People).
          - The second is a reference to the inner collection (StudentGrades).

    + 5. The query returns a single collection

    ! SQL Script
    SELECT
      [p].[FirstName], [p].[LastName], [p].[Discriminator],
      [s].[CourseID] AS [CourseId], [c].[Title], [s].[Grade]
      FROM [Person] AS [p]
      INNER JOIN [StudentGrade] AS [s] ON [p].[PersonID] = [s].[StudentID]
      INNER JOIN [Course] AS [c] ON [s].[CourseID] = [c].[CourseID]
      WHERE [p].[Discriminator] = 'Student';
*/

var selectMany = _context.People
                          .Where(x => x.Discriminator == "Student")
                          .SelectMany(c => c.StudentGrades, (student, grade) => new
                          {
                            student.FirstName,
                            student.LastName,
                            student.Discriminator,
                            grade.CourseId,
                            grade.Course.Title,
                            grade.Grade
                          });

foreach (var item in selectMany)
{
  Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.FirstName, item.LastName, item.Discriminator, item.CourseId, item.Title, item.Grade);
}
Console.ReadLine();
#endregion


#region Linq SelectMany Using Query Syntax
/*

  * The most important point is that there is no such SelectMany operator available in LINQ to write query syntax.
  * But we can achieve this by writing multiple “from clause” in the query as shown in the below example.
*/

var querySyntax = from student in _context.People
                  from grade in student.StudentGrades
                  select new { student.FirstName, grade.Course.Title, grade.Grade };

foreach (var item in querySyntax)
{
  Console.WriteLine("{0} {1} {2}", item.FirstName, item.Title, item.Grade);
}
#endregion


#region Code First
// dotnet add package Microsoft.EntityFrameworkCore --version 6.0.12
// dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.12
// dotnet ef migrations add [name]
// dotnet ef database update
#endregion