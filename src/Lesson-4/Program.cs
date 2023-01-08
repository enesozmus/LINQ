using Microsoft.EntityFrameworkCore;
Console.WriteLine("Hello, World!");

// See https://dotnettutorials.net/course/linq/ for more information
Lesson4Context _context = new();


#region Differences between IEnumerable and IQueryable in C#:
/*

  * The IEnumerable and IQueryable interfaces are used to hold a collection of data and also used to perform data manipulation operations such as filtering, ordering, grouping, etc. based on the business requirements.


  ½ While querying the data from the database, the IEnumerable executes the “select statement” on the server-side (i.e. on the database), loads data into memory on the client-side, and then only applied the filters on the retrieved data.
  + While querying the data from a database, the IQueryable executes the “select query” with the applied filter on the server-side i.e. on the database and then retrieves data.
  
  ½ So you need to use the IEnumerable when you need to query the data from in-memory collections like List, Array, and so on.
  + So you need to use the IQueryable when you want to query the data from out-memory such as remote database, service, etc.
  
  ½ The IEnumerable is mostly used for LINQ to Object and LINQ to XML queries.
  + IQueryable is mostly used for LINQ to SQL and LINQ to Entities queries.

  ½ IEnumerable supports deferred execution.
  + IQueryable supports deferred execution.
  + It also supports custom queries using CreateQuery and Executes methods.
  + IQueryable supports lazy loading and hence it is suitable for paging-like scenarios.

  ? The IEnumerable collection is of type forward only. That means it can only move in forward, it can’t move backward and between the items.
  ? The collection of type IQueryable can move only forward, it can’t move backward and between the items.
*/
#endregion


#region worth to be read - summary
// 1
Microsoft.EntityFrameworkCore.DbSet<Student>? students_1 = _context.Students;

// 2
IQueryable<Student>? students_2 = _context.Students.Where(x => (x.Id > 0) && (x.Gender == "Male"));

// 3
IQueryable<Student>? students_3 = _context.Students.Where(x => x.Id > 0).Take(2);

// 4
IQueryable<Student>? students_4 = _context.Students.Where(x => x.Id > 0).AsQueryable().Take(2);

/*

  ! Türünü direkt IEnumerable<T> olarak ayarlayıp instance'ı üzerinden hareket etmedikçe
  ! ya da AsEnumerable() & ToList() kullanımının sonrasında değilsek
  ! DbSet<T> ya da IQueryable<T> durumunda olduğumuzun farkında olmalıyız


  + IQueryable ile yapılan sorgulama çalışmalarında, SQL hedef verileri elde edecek şekilde generate edilecekken,
  + IEnumerable ile yapılan sorgulama çalışmalarında SQL daha geniş verileri getirebilecek şekilde execute edilecektir.
  + IEnumerable kullanımında filtreleme işlemleri in-memory'de yapılır.
*/

// 5
IEnumerable<Student>? students_5 = _context.Students.AsEnumerable().Where(x => x.Id > 0).Take(2);

// 6
IEnumerable<Student>? students_6 = _context.Students.ToList().Where(x => x.Id > 0).Take(2);


// + Iterate through the collection
foreach (var item in students_1)
  Console.WriteLine(item.Id + " " + item.FirstName);

Console.ReadLine();
#endregion


#region Using DbSet<Student>

Microsoft.EntityFrameworkCore.DbSet<Student>? students_DbSet = _context.Students;

/*

  SELECT
  [s].[ID], [s].[FirstName], [s].[Gender], [s].[LastName]
  FROM [Student] AS [s]

*/
#endregion


#region Using IEnumerable

IEnumerable<Student>? students_IEnumerable_1 = _context.Students.AsEnumerable().Where(x => x.Id > 0).Take(2);
IEnumerable<Student>? students_IEnumerable_2 = _context.Students.ToList().Where(x => x.Id > 0).Take(2);

/*

  SELECT
  [s].[ID], [s].[FirstName], [s].[Gender], [s].[LastName]
  FROM [Student] AS [s]

*/
#endregion


#region Using IQueryable

IQueryable<Student>? students_IQueryable_1 = _context.Students.Where(x => (x.Id > 0) && (x.Gender == "Male")).Take(2);
IQueryable<Student>? students_IQueryable_2 = _context.Students.Where(x => x.Id > 0).Take(2);
IQueryable<Student>? students_IQueryable_3 = _context.Students.Where(x => x.Id > 0).AsQueryable().Take(2);

/*

  SELECT TOP(2)
  [s].[ID], [s].[FirstName], [s].[Gender], [s].[LastName]
  FROM [Student] AS [s]
  WHERE ([s].[ID] > 0) AND ([s].[Gender] = 'Male');

  SELECT TOP(2)
  [s].[ID], [s].[FirstName], [s].[Gender], [s].[LastName]
  FROM [Student] AS [s]
  WHERE [s].[ID] > 0;

*/
#endregion


#region Entity and Context
class Student
{
  public int Id { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? Gender { get; set; }
}
class Lesson4Context : DbContext
{

  public Lesson4Context() { }
  public Lesson4Context(DbContextOptions<Lesson4Context> options) : base(options) { }

  public DbSet<Student> Students { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer("Data Source=DESKTOP-OPFJQHD; Database=Lesson4DB; Integrated Security=True;");
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