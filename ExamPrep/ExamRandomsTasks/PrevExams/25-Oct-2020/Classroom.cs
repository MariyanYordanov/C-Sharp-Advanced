using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public int Capacity { get; set; }
        public List<Student> Students { get; set; }
        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
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
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            var studentsSubject = students.Where(x => x.Subject == subject).ToList();
            if (studentsSubject.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Subject: {subject}");
                stringBuilder.AppendLine("Students:");
                foreach (Student student in students)
                {
                    stringBuilder.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return stringBuilder.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount() => Count;

        public Student GetStudent(string firstName, string lastName) 
            => students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        
    }
}
