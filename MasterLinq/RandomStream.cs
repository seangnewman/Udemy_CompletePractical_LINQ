using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public static class RandomStream
    {
       public static IEnumerable<double> GenerateRandomNumber()
        {
            var random = new Random();

            while (true)
            {
                yield return random.NextDouble();
            }
        }
    }
}
