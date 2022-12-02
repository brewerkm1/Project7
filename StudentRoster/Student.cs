using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRoster
{
    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public List<GradeItem> Grades { get; private set; }

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Grades = new List<GradeItem>();
        }

        public void AddGrade(string name, byte grade) => Grades.Add(new GradeItem(name, grade));

        // Search for all grade items to find the first one with the right name
        // Remove the grade item if found
        public void RemoveGrade(string name) => Grades.Remove(Grades.Find(x => (x.Name == name)));
        
        
    }
}
