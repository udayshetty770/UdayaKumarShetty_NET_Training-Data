using System;

namespace StudentGradeCalculator
{
    public class Student : Person, IGradeCalculator
    {
        private int[] Marks;
        private double Average;
        private string Grade;

        public Student(string name, int rollNumber, int[] marks)
            : base(name, rollNumber)
        {
            Marks = marks;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Roll No: {RollNumber}");
        }

        public void CalculateGrade()
        {
            int total = 0;
            foreach (int mark in Marks)
            {
                total += mark;
            }

            Average = total / (double)Marks.Length;

            if (Average >= 85)
                Grade = "A";
            else if (Average >= 70)
                Grade = "B";
            else if (Average >= 50)
                Grade = "C";
            else
                Grade = "Fail";
        }

        public void DisplayResult()
        {
            DisplayInfo();
            Console.WriteLine($"Average Marks: {Average}");
            Console.WriteLine($"Grade: {Grade}");
        }
    }
}
