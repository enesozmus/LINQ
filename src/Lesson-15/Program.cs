// See https://dotnettutorials.net/course/linq/ for more information
Console.WriteLine("Hello, World!");


#region What Are Ordering Operators?
/*
    
    * In simple terms, we can say that Ordering is nothing but a process to manage the data in a particular order.
    * A sorting operator arranges the elements of the collection in ascending or descending order.
    * It is not changing the data or output rather this operation arranges the data in a particular order i.e. either ascending order or descending order.
    * For example

        - Name of Cities of a particular state in alphabetical order.
        - Students order by Roll Number in a class.
        - It is also possible to order based on multiple columns like Employee First and Last Name in ascending order while the Salary is on descending order.

    * There are five methods provided by LINQ to sort the data.
    * They are as follows:

        1. OrderBy
            - Sorts the elements in the collection based on specified fields in ascending or decending order.
        2. OrderByDescending
            - Sorts the collection based on specified fields in descending order.
        3. ThenBy
            - Used for second level sorting in ascending order.
        4. ThenByDescending
            - Used for second level sorting in descending order.
        5. Reverse
            - Sorts the collection in reverse order.
*/
#endregion


#region ThenBy & ThenByDescending Operators:
/*

    * The ThenBy and ThenByDescending extension methods are used for sorting on multiple fields.
    ! The LINQ OrderBy or OrderByDescending method works fine when you want to sort the data based on a single value or a single expression.
    ! But if you want to sort the data based on multiple values or multiple expressions then you need to use the LINQ ThenBy and ThenByDescending Method along with OrderBy or OrderByDescending Method.
    * LINQ will first sort the collection based on primary field which is specified by OrderBy method and then sort the resulted collection in ascending order again based on secondary field specified by ThenBy method.
    ½ The same way, use ThenByDescending method to apply secondary sorting in descending order.

*/
IList<Student> studentList = new List<Student>() {
    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
    new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
    new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 },
    new Student() { StudentID = 6, StudentName = "Ram" , Age = 18 },
    new Student() { StudentID = 6, StudentName = "Ram" , Age = 5 }
};

IOrderedEnumerable<Student>? thenByResult = studentList
                                                    .OrderBy(s => s.StudentName)
                                                    .ThenBy(s => s.Age);

IOrderedEnumerable<Student>? thenByDescResult = studentList
                                                    .OrderBy(s => s.StudentName)
                                                    .ThenByDescending(s => s.Age);

foreach (var item in thenByResult)
  Console.WriteLine(item.StudentName + " " + item.Age);
Console.ReadLine();
#endregion


#region Reverse Operator:
/*

    * The LINQ Reverse method is used to reverse the data stored in a data source.
    * So, as a result, we will get the output in reverse order.
    ½ The LINQ Reverse Method in C# will return the data as IEnumerable<TSource> or IQuereable<TSource> based on how we use the LINQ method.
*/
int[] intArray = new int[] { 10, 30, 50, 40, 60, 20, 70, 100 };

IEnumerable<int> ArrayReversedData = intArray
                                        .Reverse();

foreach (var number in ArrayReversedData)
  Console.Write(number + " ");
Console.ReadLine();

List<string> stringList = new List<string>() { "Preety", "Tiwary", "Agrawal", "Priyanka", "Dewangan" };

// ! You cannot store the data like below as this method belongs to System.Collections.Generic namespace whose return type is void
// IEnumerable<int> ArrayReversedData = stringList.Reverse();

stringList.Reverse();
foreach (var name in stringList)
  Console.Write(name + " ");
Console.ReadLine();
#endregion


#region How to apply the Linq Reverse method on a collection of List<T> type?
/*

    * If you want to apply the Reverse method which belongs to System.Linq namespace on a collection of type List<T>, then first you need to convert to the List<T> collection to as IEnumerable or IQueryable collection by using the AsEnumerable() or AsQueryable() method on the data source.
    ½ If you use the AsEnumerable() method then it will convert the collection to IEnumerable whereas if you use AsQueryable() method then it will convert the collection to IQueryable.
    ! The following program shows how to apply the Linq Reverse method on a collection of type List<T>:
*/
IEnumerable<string> ReverseData1 = stringList.AsEnumerable().Reverse();
IQueryable<string> ReverseData2 = stringList.AsQueryable().Reverse();

foreach (var name in ReverseData1)
  Console.Write(name + " ");
Console.ReadLine();

class Student
{
  public int StudentID { get; set; }
  public string? StudentName { get; set; }
  public int Age { get; set; }
}
#endregion