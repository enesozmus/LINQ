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


#region Average Operator:
/*

    * This Average method can return nullable or non-nullable decimal, float or double value.
*/
IList<int> intList = new List<int>() { 10, 20, 30, 35, 60 };

double avg = intList.Average();
Console.WriteLine("Average: {0}", avg);
Console.ReadLine();


// example
double avg2 = intList.Where(num => num > 50).Average();
Console.WriteLine("Average 2: {0}", avg2);
Console.ReadLine();


// example
IList<Student> studentList = new List<Student>() {
    new Student() { StudentID = 1, StudentName = "John", Age = 13 },
    new Student() { StudentID = 2, StudentName = "Moin", Age = 21 },
    new Student() { StudentID = 3, StudentName = "Bill", Age = 18 },
    new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
    new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
};

double avgAge = studentList.Average(s => s.Age);
Console.WriteLine("Average Age of Student: {0}", avgAge);
Console.ReadLine();
#endregion


#region Aggregate Operator:
/*

    * The Aggregate method performs an accumulate operation.
    * The Linq Aggregate extension method performs an accumulative operation.
    * Aggregate extension method has the following overload methods:

        - public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func);
            ½ Applies an accumulator function over a sequence.

        - public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func);
            ½ Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value.

        - public static TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector);
            ½ Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value, and the specified function is used to select the result value.
*/
string[] skills = { "C#.NET", "MVC", "WCF", "SQL", "LINQ", "ASP.NET" };

string? commaSeperatedString = skills.Aggregate((s1, s2) => s1 + ", " + s2);
/*

    * The lambda expression (s1, s2) => s1 + “, ” + s2 will be treated like s1 = s1 + “, ” + s2 where s1 will be accumulated for each item present in the collection.

        1. First “C#.NET” is concatenated with “MVC” to produce the result “C#.NET, MVC“.
        2. Result in Step 1 i.e. “C#.NET, MVC” is then concatenated with “WCF” to produce the result “C#.NET, MVC, WCF“.
        3. Result in Step 2 i.e. “C#.NET, MVC, WCF” is then concatenated with “SQL” to produce the result “C#.NET, MVC, WCF, SQL“.
        ...
*/
Console.WriteLine("commaSeperatedString: {0}", commaSeperatedString);
Console.ReadLine();


// example
int[] intNumbers = { 3, 5, 7, 9 };

int result = intNumbers.Aggregate((n1, n2) => n1 * n2);
Console.WriteLine("result_1: {0}", result);
Console.ReadLine();
#endregion


#region Aggregate Method with the seed parameter:
/*

    * The second overloaded version of the Aggregate method takes the first parameter as the seed value to accumulate.
    * The second overload method of Aggregate requires first parameter for seed value to accumulate.
    * The Second parameter is Func type delegate: Let us understand the use of the seed parameter with an example.
*/
int result2 = intNumbers.Aggregate(2, (n1, n2) => n1 * n2);
Console.WriteLine("result_2: {0}", result2);
Console.WriteLine(945 * 2);
Console.ReadLine();


//example
string commaSeparatedStudentNames = studentList.Aggregate<Student, string>("Student Names: ", (str, s) => str += s.StudentName + ", ");
Console.WriteLine(commaSeparatedStudentNames);
Console.ReadLine();


// example
int SumOfStudentsAge = studentList.Aggregate<Student, int>(0, (totalAge, s) => totalAge += s.Age);
Console.WriteLine(SumOfStudentsAge);
Console.ReadLine();
#endregion


#region Aggregate Method with Complex Type
/*

    * The third overload version requires the third parameter of the Func delegate expression for the result selector so that we can formulate the result.
    ½ Let's see how we can remove the last comma using the third parameter:
*/
string commaSeparatedStudentNames2 = studentList.Aggregate<Student, string, string>(
                                            "Student Names: ", // seed value
                                            (str, s) => str += s.StudentName + ", ", // returns result using seed value, String.Empty goes to lambda expression as str
                                            str => str.Substring(0, str.Length - 2)); // result selector that removes last comma
Console.WriteLine(commaSeparatedStudentNames2);
Console.WriteLine("over");
Console.ReadLine();


class Student
{
  public int StudentID { get; set; }
  public string? StudentName { get; set; }
  public int Age { get; set; }
}
#endregion