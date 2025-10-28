namespace StudentGradeCalculator
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int RollNumber { get; set; }

        public Person(string name, int rollNumber)
        {
            Name = name;
            RollNumber = rollNumber;
        }

        public abstract void DisplayInfo();
    }
}
