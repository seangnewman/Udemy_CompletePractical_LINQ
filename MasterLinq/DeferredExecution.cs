using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public class Defferred
    {
        public static void Test()
        {
            var list = new List<int> { 1, 2, 3 };
            var query = list.Where(c => c >= 2);

            list.Remove(3);

            Console.WriteLine(query.Count());
        }

        public static void Closure()
        {
            IEnumerable<char> str = "abcdefu";
            string vowels = "aeiou";

            for (var i = 0; i < vowels.Length; i++)
            {
                var v = vowels[i];
                str = str.Where(c =>   c != v);
            }

            Console.WriteLine(new string(str.ToArray()));

            IEnumerable<char> str2 = "abcdefu";

            foreach (var vowel in "aeiou")
            {
                str2 = str2.Where(c => c != vowel);
            }
            Console.WriteLine(new string(str2.ToArray()));
        }

        public static void CompiledVersion1()
        {
            IEnumerable<char> str = "abcdefu";
            string vowels = "aeiou";

            DisplayClass dc = new DisplayClass();
            for (var i = 0; i < vowels.Length; i++)
            {
                dc.i = i;
                str = str.Where(dc.Func);
            }
            Console.WriteLine(new string(str.ToArray()));
        }


        public static void CompiledVersion2()
        {
            IEnumerable<char> str = "abcdefu";
            string vowels = "aeiou";
 
            for (var i = 0; i < vowels.Length; i++)
            {
                DisplayClass dc = new DisplayClass();
                dc.i = i;
                str = str.Where(dc.Func);
            }
            Console.WriteLine(new string(str.ToArray()));
        }

        private sealed class DisplayClass
        {
            public int i;
            string vowels = "aeiou";

            public bool Func(char c)
            {
                return vowels[i] != c;
            }
        }
    }
 
}
