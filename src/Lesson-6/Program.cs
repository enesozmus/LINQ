using Microsoft.EntityFrameworkCore;
Console.WriteLine("Hello, World!");

// See https://dotnettutorials.net/course/linq/ for more information
Lesson6Context _context = new();


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


#region Select Operator:
/*

  * The Select operator always returns an IEnumerable collection which contains elements based on a transformation function.
  * As we know the Select clause in SQL allows us to specify what columns we want to retrieve,
  * ...whether you want to retrieve all the columns or some of the columns that you need to specify the select clause.
  * In the same way, the LINQ Select operator also allows us to specify what properties we want to retrieve,
  * ...whether you want to retrieve all the properties or some of the properties that you need to specify in the select operator.

  + The select operator can be used to formulat the result as per our requirement.
  + It can be used to return a collection of custom class or anonymous type which includes properties as per our need.
*/

IQueryable<Student>? students = _context.Students.Take(10);

foreach (var item in students)
  Console.WriteLine($"NO SELECT - {item.Id} - {item.FirstName} - {item.LastName} ");

Console.ReadLine();

// ! Görüldüğü üzere Student entity'sinin sadece üç property'sine ihtiyacımızın olduğu bir senaryodayız.
// ! Dolayısıyla bu durumda Select Operator'ını kullanabiliriz.

IQueryable<Student>? students2 = _context.Students
                                    .Take(10)
                                    // + Here we are selecting the ID, FirstName and LastName properties
                                    // + to the same Student class using Query Syntax.
                                    .Select(student => new Student
                                    {
                                      Id = student.Id,
                                      FirstName = student.FirstName,
                                      LastName = student.LastName,
                                    });
foreach (var item in students2)
  Console.WriteLine($"SELECT - {item.Id} - {item.FirstName} - {item.LastName} ");

Console.ReadLine();
#endregion


#region How to Select Data to Anonymous Type using LINQ Select Operator?
/*

  * Instead of projecting the data to a particular type like Student or Another, we can also project the data to an anonymous type in LINQ.
*/

var students3 = _context.Students
                            .Take(10)
                            // + Here we are selecting the ID, FirstName and LastName properties
                            // + to the another class using Query Syntax.
                            .Select(student => new
                            {
                              Id = student.Id,
                              FirstName = student.FirstName,
                              LastName = student.LastName,
                            });

foreach (var item in students3)
  Console.WriteLine($"Anonymous - {item.Id} - {item.FirstName} - {item.LastName} ");

Console.ReadLine();
#endregion


#region How to Select Data to another class using LINQ Projection Operator?
/*

  * It is also possible to select the data to another class using the LINQ Select operator.
  * Let us create a new class with the above three properties.
*/

List<Another>? students4 = _context.Students
                                    .Take(10)
                                    // + Here we are selecting the ID, FirstName and LastName properties
                                    // + to the another class using Query Syntax.
                                    .Select(student => new Another()
                                    {
                                      Id = student.Id,
                                      FirstName = student.FirstName,
                                      LastName = student.LastName,
                                    })
                                    .ToList();
foreach (var item in students4)
  Console.WriteLine($"Another - {item.Id} - {item.FirstName} - {item.LastName} ");

Console.ReadLine();
#endregion


#region How to perform calculations on data selected using the LINQ Select Operator?
/*

  * FullName = FirstName + ” ” + LastName
  * AnnualSalary = Salary*12
*/

var selectQuery = from student in _context.Students
                  select new
                  {
                    StudentID = student.Id,
                    FullName = student.FirstName + " " + student.LastName,
                    // AnnualSalary = student.Salary * 12
                  };

foreach (var item in selectQuery)
  Console.WriteLine($"Calculations - {item.StudentID} - {item.FullName}");

Console.ReadLine();
#endregion


#region How to select data with index value?
var selectMethod = _context.Students
                              .ToList()
                              .Select((student, index) => new
                              {
                                IndexPosition = index,
                                FullName = student.FirstName + " " + student.LastName,
                              });

foreach (var item in selectMethod)
  Console.WriteLine($"INDEX - {item.IndexPosition} - {item.FullName}");

Console.ReadLine();
#endregion


#region Simple Example

IList<Nef> listNef = new List<Nef>() {
    new Nef() { ID = 1, Name = "John", Age = 10 },
    new Nef() { ID = 2, Name = "Moin", Age = 11 },
    new Nef() { ID = 3, Name = "Bill", Age = 12 },
    new Nef() { ID = 4, Name = "Ram", Age = 13},
    new Nef() { ID = 5, Name = "Ron", Age = 14 }
};

IEnumerable<string>? names = from s in listNef
                             select s.Name;

foreach (string name in names)
{
  Console.WriteLine(name);
}
Console.ReadLine();
#endregion


#region Using Query Syntax
// List<Student>? students_query_syntax = (from student in _context.Students select student).ToList();
// List<string>? students_query_syntax = (from student in _context.Students select student.FirstName).ToList();
// List<Student>? students_query_syntax = (from student in _context.Students select new Student { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName }).ToList();
// List<Another>? students_query_syntax = (from student in _context.Students select new Another { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName }).ToList();
// var students_query_syntax = (from student in _context.Students select new { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName }).ToList();
#endregion


#region Entity and Context
public class Nef
{
  public int ID { get; set; }
  public string? Name { get; set; }
  public int Age { get; set; }
}
class Another
{
  public int Id { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
}
class Student
{
  public int Id { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? Gender { get; set; }
}
class Lesson6Context : DbContext
{

  public Lesson6Context() { }
  public Lesson6Context(DbContextOptions<Lesson6Context> options) : base(options) { }

  public DbSet<Student> Students { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer("Data Source=DESKTOP-OPFJQHD; Database=Lesson6DB; Integrated Security=True;");
    }
  }
}
#endregion


#region Code First
// dotnet add package Microsoft.EntityFrameworkCore --version 6.0.12
// dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.12
// dotnet ef migrations add [name]
// dotnet ef database update
// ! Please use the below SQL Script to populate the Student table with the required test data.
// INSERT INTO Students VALUES ('Steve', 'Smith', 'Male');
// INSERT INTO Students VALUES ('Sara', 'Pound', 'Female');
// INSERT INTO Students VALUES ('Ben', 'Stokes', 'Male');
// INSERT INTO Students VALUES ('Jos', 'Butler', 'Male');
// INSERT INTO Students VALUES ('Pam', 'Semi', 'Female');
#endregion