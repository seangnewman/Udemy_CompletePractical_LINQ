using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var result = new List<T>();

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }

            }

            //return result; 
        }


        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
                throw new ArgumentException();

            if(action == null)
                throw new ArgumentException();
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
