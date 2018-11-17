using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //WhyLinq.Demo();
            //ParseCsv.ParseCsvDemo();
            //QueryFormsDemo();
            //ParseCsv.ParseCsvQueryDemo();
            //DemoNoYield();
            //Console.WriteLine("\nWith Yield\n");
            // DemoYield();
            //Defferred.Closure();
            //AlteringList.RemoveInFor();
            //Console.WriteLine();
            //AlteringList.RemoveInFor2();
            //EnumerableDemo();
            // Projections_with_Select();

            //WhereDemo.Demo();
            //ParseCsv.ParseCsv_FirstLastSingleDefault();
            //ParseCsv.TakeWhile();
            //ParseCsv.SkipWhile();
            //ParseCsv.ParseCsv_SequenceEqual();
            //ParseCsv.DemoDistinct();
            //ParseCsv.DemoDistinctRating();
            //ParseCsv.AnyAllContains();
            //SelectMany.Demo();
            ElementAtCount();

        }

        private static void ElementAtCount()
        {
            var players = ChessPlayer.GetDemoList();

            int count = players.Count( p => p.Country== "USA");
            long longCount = players.LongCount();

            ChessPlayer x = players.ElementAt(1);

            Console.WriteLine($"Count: {count} Long Count: {longCount}  Player at Index 1 {x}");
            Console.WriteLine();
        }

        private static void Projections_with_Select()
        {
            var players = ChessPlayer.GetDemoList().ToList();
            var ratings = players.Select(p => p.Rating);
            var lastNames = players.Select(p => p.LastName);
            var FullNames = players.Select(p => $"{p.LastName} {p.FirstName}");

            var anonymousType = players.Select((p, index) => new { Index = index, p.FirstName, p.LastName });

            foreach (var rating in ratings)
            {
                Console.WriteLine(rating);
            }
            Console.WriteLine();
            foreach (var type in anonymousType)
            {
                Console.WriteLine($"{type.FirstName } {type.LastName}");
            }
        }

        private static void EnumerableDemo()
        {
            Console.WriteLine("Generating Range");

            foreach (var r in Enumerable.Range(5, 8))
            {
                Console.WriteLine($"{r} ");
            }

            Console.WriteLine("\nRepeating");
            foreach (var r in Enumerable.Repeat(10, 5))
            {
                Console.WriteLine($"{r} ");
            }

            Console.WriteLine("\nRandomNumbers");
            foreach (var r in RandomStream.GenerateRandomNumber().Where(n => n > 0.7).Take(5))
            {
                Console.WriteLine($"{r.ToString("F2")} ");
            }
        }

        public IEnumerable<int> GetDate()
        {
            // if no elements please do this
            return Enumerable.Empty<int>();
        }

        private static void ProcessCollection(IReadOnlyCollection<ChessPlayer> players)
        {
            Console.WriteLine("FirstNames\n");
            foreach (var player in players)
            {
                Console.WriteLine(player.FirstName);
            }

            Console.WriteLine("\nLastName\n");
            foreach (var player in players)
            {
                Console.WriteLine(player.LastName);
            }
        }
        private static void MultipleEnumeration()
        {
            IEnumerable<ChessPlayer> players = FilterPlayersByMinumumRating(2750).ToList();

            Console.WriteLine("FirstNames\n");
            foreach (var player in players)
            {
                Console.WriteLine(player.FirstName);
            }

            Console.WriteLine("\nLastName\n");
            foreach (var player in players)
            {
                Console.WriteLine(player.LastName);
            }

        }
        private static IEnumerable<ChessPlayer> FilterPlayersByMinumumRating(int minRating)
        {
            return ChessPlayer.GetDemoList().Where(p => p.Rating >= minRating);
        }

        private static void DemoYield()
        {
            var players = ChessPlayer.GetDemoList().Where(c => c.Country == "USA");

            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
        }

        private static void DemoNoYield()
        {
            var players = ChessPlayer.GetDemoList().Filter(c => c.Country == "USA");

            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
        }

        private static void QueryFormsDemo()
        {
            var ratings = new List<int>
            {
                2200,2400,2700,2800,2820
            };

            var ratings1 = ratings.Where(r => r > 2700);
            var ratings2 = ratings.Where(GetRatingsOver2700);
            var ratings3 = ratings.Where(delegate (int rating) { return rating > 2700; });

            foreach (var r in ratings1)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine();
            foreach (var r in ratings2)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine();
            foreach (var r in ratings3)
            {
                Console.WriteLine(r);
            }
        }

        private static bool GetRatingsOver2700(int arg)
        {
            return arg > 2700;
        }


    }
}
