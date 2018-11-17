using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public class WhereDemo
    {
        public static void Demo()
        {
            var names = new List<string>()
            {
                "Mary", "John", "Bob", "Harry", "Elias","Ann", "Ada"
            };

            var filteredNames = names.Where(n => n.Length > 3);
            var everySecondName = names.Where( (n, i)  =>  i % 2 == 0  );

            foreach (var name in filteredNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            foreach (var name in everySecondName)
            {
                Console.WriteLine(name);
            }

        }
    }
}
