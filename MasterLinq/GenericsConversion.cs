using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public class GenericsConversion
    {
        public void RunPuzzle()
        {
            var ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            var doubles1 = ints.Convert<double>()
                               .Select(x => x);
            var doubles2 = ints.Cast<double>()
                               .Select(x => x);

            var doubles3 = from double c in ints select c;
            var doubles4 = from c in ints select (double)c;



        }


        public static void TestConvertion(Func<List<int>, IEnumerable<double>> func, List<int> list)
        {
            try
            {
                IEnumerable<double> result = func(list);
                foreach (var d in result)
                {
                    Console.WriteLine(d);
                }
            }
            catch (Exception ex)
            {

                 
            }
        }
    }
}
