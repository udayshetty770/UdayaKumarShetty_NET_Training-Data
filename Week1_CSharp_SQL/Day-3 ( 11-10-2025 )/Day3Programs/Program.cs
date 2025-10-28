// using System;

// class Employee          // base class
// {
//     public string Name;
//     public void Work()
//     {
//         Console.WriteLine($"{Name} is working...");
//     }
// }

// class Developer : Employee   // derived class
// {
//     public string Language;
//     public void Code()
//     {
//         Console.WriteLine($"{Name} codes in {Language}");
//     }
// }

// class InheritanceDemo
// {
//     static void Main()
//     {
//         Developer dev = new Developer();
//         dev.Name = "Udaya";
//         dev.Language = "C#";
//         dev.Work();
//         dev.Code();
//     }
// }


// using System;

// class Calculator        // Compile-time polymorphism (overloading)
// {
//     public int Add(int a, int b) => a + b;
//     public double Add(double a, double b) => a + b;
// }

// class Shape             // Run-time polymorphism (overriding)
// {
//     public virtual void Draw() => Console.WriteLine("Drawing a shape...");
// }

// class Circle : Shape
// {
//     public override void Draw() => Console.WriteLine("Drawing a circle ");
// }

// class Square : Shape
// {
//     public override void Draw() => Console.WriteLine("Drawing a square ");
// }

// class PolymorphismDemo
// {
//     static void Main()
//     {
//         // overloading
//         Calculator c = new Calculator();
//         Console.WriteLine("Sum int: " + c.Add(5, 10));
//         Console.WriteLine("Sum double: " + c.Add(2.5, 3.6));

//         // overriding
//         Shape s1 = new Circle();
//         Shape s2 = new Square();
//         s1.Draw();
//         s2.Draw();
//     }
// }


// using System;

// // Abstract class example
// abstract class Vehicle
// {
//     public abstract void Start();     // must be implemented by child
//     public void Stop()
//     {
//         Console.WriteLine("Vehicle stopped.");
//     }
// }

// class Car : Vehicle
// {
//     public override void Start()
//     {
//         Console.WriteLine("Car started ");
//     }
// }

// class AbstractionDemo
// {
//     static void Main()
//     {
//         Vehicle car = new Car();
//         car.Start();
//         car.Stop();
//     }
// }


// using System;

// class BankAccount
// {
//     private double balance;   // hidden data

//     public void Deposit(double amount)
//     {
//         if (amount > 0) balance += amount;
//     }

//     public double Balance
//     {
//         get { return balance; }
//     }
// }

// class EncapsulationDemo
// {
//     static void Main()
//     {
//         BankAccount acc = new BankAccount();
//         acc.Deposit(5000);
//         Console.WriteLine("Current balance: " + acc.Balance);
//     }
// }


// using System;

// class Parent
// {
//     private int a = 10;
//     protected int b = 20;
//     public int c = 30;

//     public void Show()
//     {
//         Console.WriteLine($"a={a}, b={b}, c={c}");
//     }
// }

// class Child : Parent
// {
//     public void Display()
//     {
//         // a is private → not accessible
//         Console.WriteLine($"Protected b={b}, Public c={c}");
//     }
// }

// class AccessDemo
// {
//     static void Main()
//     {
//         Child ch = new Child();
//         ch.Show();
//         ch.Display();
//     }
// }

// using System;

// class Student
// {
//     public string Name;
//     public int Age;

//     // Default constructor
//     public Student()
//     {
//         Name = "Unknown";
//         Age = 0;
//     }

//     // Parameterized constructor
//     public Student(string name, int age)
//     {
//         Name = name; Age = age;
//     }

//     // Destructor (runs automatically)
//     ~Student()
//     {
//         Console.WriteLine($"Destructor called for {Name}");
//     }

//     public void Display() => Console.WriteLine($"{Name} - {Age}");
// }

// class ConstructorDemo
// {
//     static void Main()
//     {
//         Student s1 = new Student();
//         Student s2 = new Student("Udaya", 24);
//         s1.Display();
//         s2.Display();
//     }
// }


// using System;

// static class MathUtil
// {
//     public static double Pi = 3.14159;
//     public static double Square(double x) => x * x;
// }

// class StaticDemo
// {
//     static void Main()
//     {
//         Console.WriteLine("Pi: " + MathUtil.Pi);
//         Console.WriteLine("Square(4): " + MathUtil.Square(4));
//     }
// }


// using System;

// sealed class Logger
// {
//     public void Log(string msg) => Console.WriteLine("Log: " + msg);
// }

// // class FileLogger : Logger {}  //  Not allowed – sealed class

// class SealedDemo
// {
//     static void Main()
//     {
//         Logger log = new Logger();
//         log.Log("This class cannot be inherited.");
//     }
// }


using System;
using DhruvTraining.Day3;   // use the namespace defined below

namespace DhruvTraining.Day3
{
    public class Demo
    {
        public void Show()
        {
            Console.WriteLine("Inside DhruvTraining.Day3 namespace");
        }
    }
}

class NamespaceDemo
{
    static void Main()
    {
        Demo d = new Demo();
        d.Show();
    }
}
