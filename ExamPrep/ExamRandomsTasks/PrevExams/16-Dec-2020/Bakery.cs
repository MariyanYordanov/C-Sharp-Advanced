using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Employee> Data { get; set; }
        public int Count => data.Count;

        public void Add(Employee employee)
        {
            if (Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);
            return data.Remove(employee);
        }

        public Employee GetOldestEmployee() => data.OrderByDescending(x => x.Age).FirstOrDefault();

        public Employee GetEmployee(string name) => data.FirstOrDefault(x => x.Name == name);

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in data)
            {
                stringBuilder.AppendLine(employee.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
