using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; }
        public Family()
        {
            People = new List<Person>();
        }
        public void AddMember(Person person)
        {
            People.Add(person);
        }

        public List<Person> GetPersonOver30()
        {
            List<Person> filtradedFamily = new List<Person>();
            foreach (var member in People)
            {
                if (member.Age > 30)
                {
                    Person person = new Person(member.Name, member.Age);
                    filtradedFamily.Add(person);
                }
            }

            return filtradedFamily;
        }

        public Person GetOldestMember()
        {
            Person person = People.OrderByDescending(x => x).FirstOrDefault();
            return person;
        }

        
    }
}
