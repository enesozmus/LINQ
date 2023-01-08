// See https://dotnettutorials.net/course/linq/ for more information
Console.WriteLine("Hello, World!");

#region Using IEnumerable
List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

// returns IEnumerable<int>
IEnumerable<int> EvenNumbersList = intList.Where(n => n % 2 == 0);
/*

  * The LINQ’s standard query operators such as select, where, etc. are implemented in the Enumerable class.
  * These methods are implemented as extension methods of the type IEnumerable<T> interface.
  ? The above Where() method is not belonging to the List<T> class, but still, we are able to call it as it belongs to the List<T> class. 
  ? Why it is possible to call it using the List<T> object, let’s find out. If you go to the definition of where method, then you will find the following definition.

    ½   public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

  + As you can see in the signature, the where Where() method is implemented as an extension method on IEnumerable<T> interface and we know List<T> implements IEnumerable<T> interface.
  + This is the reason why we are able to call the Where() method using the List<T> object.

  ! With this keep in mind, let us understand what extension methods are and how they are implemented in C#.
*/
#endregion


#region What are Extension Methods?
/*

  * According to MSDN, Extension methods allow us to add methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.
  * In simple words, we can say that the Extension methods can be used as an approach to extending the functionality of a class by adding new methods in the future.
  * Extension methods are the special kind of static methods of a static class, but they are going to be called as if they were instance methods on the extended type. 

  + You need to use an extension method if any of the following conditions are true:

      1. You need a method on an existing type and you are not the owner of the source code of that type.
      2. You need a method on an existing type, you do own the source code of that type but that type is an interface.
      3. You need a method on an existing type, you do own the source code and that type is not an interface but adding the method creates undesired coupling.
*/
#endregion


#region How to implement extension methods in C#?
/*

  * Let us understand this with an example.
  * Our requirement is that we want to add a method in the built-in string class, let’s call this method GetWordCount() which will count the word present in a string separated by a space.
  * For example, if the string is “Welcome to Dotnet Tutorials”, then it should return the word count as 4.

  ! The most important point is that we need to call this method on the String object as shown below.

    - int wordCount = sentence.GetWordCount();

  + Note: We cannot define the GetWordCount() method directly in the string class as we are not the owner of the string class.
    
    - The string class belongs to the System namespace which is owned by the .NET framework.
    - So, the alternative solution to achieve this is to write a wrapper class as shown below.
*/
// ! You can save them from being a 'comment line'.
// string sentence = "Welcome to Dotnet Tutorials adana fransa bursa";
// // int wordCount = sentence.GetWordCount();
// int wordCount = ExtensionHelper.GetWordCount(sentence);
// Console.WriteLine(wordCount);

// public class ExtensionHelper
// {
//   public static int GetWordCount(string str)
//   {
//     if (!String.IsNullOrEmpty(str))
//       return str.Split(' ').Length;
//     return 0;
//   }
// }


/*

  * The above ExtensionHelper Wrapper class works fine, 
  * but the problem is, here we cannot call the GetWordCount() method using the string object as shown below.

    - 'string' bir 'GetWordCount' tanımı içermiyor ve 'string' türünde bir ilk bağımsız değişken kabul eden hiçbir erişilebilir 'GetWordCount' genişletme yöntemi bulunamadı
  
  * Instead, we need to call the GetWordCount() method as shown below.

    - int wordCount = ExtensionHelper.GetWordCount(sentence);

  ? How to convert the above GetWordCount() method to an Extension Method of string class?
*/
#endregion


#region How to convert the above GetWordCount() method to an Extension Method of string class?
/*

  * Now let’s convert the GetWordCount() method to an extension method on the String class.
  * So that we can able to call the GetWordCount() method using the following syntax.

    - int wordCount = sentence.GetWordCount();

  * In order to make the above GetWordCount() method as an extension method, we need to make two changes which are as follows.

    1. First, we need to make the ExtensionHelper class a static class.
    2. Second, the type the method extends (i.e. string) should be passed as the first parameter preceding with the “this” keyword to the GetWordCount() method.
  
  * With the above two changes in place, now the GetWordCount() method becomes an extension method and hence we can call the GetWordCount() method in the same way as we call an instance method of a class.
*/
string sentence = "Welcome to Dotnet Tutorials fo";
int wordCount2 = sentence.GetWordCount2();
Console.WriteLine(wordCount2);

public static class ExtensionHelper2
{
  public static int GetWordCount2(this string str)
  {
    if (!String.IsNullOrEmpty(str))
      return str.Split(' ').Length;
    return 0;
  }
}
#endregion