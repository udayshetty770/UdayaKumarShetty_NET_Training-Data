using System;

namespace StudentGradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Student Grade Calculator ===");

                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Roll Number: ");
                int rollNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter number of subjects: ");
                int subjectCount = int.Parse(Console.ReadLine());

                int[] marks = new int[subjectCount];
                for (int i = 0; i < subjectCount; i++)
                {
                    Console.Write($"Enter marks for Subject {i + 1}: ");
                    marks[i] = int.Parse(Console.ReadLine());
                }

                Student student = new Student(name, rollNumber, marks);
                student.CalculateGrade();
                student.DisplayResult();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format! Please enter numeric values where required.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nProgram execution completed.");
            }
        }
    }
}
