using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public class SelectMany
    {
        public static void Demo()
        {
            IEnumerable<Person> people = new List<Person>()
            {
                new Person() {Name="Bob", PhoneNumbers = new List<string> (){ "123", "456"}},
                new Person() {Name="John", PhoneNumbers = new List<string> (){ "789", "453"}},
                new Person() {Name="Jeff", PhoneNumbers = new List<string> (){ "879", "146"}},
                new Person() {Name="Jon", PhoneNumbers = new List<string> (){ "765", "481"}},
                new Person() {Name="Buster", PhoneNumbers = new List<string> (){ "294", "090"}}
            };

            IEnumerable<List<string>> phoneLists = people.Select(p => p.PhoneNumbers);

            var phoneNumbers = people.SelectMany(p => p.PhoneNumbers);

            var personsWithPhoneNumbers = people.SelectMany(p => p.PhoneNumbers, 
                                                            (person, phone) => new { person.Name, Phone=phone});
            foreach (var person in personsWithPhoneNumbers)
            {
                Console.WriteLine($"Person: {person.Name}, Phone: {person.Phone}");
            }

        }
    }
}
