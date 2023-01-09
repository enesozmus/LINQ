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

#region Except Operator:
List<int> dataSource1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
List<int> dataSource2 = new List<int>() { 1, 3, 5, 8, 9, 10 };

IEnumerable<int>? first_example = dataSource1
                                      .Except(dataSource2);

foreach (int item in first_example)
{
  Console.WriteLine(item);
}
Console.WriteLine("first_example");
Console.ReadLine();

string[] dataSource3 = { "India", "USA", "UK", "Canada", "Srilanka" };
string[] dataSource4 = { "india", "UK", "Canada", "France", "Japan" };

IEnumerable<string>? second_example = dataSource3
                                          // .Except(dataSource4);
                                          .Except(dataSource4, StringComparer.OrdinalIgnoreCase);

foreach (string? item in second_example)
{
  // ! In spite of having the country India in the second collection, it still shows in the output.
  // ! This is because the default comparer that is being used to filter the data is case-insensitive.
  // ! So if you want to ignore the case-sensitive then you need to use the other overloaded version of the Except() method which takes IEqualityComparer as an argument.
  Console.WriteLine(item);
}
Console.WriteLine("second_example");
Console.ReadLine();
#endregion


#region Except Operator with Complex Type:
List<Student> Class10tudents = new List<Student>()
{
  new Student {ID = 101, Name = "Preety" },
  new Student {ID = 102, Name = "Sambit" },
  new Student {ID = 103, Name = "Hina"},
  new Student {ID = 104, Name = "Anurag"},
  new Student {ID = 105, Name = "Pranaya"},
  new Student {ID = 106, Name = "Santosh"},
};
List<Student> Class12tudents = new List<Student>()
{
  new Student {ID = 102, Name = "Sambit" },
  new Student {ID = 104, Name = "Anurag"},
  new Student {ID = 105, Name = "Pranaya"},
};

IEnumerable<string?>? third_example = Class10tudents
                                            .Select(x => x.Name)
                                            .Except(Class12tudents.Select(y => y.Name));

foreach (string? item in third_example)
{
  Console.WriteLine(item);
}
Console.WriteLine("third_example");
Console.ReadLine();

var fourth_example = Class10tudents
                            .Select(x => new { x.ID, x.Name })
                            .Except(Class12tudents.Select(x => new { x.ID, x.Name }));

foreach (var item in fourth_example)
{
  Console.WriteLine(item);
}
Console.WriteLine("fourth_example");
Console.ReadLine();
#endregion


#region Using Comparer:
StudentComparer studentComparer = new();

var fifth_example = Class10tudents
                          .Except(Class12tudents, studentComparer);
foreach (var item in fifth_example)
{
  Console.WriteLine($" ID : {item.ID} Name : {item.Name}");
}
Console.WriteLine("fifth_example");
Console.WriteLine("over");
Console.ReadLine();
class StudentComparer : IEqualityComparer<Student>
{
  public bool Equals(Student? x, Student? y)
  {
    //First check if both object reference are equal then return true
    if (object.ReferenceEquals(x, y))
    {
      return true;
    }
    //If either one of the object refernce is null, return false
    if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
    {
      return false;
    }
    //Comparing all the properties one by one
    return x.ID == y.ID && x.Name == y.Name;
  }
  public int GetHashCode(Student obj)
  {
    //If obj is null then return 0
    if (obj == null)
    {
      return 0;
    }
    //Get the ID hash code value
    int IDHashCode = obj.ID.GetHashCode();
    //Get the Name HashCode Value
    int NameHashCode = obj.Name == null ? 0 : obj.Name.GetHashCode();
    return IDHashCode ^ NameHashCode;
  }
}
class Student
{
  public int ID { get; set; }
  public string? Name { get; set; }
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