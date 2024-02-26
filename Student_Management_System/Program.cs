using System.Xml.Linq; 
using Student_Management_System; 

Student student = new Student(null,null,0,' '); // Creating a new instance of Student class
StudentManagmentSystem sms = new StudentManagmentSystem(); // Creating a new instance of StudentManagmentSystem class

Console.WriteLine("Welcome To The Student Management System Of 'The School of Programming'");
bool loop = true; // Variable to control the loop

begin:
Console.WriteLine();

// Displaying user's choices
Console.WriteLine("Would You Like To:\n\t1. Add New Student\n\t2. View All Students\n\t3. Find Student By Roll Number\n\t4. Upgrade Student's Grade\n\t5. View all Lecturers\n\t6. Exit");
string answer = Console.ReadLine(); // Reading user's input

while (loop) // Loop to handle user interactions
{
    // Checking user's choice
    if (answer == "1" || answer == "Add New Student")
    {
        try
        {
            // Adding a new student
            Console.WriteLine("To Add New Student, We Need The Name, Lastname, Roll Number And Grade\n\tEnter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("\tEnter Lastname:");
            string lastname = Console.ReadLine();

            Console.WriteLine("\tEnter Roll Number:");
            int rollNumber;
            bool isValid = int.TryParse(Console.ReadLine(), out rollNumber); // Parsing roll number input

            if (!isValid)
            {
                throw new FormatException(); // Throwing exception if input is not a valid integer
            }
            else
            {
                if (sms.RollNumberExist(rollNumber)) { throw new RollNumberExistsException(); }; // Checking if roll number already exists

                Console.WriteLine("\tEnter Grade:");
                char grade = char.Parse(Console.ReadLine()); 

                if ((int)grade < 65 || (int)grade > 70 ) { throw new WrongGradeException(); } // Checking if grade is within valid range
                else {
                    sms.AddStudent(name, lastname, rollNumber, grade); Console.WriteLine("Student added successfully!") ; // Adding student if all conditions are met
                    goto begin;
                }
            }
        }
        catch (WrongGradeException ex) { Console.WriteLine(ex.Message); } // Handling wrong grade exception
        catch (RollNumberExistsException ex) { Console.WriteLine(ex.Message); } // Handling roll number exists exception
        catch (FormatException ex) { Console.WriteLine("Invalid input. Please enter a valid integer for roll number."); } // Handling format exception for roll number
    }
    else if (answer == "2" || answer == "View All Students")
    {
        // Viewing all students
        sms.ViewAllStudents();
        goto begin;
    }
    else if (answer == "3" || answer == "Find Student By Roll Number")
    {
        // Finding a student by roll number
        Console.Write("Enter The Roll Number:  ");
        int rn = int.Parse(Console.ReadLine());

        Student st = sms.FindStudent(rn);
        if (st == null) { Console.WriteLine("Student Not Found!"); } 
        else { Console.WriteLine(st.ToString()); goto begin; } // Displaying student details
        
    }
    else if (answer == "4" || answer == "Upgrade Student's Grade")
    {
        try
        {
            // Upgrading a student's grade
            Console.WriteLine("To Change Student's Grade, We Need The Roll Number:");
            Console.WriteLine("\tEnter Roll Number:");
            int rollNumber = int.Parse(Console.ReadLine());

            if (sms.FindStudent(rollNumber) == null) { Console.WriteLine("Student Not Found!"); } 
            else
            {
                Console.WriteLine("\tEnter New Grade:");
                char newGrade = char.Parse(Console.ReadLine());

                if ((int)newGrade < 65 || (int)newGrade > 70) { throw new WrongGradeException(); } // Checking if new grade is within valid range
                else { sms.UpgradeGrade(sms.FindStudent(rollNumber), rollNumber, newGrade); Console.WriteLine("Grade Changed Successfully!"); goto begin; } // Upgrading grade if all conditions are met
            }

        }
        catch (WrongGradeException ex) { Console.WriteLine(ex.Message); } // Handling wrong grade exception
    }
    else if (answer == "5" || answer == "View all Lecturers")
    {
        sms.ViewLecturers();
        goto begin;
    }
    else if (answer == "6" || answer == "Exit")
    {
        // Exiting the program
        Console.WriteLine("You Have Exited Successfully!");
        loop = false; // Setting loop control variable to false to exit the loop
    }
    else
    {
        // Handling incorrect option
        Console.WriteLine("Enter Correct Option!");
        goto begin; // Returning to the beginning of the loop
    }
    //answer = "0";
}


