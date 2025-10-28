// using System;
// using System.IO;

// class FileCreateWrite
// {
//     static void Main()
//     {
//         File.WriteAllText("sample.txt", "Welcome to Dhruv .NET Training!");
//         Console.WriteLine("File created and written successfully.");
//     }
// }

// using System;
// using System.IO;

// class FileRead
// {
//     static void Main()
//     {
//         if (File.Exists("sample.txt"))
//         {
//             string content = File.ReadAllText("sample.txt");
//             Console.WriteLine("File content:\n" + content);
//         }
//         else
//         {
//             Console.WriteLine("File not found.");
//         }
//     }
// }


// using System;
// using System.IO;

// class FileAppend
// {
//     static void Main()
//     {
//         File.AppendAllText("sample.txt", "\nAppended new line on " + DateTime.Now);
//         Console.WriteLine("Content appended successfully.");
//     }
// }


// using System;
// using System.IO;

// class FileDelete
// {
//     static void Main()
//     {
//         if (File.Exists("sample.txt"))
//         {
//             File.Delete("sample.txt");
//             Console.WriteLine("File deleted.");
//         }
//         else
//         {
//             Console.WriteLine("File not found.");
//         }
//     }
// }

// using System;
// using System.IO;

// class StreamExample
// {
//     static void Main()
//     {
//         // Write
//         using (StreamWriter sw = new StreamWriter("data.txt"))
//         {
//             sw.WriteLine("Hello Udaya");
//             sw.WriteLine("Welcome to .NET Full Stack Training");
//         }

//         // Read
//         using (StreamReader sr = new StreamReader("data.txt"))
//         {
//             string line;
//             while ((line = sr.ReadLine()) != null)
//             {
//                 Console.WriteLine(line);
//             }
//         }
//     }
// }

// using System;
// using System.Linq;
// using System.Collections.Generic;

// class LINQNumbers
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int>() {10, 45, 60, 25, 90, 30};

//         var result = from n in numbers
//                      where n > 40
//                      orderby n descending
//                      select n;

//         Console.WriteLine("Numbers greater than 40:");
//         foreach (var n in result)
//             Console.WriteLine(n);
//     }
// }


// using System;
// using System.Linq;
// using System.Collections.Generic;

// class Student
// {
//     public string Name { get; set; }
//     public int Marks { get; set; }
// }

// class LINQObject
// {
//     static void Main()
//     {
//         List<Student> students = new List<Student>()
//         {
//             new Student(){Name="Udaya", Marks=85},
//             new Student(){Name="Arun", Marks=45},
//             new Student(){Name="Shetty", Marks=75}
//         };

//         var passed = students.Where(s => s.Marks >= 50)
//                              .OrderByDescending(s => s.Marks);

//         Console.WriteLine("Passed Students:");
//         foreach (var s in passed)
//             Console.WriteLine($"{s.Name} - {s.Marks}");
//     }
// }

// using System;
// using System.Linq;
// using System.Collections.Generic;

// class Student
// {
//     public string Name { get; set; }
//     public int Marks { get; set; }
// }

// class LINQGroup
// {
//     static void Main()
//     {
//         List<Student> students = new List<Student>()
//         {
//             new Student(){Name="Udaya", Marks=85},
//             new Student(){Name="Arun", Marks=45},
//             new Student(){Name="Shetty", Marks=75},
//             new Student(){Name="Ravi", Marks=30}
//         };

//         var groups = students.GroupBy(s => s.Marks >= 50 ? "Pass" : "Fail");

//         foreach (var g in groups)
//         {
//             Console.WriteLine(g.Key + ":");
//             foreach (var s in g)
//                 Console.WriteLine("  " + s.Name);
//         }

//         double avg = students.Average(s => s.Marks);
//         Console.WriteLine("\nAverage Marks: " + avg);
//     }
// }


