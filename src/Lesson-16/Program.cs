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


#region Sum Operator:
IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87, 7, 10 };

int total = intList
                .Sum();
Console.WriteLine("Sum: {0}", total);
Console.ReadLine();

// example
int greaterThan50 = intList
                        .Where(num => num > 50)
                        .Sum();
Console.WriteLine("Sum of numbers greater than 50: {0}", greaterThan50);
Console.ReadLine();

// example
int sumOfEvenElements = intList.Sum(i =>
                                        {
                                          if (i % 2 == 0)
                                            return i;

                                          return 0;
                                        });
Console.WriteLine("Sum of Even Elements: {0}", sumOfEvenElements);
Console.ReadLine();

// example
IList<Student> studentList = new List<Student>() {
    new Student() { StudentID = 1, StudentName = "John", Age = 13 },
    new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 },
    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 },
    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 },
    new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
};
int sumOfAge = studentList
                    .Sum(s => s.Age);
Console.WriteLine("Sum of all student's age: {0}", sumOfAge);
Console.ReadLine();

// example
int numOfAdults = studentList.Sum(s =>
                                    {

                                      if (s.Age >= 18)
                                        return 1;
                                      else
                                        return 0;
                                    });
Console.WriteLine("Total Adult Students: {0}", numOfAdults);
Console.ReadLine();
#endregion


#region Count Operator:
/*

    * The first overload method of Count returns the number of elements in the specified collection, whereas the second overload method returns the number of elements which have satisfied the specified condition given as lambda expression/predicate function.
    *
*/
IList<int> intList_forCount = new List<int>() { 10, 21, 30, 45, 50 };

int totalElements = intList_forCount
                            .Count();
Console.WriteLine("Total Elements: {0}", totalElements);
Console.ReadLine();

// example
int evenElements = intList_forCount
                            .Count(i => i % 2 == 0);
Console.WriteLine("Even Elements: {0}", evenElements);
Console.ReadLine();

// example
int totalStudents = studentList
                            .Count();
Console.WriteLine("Total Students: {0}", totalStudents);
Console.ReadLine();

// example
int adultStudents = studentList
                            .Count(s => s.Age >= 18);
Console.WriteLine("Number of Adult Students: {0}", adultStudents);
Console.ReadLine();
#endregion


class Student
{
  public int StudentID { get; set; }
  public string? StudentName { get; set; }
  public int Age { get; set; }
}