using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public static class Extensions
    {
        public static IEnumerable<TResult> Convert<TResult>(this IEnumerable<int> sequence)
        {
            foreach (var item in sequence)
            {
                dynamic runtimeItem = item;
                yield return (TResult)runtimeItem;

            }
        }
    }
}
