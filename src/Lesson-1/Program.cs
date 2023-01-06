// See https://dotnettutorials.net/course/linq/ for more information
Console.WriteLine("Hello, World!");

#region What is Linq?
/*

  * LINQ stands for Language-Integrated Query. 
  * LINQ is a powerful query language that was introduced with .Net 3.5 & Visual Studio 2008.
  * You can use LINQ with C# or VB to query different types of data sources such as SQL, XML, In memory objects, etc.
  * It was introduced by Microsoft with .NET Framework 3.5 and C# 3.0 and is available in System.Linq namespace.
  * LINQ provides us with common query syntax which allows us to query the data from various data sources.

  + The LINQ provider is a software component that lies between the LINQ queries and the actual data source.
  + The Linq provider will convert the LINQ queries into a format that can be understood by the underlying data source.
  + For example, LINQ to SQL provider will convert the LINQ queries to SQL statements which can be understood by the SQL Server database.
  + Similarly, the LINQ to XML provider will convert the queries into a format that can be understood by the XML document.
*/
#endregion


#region What are LINQ Providers?
/*

  * A LINQ provider is software that implements the IQueryProvider and IQueryable interface for a particular data source.
  * In other words, it allows us to write LINQ queries against that data source.
  * If you want to create your custom LINQ provider then it must implement IQueryProvider and IQueryable interface.
  ! Without LINQ Provider we cannot execute our LINQ Queries.

      1. LINQ to Objects
      2. LINQ to SQL
      3. LINQ to Datasets
      4. LINQ to Entities
      5. LINQ to XML:
      6. Parallel LINQ:
*/
#endregion


#region Why should we learn LINQ?
/*

  * Suppose we are developing a .NET Application and that application requires data from different data sources.
  * For example:

      1. The application may need data from SQL Server Database.
          - So as a developer, in order to access the data from SQL Server Database, we need to understand ADO.NET and SQL Server-specific syntaxes. 
          - If the database is Oracle then we need to learn SQL Syntax specific to Oracle Database.
      2. The application also may need data from an XML Document.
          - So as a developer in order to work with XML documents, we need to understand XPath and XSLT queries.
      3. The application also needs to manipulate the data (objects) in memory such as List<Products>, List<Orders>, etc. 
          - So as a developer we should also have to understand how to work with in-memory objects.
  + LINQ provides a uniform common query syntax which allows us to work with different data sources.
  + As a result, we don’t require to learn different syntaxes to query different data sources.
*/
#endregion


#region Advantages of using LINQ?
/*

  * We don’t need to learn new query language syntaxes for different data sources as it provides common query syntax to query different data sources.
  * It provides Compile time error checking as well as intelligence support in Visual Studio. This powerful feature helps us to avoid run-time errors.
  * LINQ provides a lot of inbuilt methods that we can use to perform different operations such as filtering, ordering, grouping, etc. which makes our work easy.
  ! Its query can be reused.
*/
#endregion


#region Ways to Write LINQ Query
/*

  * In order to write a LINQ query, we need the following three things:

      1. Data Source (in-memory objects, SQL, XML)
      2. Query
      3. Execution of the query

  * We can write the LINQ query in three different ways. They are as follows

      1. Query Syntax

          from object in datasource     // + Initialization
          where condition               // + Condition
          select object                 // + Selection

      2. Method Syntax

          datasource.ConditionMethod().SelectionMethod()

      3. Mixed Syntax (Query + Method)

          (from object in datasource where condition select object).Method()
   
  ? From the performance point of view there is no difference between the above three approaches.
  ! But the point that you need to keep in mind is, behind the scene, the LINQ queries written using query syntax are translated into their lambda expressions before they are compiled. 
*/
#endregion


#region Example Using Query Syntax:

// Data Source
List<int> integerList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

IEnumerable<int>? QuerySyntax = from obj in integerList       // + Initialization
                                where obj > 5                 // + Condition
                                select obj;                   // + Selection
// Execution
foreach (var item in QuerySyntax)
{
  Console.Write(item + " ");
}
Console.ReadLine();
#endregion


#region Example Using Method Syntax:

List<int>? MethodSyntax = integerList.Where(obj => obj < 5).ToList();

// Execution
foreach (var item in MethodSyntax)
{
  Console.Write(item + " ");
}
Console.ReadLine();
#endregion


#region Example Using Mixed Syntax:

int MixedSyntax = (from obj in integerList
                   where obj > 5
                   select obj).Sum();

// Execution
Console.Write("Sum Is : " + MixedSyntax);
Console.ReadLine();
#endregion


#region What is a Query?
/*

  * A query is nothing but a set of instructions that are applied to a data source to perform certain operations and then tells the shape of the output from that query.
  * That means the query is not responsible for what will be the output rather it is responsible for the shape of the output.
  * This means what is going to return from that query whether it is going to return a particular value, a particular list, or an object.

  * Each query is a combination of three things. They are as follows:

      1. Initialization (to work with a particular data source)
      2. Condition (where, filter, sorting condition)
      3. Selection (single selection, group selection, or joining)
*/
#endregion