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
            //ParseCsvDemo();
            //QueryFormsDemo();
            //ParseCsvQueryDemo();

            //DemoNoYield();
            //Console.WriteLine("\nWith Yield\n");
            // DemoYield();
            //Defferred.Closure();
            AlteringList.RemoveInFor();
            Console.WriteLine();
            AlteringList.RemoveInFor2();
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

        private static void ParseCsvDemo()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
            ParseCsv(fileLocation);
        }

        private static void ParseCsvQueryDemo()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
            ParseCsvQuery(fileLocation);
        }

        private static void ParseCsv(string file)
        {
            var list = File.ReadAllLines(file)
                            .Skip(1)
                            .Select(ChessPlayer.ParseFideCsv)
                            .OrderByDescending(p => p.Rating)
                            .Take(10);

            foreach (var player in list)
            {
                Console.WriteLine(player.ToString() ); 
            }
        }


        private static void ParseCsvQuery(string file)
        {
            var list = File.ReadAllLines(file)
                            .Skip(1)
                            .Select(ChessPlayer.ParseFideCsv);


            var filtered = list.Where(p => p.BirthYear > 1988)
                            .OrderByDescending(p => p.Rating)
                            .Take(10);

            var filtered2 = from player in list
                            where player.BirthYear > 1988
                            orderby player.Rating descending
                            select player;

            foreach (var player in filtered2.Take(10))
            {
                Console.WriteLine(player.ToString());
            }
        }
    }
}
