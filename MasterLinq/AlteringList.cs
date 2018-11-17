using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public class AlteringList
    {

        public static void RemoveInForeach()
        {
            var list = new List<int> { 0,1,2,3,4,5 };
            foreach (var item in list)
            {
                if( item % 2 == 0)
                {
                    list.Remove(item);
                }
            }
            Console.WriteLine(list.Count == 3);
        }

        public static void RemoveInFor()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if( item % 2 == 0)
                {
                    list.Remove(item);
                    i--;
                }
            }
            Console.WriteLine(list.Count == 3);
        }


        public static void RemoveInFor2()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            for (var i = list.Count - 1; i >= 0; i--)
            {
                var item = list[i];
                if (item % 2 == 0)
                {
                    list.Remove(item);
                    i--;
                }
            }
            Console.WriteLine(list.Count == 3);
        }

        public static void RemoveAll()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };

            list.RemoveAll(x => x <= 3);

        }

        public static void AlterWithSecondList()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            List<int> result = list.Where(item => item % 2 != 0).ToList();
            Console.WriteLine(result.Count == 3);
        }
    }
}
