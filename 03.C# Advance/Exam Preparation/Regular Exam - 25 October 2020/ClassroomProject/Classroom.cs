using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private int capacity;
        private List<Student> students;

        public int Count => students.Count;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }

        public string RegisterStudent(Student student)
        {
            if (Count < capacity)
            {
                students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            bool hasBeenRemoved = students.Remove(students.Find(x => x.FirstName == firstName && x.LastName == lastName));

            return hasBeenRemoved
                ? $"Dismissed student {firstName} {lastName}"
                : "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            var filtered = students.Where(x => x.Subject == subject).ToList();

            if (filtered.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            else
            {
                StringBuilder output = new StringBuilder();

                output.AppendLine($"Subject: {subject}");
                output.AppendLine("Students:");

                foreach (var student in filtered)
                {
                    output.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return output.ToString().TrimEnd();
            }
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {          
            return students.Find(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
