using System;
using Student_Management_System;

namespace Student_Management_System
{
    public class Human
    {
        public string Name { get; set; }
        public string Lastname { get; set; }

        public Human(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
        }

        public override string ToString()
        {
            return null;
        }
    }

    // Class representing a lecturer
    public class Lecturer : Human
    {
        private int IDNumber { get; set; }
        private static int nextID = 1;

        public Lecturer(string name, string lastname) : base(name, lastname)
        {
            IDNumber = nextID++; // Assign a unique ID and increment the counter
        }

      

        public override string ToString()
        {
            return $"{Name} {Lastname}";
        }
    }

    // Class representing a student
    public class Student : Human
    {
        public int RollNumber { get; set; }
        public char Grade { get; set; }

        // Constructor with four arguments
        public Student(string name, string lastname, int rollNumber, char grade) : base(name, lastname)
        {
            RollNumber = rollNumber;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{Name} {Lastname} {RollNumber} {Grade}";
        }
    }

}
