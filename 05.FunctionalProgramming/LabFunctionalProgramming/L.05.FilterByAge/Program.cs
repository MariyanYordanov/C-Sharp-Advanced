using System;
using System.Collections.Generic;
using System.Linq;

namespace L._05.FilterByAge
{
    class Program
    {
        public class Student
        {
            public Student(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public string Name { get; set; }

            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] pairNameAge = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = pairNameAge[0];
                int age = int.Parse(pairNameAge[1]);
                Student student = new Student(name, age);
                students.Add(student);
            }

            string conditionCommand = Console.ReadLine();
            int ageCommand = int.Parse(Console.ReadLine());
            string formatCommand = Console.ReadLine();
            Func<Student, int, bool> filter = GetFilter(conditionCommand);
            students = students.Where(x => filter(x, ageCommand)).ToList();
            Action<Student> print = GetFormat(formatCommand);
            students.ForEach(print);
        }

        private static Func<Student, int, bool> GetFilter(string conditionCommand)
        {
            switch (conditionCommand)
            {
                case "older": return (s, age) => s.Age >= age;
                case "younger": return (s, age) => s.Age < age;
                default: return null;
            }
        }

        private static Action<Student> GetFormat(string formatCommand)
        {
            switch (formatCommand)
            {
                case "name": return s => Console.WriteLine(s.Name);
                case "age": return s => Console.WriteLine(s.Age);
                case "name age": return s => Console.WriteLine($"{s.Name} - {s.Age}");
                default: return null;
            }
        }

    }
}
