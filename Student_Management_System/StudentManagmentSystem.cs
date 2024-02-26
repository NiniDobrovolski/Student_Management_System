using System;
using System.Collections.Generic;
using Student_Management_System;


namespace Student_Management_System
{
    // Class for managing student data
    public class StudentManagmentSystem
    {
        // List to store lecturer objects
        public List<Lecturer> Lecturers { get; private set; } = new List<Lecturer>()
        {
            // adding some sample lecturer data
            new Lecturer(
                "Jacob",
               "Washington"
            ),

             new Lecturer ("Oliver",
                "Sprouse"
            ),
              new Lecturer("Madison",
                 "Madden"),
              new Lecturer("Kelly",
                "Hart")
        };

        public void ViewLecturers() => Lecturers.ForEach(Console.WriteLine);
        // List to store roll numbers of students
        public List<int> RollNumbers { get; set; } = new List<int>()
        {
             1,2,3,4
        };

        // List to store student objects
        public List<Student> Students { get; set; } = new List<Student>()
        {
            // adding some sample student data
            new Student("John",
                "Sue",
                1,
                'B'),
             new Student("Kate",
                "Sprouse",
                  2,
                 'C'
            ),
              new Student(
               "Jane",
                 "Madden",
                  3,
                 'B'
              ),
              new Student(
                "Elly",
                  "Hart",
                  4,
                  'A'
            )
        };

        // Method to add a new student
        public void AddStudent(string name, string lastname, int rollNumber, char grade) => Students.Add(
              new Student(name,
                   lastname,
                    rollNumber,
                   grade)
              );

        // Method to check if a given roll number exists
        public bool RollNumberExist(int rollNumber)
        {
            return RollNumbers.Contains(rollNumber);
        }

        // Method to view all students
        public void ViewAllStudents() => Students.ForEach(
               Console.WriteLine);

        // Method to find a student by roll number
        public Student FindStudent(int rollNumber)
        {
            foreach (var item in Students)
            {
                if (item.RollNumber == rollNumber) return item;
            }
            return null;
        }

        // Method to upgrade the grade of a student
        public void UpgradeGrade(Student student, int rollNumber, char newGrade)
        {
            foreach (var item in Students)
            {
                // If the student's roll number matches the provided roll number, update the grade
                if (student.RollNumber == rollNumber)
                    student.Grade = newGrade;
            }
        }
    }
}
