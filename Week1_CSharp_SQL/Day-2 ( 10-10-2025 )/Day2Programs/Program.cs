// using System;

// class MethodsDemo
// {
//     // Method without return type
//     static void Greet(string name)
//     {
//         Console.WriteLine($"Hello {name}, welcome to Dhruv .NET training!");
//     }

//     // Method with return type
//     static int Add(int a, int b)
//     {
//         return a + b;
//     }

//     static void Main()
//     {
//         Greet("Udaya");
//         int sum = Add(10, 20);
//         Console.WriteLine("Sum = " + sum);
//     }
// }


// using System;

// class Student
// {
//     public string name;
//     public int age;

//     public void Display()
//     {
//         Console.WriteLine($"Name: {name}, Age: {age}");
//     }
// }

// class ClassDemo
// {
//     static void Main()
//     {
//         Student s1 = new Student(); // Object creation
//         s1.name = "Udaya";
//         s1.age = 24;
//         s1.Display();
//     }
// }


// using System;

// struct Point
// {
//     public int x, y;
//     public void Display()
//     {
//         Console.WriteLine($"X = {x}, Y = {y}");
//     }
// }

// class StructDemo
// {
//     static void Main()
//     {
//         Point p = new Point();
//         p.x = 10; 
//         p.y = 20;
//         p.Display();
//     }
// }


// using System;

// interface IShape
// {
//     double GetArea();
// }

// class Circle : IShape
// {
//     public double radius;
//     public Circle(double r)
//     {
//         radius = r;
//     }

//     public double GetArea()
//     {
//         return Math.PI * radius * radius;
//     }
// }

// class InterfaceDemo
// {
//     static void Main()
//     {
//         IShape shape = new Circle(5);
//         Console.WriteLine("Area of Circle = " + shape.GetArea());
//     }
// }


// using System;

// enum Level
// {
//     Low,
//     Medium,
//     High
// }

// class EnumDemo
// {
//     static void Main()
//     {
//         Level taskLevel = Level.Medium;
//         Console.WriteLine("Task Level: " + taskLevel);
//         Console.WriteLine("Numeric value: " + (int)taskLevel);
//     }
// }


// using System;

// class Animal
// {
//     public virtual void Sound()
//     {
//         Console.WriteLine("Animal makes sound");
//     }
// }

// class Dog : Animal
// {
//     public override void Sound()
//     {
//         Console.WriteLine("Dog barks ");
//     }
// }

// class Cat : Animal
// {
//     public override void Sound()
//     {
//         Console.WriteLine("Cat meows ");
//     }
// }

// class OOPDemo
// {
//     static void Main()
//     {
//         Animal a1 = new Dog();
//         Animal a2 = new Cat();

//         a1.Sound();
//         a2.Sound();
//     }
// }


using System;

class DivideNumbers
{
    public int Divide(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero!");
            return 0;
        }
        finally
        {
            Console.WriteLine("Division process complete.");
        }
    }
}

class ExceptionHandlingDemo
{
    static void Main()
    {
        DivideNumbers obj = new DivideNumbers();
        Console.Write("Enter first number: ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second number: ");
        int y = Convert.ToInt32(Console.ReadLine());

        int result = obj.Divide(x, y);
        Console.WriteLine("Result = " + result);
    }
}
