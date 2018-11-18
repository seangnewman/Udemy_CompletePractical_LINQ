using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public class JoinGroupAggregate
    {
        public static void Demo()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
            JoinDemo(fileLocation);
        }

        public static void DemoGroupJoin()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
            GroupJoinDemo();
        }

        public static void JoinGroupByDemo()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");
            GroupByDemo(fileLocation);
        }

        public static void ZipDemo()
        {
            List<Team> teams = new List<Team>()
            {
                new Team {Name = "Bavaria", Country = "Germany"},
                new Team {Name = "Barcelona", Country = "Spain"},
                new Team {Name = "Juventus", Country = "Italy"}
            };

            List<Player> players = new List<Player>()
            {
                new Player  {Name = "Messy", Team = "Barcelona"},
                new Player  {Name = "Neimar", Team = "Barcelona"},
                new Player  {Name = "Robben", Team = "Bavaria"},
                new Player  {Name = "Buffon", Team = "Juventus"}
            };

            var result = players.Zip(teams,
                                      (player, team) => new
                                      {
                                          Name = player.Name,
                                          Team = team.Name,
                                          Country = team.Country

                                      });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.Team} from {item.Country}");
            }
        }

        public static void GroupJoinDemo()
        {
            List<Team> teams = new List<Team>()
            {
                new Team {Name = "Bavaria", Country = "Germany"},
                new Team {Name = "Barcelona", Country = "Spain"},
                new Team {Name = "Juventus", Country = "Italy"}
            };

            List<Player> players = new List<Player>()
            {
                new Player  {Name = "Messy", Team = "Barcelona"},
                new Player  {Name = "Neimar", Team = "Barcelona"},
                new Player  {Name = "Robben", Team = "Bavaria"},
                new Player  {Name = "Buffon", Team = "Juventus"}
            };

            var result = teams.GroupJoin( players,
                                          t => t.Name,
                                          pt => pt.Team,
                                          (t, pl)=> new
                                          {
                                            Name = t.Name,
                                            Count = t.Country,
                                            Players = pl.Select(p => p.Name)
                                          });
            foreach (var team in result)
            {
                Console.WriteLine($"Players in {team.Name}");
                foreach (var player in team.Players)
                {
                    Console.WriteLine(player);
                }
                Console.WriteLine();
            }
        }
        public static void GroupByDemo(string file)
        {
            var players = File.ReadAllLines(file)
                           .Skip(1)
                           .Select(s => ChessPlayer.ParseFideCsv(s))
                           .Where(p => p.BirthYear > 1988)
                           .Take(10)
                           .GroupBy(p => p.Country)
                           .OrderByDescending(g => g.Key)
                           .ToList();

            foreach (var player in players)
            {
                Console.WriteLine($"\nThe following players live in {player.Key}");
                foreach (var p in player)
                {
                    Console.WriteLine($"Player: {p.LastName}, Rating: {p.Rating} ");
                }
            }
        }

        public static void JoinDemo(string file)
        {
            var players = File.ReadAllLines(file)
                           .Skip(1)
                           .Select(s => ChessPlayer.ParseFideCsv(s))
                           .Where(p => p.BirthYear > 1988)
                           .Take(10)
                           .ToList();

            var tournaments = Tournament.GetDemoStats();

            var join = players.Join(tournaments,
                                    p => p.Id,
                                    t => t.PlayerId,
                                    (p, t) => new
                                    {
                                        p.LastName,
                                        p.Rating,
                                        t.Title,
                                        t.TakenPlace,
                                        t.Country
                                    });

            foreach (var item in join)
            {
                Console.WriteLine($"{item.LastName} took {item.TakenPlace} place at {item.Title}. Has " +
                    $"rating {item.Rating}");
            }


            Console.WriteLine("After Join");
            var selectMany = join.GroupBy(c => c.Country)
                                 .SelectMany(g => g.OrderBy(grp => grp.TakenPlace));

            foreach (var item in selectMany)
            {
                Console.WriteLine($"{item.LastName} took {item.TakenPlace} place at {item.Title}. Has " +
                   $"rating {item.Rating}");
            }

        }

        
    }
}
