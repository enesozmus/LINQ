// See https://dotnettutorials.net/course/linq/ for more information
Console.WriteLine("Hello, World!");


#region What are Linq Aggregate Functions in C#?
/*
    
    * The LING aggregate functions are used to group together the values of multiple rows as the input and then return the output as a single value.
    * So, simple word, we can say that the aggregate function in C# is always going to return a single value.
    * The following are the aggregate methods provided by Linq to perform mathematical operations on a collection:

        1. Sum()
            - Calculates sum of the values in the collection.
        2. Max()
            - Finds the largest value in the collection.
        3. Min()
            - Finds the smallest value in the collection.
        4. Average():
            - Calculates the average of the numeric items in the collection.
        5. Count():
            - Counts the elements in a collection.
            - Counts the number of elements that have satisfied a given condition.
        6. Aggregate()
            - Performs a custom aggregation operation on the values in the collection.
*/
#endregion


#region Max & Min Operator:
IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };

int largest = intList
                .Max();
int minimum = intList
                .Min();
Console.WriteLine("Largest Element: {0}", largest);
Console.WriteLine("Smallest Element: {0}", minimum);
Console.ReadLine();

// example
int largest2 = intList
                        .Where(num => num < 50)
                        .Max();
Console.WriteLine("Largest number less than 50: {0}", largest2);
Console.ReadLine();

// example
var largestEvenElements = intList.Max(i =>
                                        {
                                          if (i % 2 == 0)
                                            return i;

                                          return 0;
                                        });
Console.WriteLine("Largest Even Element: {0}", largestEvenElements);
Console.ReadLine();

// example
IList<Student> studentList = new List<Student>() {
    new Student() { StudentID = 1, StudentName = "John", Age = 13 },
    new Student() { StudentID = 2, StudentName = "Christopher", Age = 24 },
    new Student() { StudentID = 3, StudentName = "Bill", Age = 18 },
    new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
    new Student() { StudentID = 5, StudentName = "David", Age = 15 }
};
int oldest = studentList
                .Max(s => s.Age);

Console.WriteLine("Oldest Student Age: {0}", oldest);
Console.ReadLine();

// ! Max returns a result of any data type.
Student? studentWithLongName = studentList.Max();
Console.WriteLine("Student ID: {0}, Student Name: {1}",
                                        studentWithLongName?.StudentID, studentWithLongName?.StudentName);

class Student : IComparable<Student>
{
  public int StudentID { get; set; }
  public string? StudentName { get; set; }
  public int Age { get; set; }

  public int CompareTo(Student? other)
  {
    if (this.StudentName?.Length >= other?.StudentName?.Length)
      return 1;

    return 0;
  }
}
#endregion