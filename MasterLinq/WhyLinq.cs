using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public static class WhyLinq
    {


        private static void IEnumerableDemo()
        {
            

            IEnumerable<string> names = new List<string>()
            {
                "John", "Bob", "Alice"
            };

            IEnumerator<string> enumerator = names.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        private static void DisplayLargestStatFilesWithLinq(string path)
        {
            new DirectoryInfo(path)
                             .GetFiles()
                             .Filter(f => f.LastWriteTime < new DateTime(2018, 08, 01))
                             //.Where(f => f.LastWriteTime < new DateTime(2018, 08, 01))
                             .OrderBy(f => f.Length)
                             .Take(5)
                             .ForEach(f => Console.WriteLine($"{f.Name} weights {f.Length}"));


          
        }

        private static void DisplayLargestStatFilesWithoutLinq(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            FileInfo[] files = dirInfo.GetFiles();

            Array.Sort(files,
                       (x, y) =>
                       {
                           if (x.Length == y.Length)
                               return 0;
                           if (x.Length > y.Length)
                               return 1;
                           return -1;

                       }
                        );
            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name} weights {file.Length}");
            }

        }


        public static void Demo()
        {
            var location = Path.Combine(Directory.GetCurrentDirectory(), "StudentStats");
            DisplayLargestStatFilesWithLinq(location);
        }
    }
}
 
