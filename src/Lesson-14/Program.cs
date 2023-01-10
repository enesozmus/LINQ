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


#region OrderBy & OrderByDescending Operators:
/*

    * OrderBy sorts the values of a collection in ascending or descending order.
    * It sorts the collection in ascending order by default because ascending keyword is optional here.
    ½ Use descending keyword to sort collection in descending order.
*/

List<int> intList = new List<int>() { 10, 45, 35, 29, 100, 69, 58, 50 };

IOrderedEnumerable<int>? intList_ordered = intList.OrderBy(num => num);
IOrderedEnumerable<int>? intList_ordered_desc = intList.OrderByDescending(num => num);


foreach (int number in intList_ordered)
  Console.WriteLine(number);
Console.ReadLine();
#endregion


#region Using LINQ OrderBy & OrderByDescending Operators with Complex type

IList<Student> studentList = new List<Student>() {
    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
    new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
    new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
};

IOrderedEnumerable<Student>? students_ordered = studentList.OrderBy(x => x.StudentName);
IOrderedEnumerable<Student>? students_ordered_desc = studentList.OrderByDescending(x => x.StudentName);


foreach (Student? student in students_ordered_desc)
  Console.WriteLine(student.StudentID + " " + student.StudentName);
Console.ReadLine();


class Student
{
  public int StudentID { get; set; }
  public string? StudentName { get; set; }
  public int Age { get; set; }
}
#endregion