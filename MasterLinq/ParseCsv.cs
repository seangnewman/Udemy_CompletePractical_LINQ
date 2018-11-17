using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public class ParseCsv
    {

        public  static void ParseCsvDemo()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
            ParseCsvExpression(fileLocation);
        }

        public static void ParseCsvQueryDemo()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
            ParseCsvQuery(fileLocation);
        }


        public static void AnyAllContains()
        {
            var players = ChessPlayer.GetDemoList().ToList();
            bool contains = players.Contains(new ChessPlayer()
            {
                Id = 6,
                BirthYear = 1993,
                FirstName = "Wesley",
                LastName = "So",
                Rating = 2780,
                Country = "USA"
            }, new PlayerComparer());

            bool any = players.Any(p => p.Country == "FRA");

            bool all = players.All(p => p.Rating > 2500);

            Console.WriteLine($"Contains = {contains}, Any = {any} and All = {all}");

        }
        public static void DemoDistinct()
        {
            string str = "Hello, World";
            Console.WriteLine("\"Hello, World \" contains the following chars:");
            foreach (var c in str.ToCharArray().Distinct())
            {
                Console.Write(c);
            }
            Console.WriteLine("\n");
        }

        public static void DemoDistinctRating()
        {
            Console.WriteLine("\nFull Demo list of Chess Players:\n");

            foreach (var player in ChessPlayer.GetDemoList())
            {
                Console.WriteLine(player);
            }

            Console.WriteLine("\nCustom Distinct\n");
            var distintByRating = ChessPlayer.GetDemoList().Distinct(new RatingsComparer());

            foreach (var rating in distintByRating)
            {
                Console.WriteLine(rating);
            }
        }

         

        public static void SequenceEqual(string file)
        {
            var list = File.ReadAllLines(file)
                           .Skip(1)
                           .Select(f => ChessPlayer.ParseFideCsv(f))
                           .Where(p => p.BirthYear > 1988)
                           .OrderByDescending(p => p.Rating).ThenBy(c => c.Country)
                           .Take(10);

            var list2 = File.ReadAllLines(file)
                            .Skip(1)
                            .Select(f => ChessPlayer.ParseFideCsv(f))
                            .Where(p => p.BirthYear > 1988)
                            .OrderByDescending(p => p.Rating).ThenBy(c => c.Country)
                            .Take(10);

            bool areEqual = list.SequenceEqual(list2, new PlayerComparer() );
            Console.WriteLine($"Are collections equal? {areEqual}");
        }

        public static void TakeWhile()
        {
            var intList = new[] { 1, 2, 3, 4, 2, 1 };
            Console.WriteLine("Where");
            foreach (var item in intList.Where(x => x <= 3))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("TakeWhile");
            foreach (var item in intList.TakeWhile(x => x <= 3))
            {
                Console.WriteLine(item);
            }
        }

        public static void SkipWhile()
        {
            var intList = new[] { 1, 2, 3, 4, 5, 3, 2, 4, 5 };
            Console.WriteLine("Where");
            foreach (var item in intList.Where(x => x  > 3))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("SkipWhile");
            foreach (var item in intList.SkipWhile(x => x <= 3))
            {
                Console.WriteLine(item);
            }

        }
        public static void ParseCsv_SequenceEqual()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
           SequenceEqual(fileLocation);
        }
        public static void ParseCsv_FirstLastSingleDefault()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
            ParseCsvExpression_First_Last_Single_Default(fileLocation);
        }

        public static void ParseCsv_While_TakeWhile()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
            TakeWhile();
        }

        public static void ParseCsv_While_SkipWhile()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
            SkipWhile();
        }


        private static void ParseCsvExpression(string file)
        {
            var list = File.ReadAllLines(file)
                            .Skip(1)
                            .Select(f => ChessPlayer.ParseFideCsv(f))
                            .OrderByDescending(p => p.Rating).ThenBy(c => c.Country)
                            .Take(10);

            foreach (var player in list)
            {
                Console.WriteLine(player.ToString());
            }
        }

        private static void ParseCsvExpression_First_Last_Single_Default(string file)
        {
            var list = File.ReadAllLines(file)
                            .Skip(1)
                            .Select(f => ChessPlayer.ParseFideCsv(f))
                            .OrderByDescending(p => p.Rating).ThenBy(c => c.Country)
                            .Take(10);

            Console.WriteLine(list.First());
            Console.WriteLine(list.Last());
            Console.WriteLine(list.First(c => c.Country == "USA"));
            Console.WriteLine(list.Last(c => c.Country == "USA"));

            Console.WriteLine(list.FirstOrDefault(c => c.Country == "BRA"));
            Console.WriteLine(list.LastOrDefault(c => c.Country == "BRA"));

            Console.WriteLine(list.Single(c => c.Country == "FRA"));
            Console.WriteLine(list.SingleOrDefault(c => c.Country == "BRA"));
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
