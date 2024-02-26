using System;

namespace Student_Management_System
{
    // Custom exception class for handling wrong grades
    internal class WrongGradeException : ApplicationException
    {
        private string _msg;

        // Constructor to initialize the error message
        public WrongGradeException()
        {
            _msg = "Enter Correct Grade!"; 
        }

        // Override the Message property to provide custom error message
        public override string Message
        {
            get { return $"{_msg}"; } 
        }
    }

    // Custom exception class for handling roll number existence
    internal class RollNumberExistsException : ApplicationException
    {
        private string _msg;

        // Constructor to initialize the error message
        public RollNumberExistsException()
        {
            _msg = "Roll Number Is Already Used!"; 
        }

        // Override the Message property to provide custom error message
        public override string Message
        {
            get { return $"{_msg}"; }   
        }
    }

    internal class FormatingExeption : ApplicationException
    {
        private string _msg;

        // Constructor to initialize the error message
        public FormatingExeption()
        {
            _msg = "Roll Number must be an intiger!";
        }

        // Override the Message property to provide custom error message
        public override string Message
        {
            get { return $"{_msg}"; }
        }
    }
}
