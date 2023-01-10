// See https://dotnettutorials.net/course/linq/ for more information
Console.WriteLine("Hello, World!");


#region Concat Operator:
/*

    * The Concat() method appends two sequences of the same type and returns a new sequence (collection).
    * The Linq Concat Method in C# is used to concatenate two sequences into one sequence.
    ½ While working with the Concat operator if any of the sequences is null then it will throw an exception.
*/
IList<string> collection1 = new List<string>() { "One", "One", "One", "Two", "Three" };
IList<string> collection2 = new List<string>() { "Four", "Five", "Six" };

IEnumerable<string>? collection3 = collection1.Concat(collection2);

foreach (string str in collection3)
  Console.WriteLine(str);
Console.ReadLine();
#endregion


#region ! Concatenate using Union Operator
/*

    * In the below example, we concatenate the two integer sequences into one sequence using the Linq Union Operator.
    ! If you observe in the output, then you will see that the duplicate elements are removed from the result set.
*/
List<int> sequence1 = new List<int> { 1, 1, 2, 3, 4, 4, 4, 4 };
List<int> sequence2 = new List<int> { 2, 4, 6, 8 };

IEnumerable<int>? result = sequence1.Union(sequence2);

foreach (var item in result)
  Console.WriteLine(item);
Console.ReadLine();
#endregion


#region What is the difference between Concat and Union operators in Linq?
/*

    * The Concat operator is used to concatenate two sequences into one sequence without removing the duplicate elements.
    * That means it simply returns the elements from the first sequence followed by the elements from the second sequence. 
    + On the other hand, the Linq Union operator is also used to concatenate two sequences into one sequence by removing the duplicate elements. 
*/
#endregion