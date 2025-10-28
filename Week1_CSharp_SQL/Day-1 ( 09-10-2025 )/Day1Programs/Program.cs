// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Welcome to .NET Training!");
//         Console.WriteLine("This is managed code running under CLR.");
//     }
// }


// using System;

// class VariablesDemo
// {
//     static void Main()
//     {
//         int age = 22;
//         string name = "Udaya Kumar Shetty";
//         float salary = 25000.75f;
//         bool isActive = true;

//         Console.WriteLine("Name: " + name);
//         Console.WriteLine("Age: " + age);
//         Console.WriteLine("Salary: " + salary);
//         Console.WriteLine("Active: " + isActive);
//     }
// }


// using System;

// class OperatorsDemo
// {
//     static void Main()
//     {
//         int a = 10, b = 3;

//         Console.WriteLine("Addition: " + (a + b));
//         Console.WriteLine("Subtraction: " + (a - b));
//         Console.WriteLine("Multiplication: " + (a * b));
//         Console.WriteLine("Division: " + (a / b));
//         Console.WriteLine("Modulus: " + (a % b));
//     }
// }


// using System;

// class IfElseDemo
// {
//     static void Main()
//     {
//         int number = -5;

//         if (number > 0)
//             Console.WriteLine("Positive number");
//         else if (number < 0)
//             Console.WriteLine("Negative number");
//         else
//             Console.WriteLine("Number is zero");
//     }
// }


// using System;

// class SwitchDemo
// {
//     static void Main()
//     {
//         int day = 3;

//         switch (day)
//         {
//             case 1: Console.WriteLine("Monday"); break;
//             case 2: Console.WriteLine("Tuesday"); break;
//             case 3: Console.WriteLine("Wednesday"); break;
//             case 4: Console.WriteLine("Thursday"); break;
//             case 5: Console.WriteLine("Friday"); break;
//             default: Console.WriteLine("Weekend"); break;
//         }
//     }
// }

// using System;

// class ForLoopDemo
// {
//     static void Main()
//     {
//         for (int i = 1; i <= 5; i++)
//         {
//             Console.WriteLine("Iteration: " + i);
//         }
//     }
// }


// using System;

// class WhileLoopDemo
// {
//     static void Main()
//     {
//         int i = 1;

//         while (i <= 5)
//         {
//             Console.WriteLine("Count: " + i);
//             i++;
//         }
//     }
// }


using System;

class DoWhileExample
{
    static void Main()
    {
        int i = 1;
        do
        {
            Console.WriteLine("Number: " + i);
            i++;
        } while (i <= 5);
    }
}
