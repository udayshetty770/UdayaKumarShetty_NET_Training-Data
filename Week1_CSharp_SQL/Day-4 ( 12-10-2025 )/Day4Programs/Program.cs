// using System;

// class ArrayDemo
// {
//     static void Main()
//     {
//         int[] marks = { 85, 90, 75, 80, 95 };

//         Console.WriteLine("Marks List:");
//         foreach (int mark in marks)
//             Console.Write(mark + " ");

//         Console.WriteLine("\nSorted Marks:");
//         Array.Sort(marks);
//         foreach (int mark in marks)
//             Console.Write(mark + " ");
//     }
// }


// using System;

// class MatrixDemo
// {
//     static void Main()
//     {
//         int[,] matrix = { {1, 2, 3}, {4, 5, 6} };

//         Console.WriteLine("Matrix Elements:");
//         for (int i = 0; i < 2; i++)
//         {
//             for (int j = 0; j < 3; j++)
//                 Console.Write(matrix[i, j] + " ");
//             Console.WriteLine();
//         }
//     }
// }

// using System;

// class JaggedArrayDemo
// {
//     static void Main()
//     {
//         int[][] jagged = new int[3][];
//         jagged[0] = new int[] {1, 2};
//         jagged[1] = new int[] {3, 4, 5};
//         jagged[2] = new int[] {6};

//         for (int i = 0; i < jagged.Length; i++)
//         {
//             Console.Write("Row " + i + ": ");
//             foreach (int val in jagged[i])
//                 Console.Write(val + " ");
//             Console.WriteLine();
//         }
//     }
// }

// using System;

// class StringDemo
// {
//     static void Main()
//     {
//         string s = "  Dhruv Compusoft Pvt Ltd  ";

//         Console.WriteLine("Original: '" + s + "'");
//         Console.WriteLine("Trimmed: '" + s.Trim() + "'");
//         Console.WriteLine("Upper: " + s.ToUpper());
//         Console.WriteLine("Replace: " + s.Replace("Compusoft", "Technologies"));
//         Console.WriteLine("Substring(2,5): " + s.Substring(2,5));
//         Console.WriteLine($"Length: {s.Length}");
//     }
// }

// using System;
// using System.Text;

// class StringBuilderDemo
// {
//     static void Main()
//     {
//         StringBuilder sb = new StringBuilder("Welcome");
//         sb.Append(" to Dhruv");
//         sb.Append(" .NET Training");
//         sb.Replace("Dhruv", "Dhruv Compusoft");

//         Console.WriteLine(sb);
//     }
// }


// using System;
// using System.Collections.Generic;

// class ListDemo
// {
//     static void Main()
//     {
//         List<string> students = new List<string>() {"Udaya", "Kiran", "Arjun"};
//         students.Add("Shetty");

//         Console.WriteLine("Students:");
//         foreach (string s in students)
//             Console.WriteLine(s);

//         students.Remove("Kiran");
//         Console.WriteLine("\nAfter Removal:");
//         students.ForEach(Console.WriteLine);
//     }
// }


// using System;
// using System.Collections.Generic;

// class DictionaryDemo
// {
//     static void Main()
//     {
//         Dictionary<string, int> ages = new Dictionary<string, int>();
//         ages["Udaya"] = 24;
//         ages["Arun"] = 25;
//         ages["Kiran"] = 23;

//         foreach (var kv in ages)
//             Console.WriteLine($"{kv.Key} → {kv.Value}");
//     }
// }


// using System;
// using System.Collections.Generic;

// class StackQueueDemo
// {
//     static void Main()
//     {
//         Stack<int> stack = new Stack<int>();
//         stack.Push(10);
//         stack.Push(20);
//         stack.Push(30);
//         Console.WriteLine("Stack Pop: " + stack.Pop());

//         Queue<string> queue = new Queue<string>();
//         queue.Enqueue("A");
//         queue.Enqueue("B");
//         queue.Enqueue("C");
//         Console.WriteLine("Queue Dequeue: " + queue.Dequeue());
//     }
// }


// using System;
// using System.Collections.Generic;

// class HashSetDemo
// {
//     static void Main()
//     {
//         HashSet<int> set = new HashSet<int>() {1, 2, 2, 3, 4};
//         Console.WriteLine("Unique Elements:");
//         foreach (int n in set)
//             Console.WriteLine(n);
//     }
// }

// using System;

// class ExceptionDemo
// {
//     static void Main()
//     {
//         try
//         {
//             Console.Write("Enter number1: ");
//             int a = Convert.ToInt32(Console.ReadLine());
//             Console.Write("Enter number2: ");
//             int b = Convert.ToInt32(Console.ReadLine());
//             int result = a / b;
//             Console.WriteLine($"Result: {result}");
//         }
//         catch (DivideByZeroException)
//         {
//             Console.WriteLine(" Division by zero not allowed!");
//         }
//         catch (FormatException)
//         {
//             Console.WriteLine("Please enter numeric values only!");
//         }
//         finally
//         {
//             Console.WriteLine("Execution complete.");
//         }
//     }
// }


// using System;

// class InvalidAgeException : Exception
// {
//     public InvalidAgeException(string message) : base(message) { }
// }

// class CustomExceptionDemo
// {
//     static void Main()
//     {
//         try
//         {
//             Console.Write("Enter age: ");
//             int age = Convert.ToInt32(Console.ReadLine());
//             if (age < 18)
//                 throw new InvalidAgeException("Age must be 18 or above!");
//             Console.WriteLine("You are eligible.");
//         }
//         catch (InvalidAgeException ex)
//         {
//             Console.WriteLine("Custom Exception → " + ex.Message);
//         }
//     }
// }


using System;

class VariableDemo
{
    static void Main()
    {
        var x = 10;             // compile-time type
        dynamic y = "Hello";    // runtime type
        object z = 25;          // base type

        Console.WriteLine($"var: {x} ({x.GetType()})");
        Console.WriteLine($"dynamic: {y} ({y.GetType()})");
        Console.WriteLine($"object: {z} ({z.GetType()})");

        y = 123; // valid for dynamic
        Console.WriteLine($"dynamic new value: {y}");
    }
}
