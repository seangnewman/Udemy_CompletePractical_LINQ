using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public class EfDemo
    {
        public static void Run()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ChessPlayerDb>());
            InsertData();
            QueryData();
        }

        private static void QueryData()
        {
            var db = new ChessPlayerDb();
            db.Database.Log = Console.WriteLine;

            var query = db.chessPlayers
                        .Where(p => p.Rating > 2700)
                        .OrderByDescending(p => p.Rating);

            foreach (var player in query)
            {
                Console.WriteLine($"{ player.LastName}, Rating: { player.Rating}");
            }
        }

        

        public static void InsertData()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");

            var records = File.ReadAllLines(fileLocation)
                              .Skip(1)
                              .Select( s => ChessPlayer.ParseFideCsv(s))
                              .ToList();

            var db = new ChessPlayerDb();

            if (!db.chessPlayers.Any())
            {
                db.chessPlayers.AddRange(records);
            }

            db.SaveChanges();

        }

         
    }
}
