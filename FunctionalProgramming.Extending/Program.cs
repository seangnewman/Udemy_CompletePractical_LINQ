using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming.Extending
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt1 = new DateTime(2000, 12, 20, 01, 02, 03);
            var result1 = dt1.ToDeviceFormat();
            Console.WriteLine(result1);

            DateTime dt2 = new DateTime(1999, 12, 20, 01, 02, 03);
            var result2 = dt2.ToDeviceFormat();
            Console.WriteLine(result2);
 
        }
    }
}
