using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MasterLinq
{
    public class XmlLinq
    {
        public static void CsvToXml()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "ChessStats", "Top100ChessPlayers.csv");

            var records = File.ReadAllLines(fileLocation)
                .Skip(1)
                .Select(s => ChessPlayer.ParseFideCsv(s))
                .ToList();

            var doc = new XDocument();
            var players = new XElement("Players",
                                        records.Select(record => new XElement("Player",
                                            new XAttribute("Id", record.Id),
                                            new XAttribute("Rating", record.Rating),
                                            new XAttribute("BirthYear", record.BirthYear),
                                            new XAttribute("Country", record.Country),
                                            new XAttribute("Lastname", record.LastName),
                                            new XAttribute("Firstname", record.FirstName))));
            doc.Add(players);
            doc.Save("ChessPlayers.xml");
        }

        public static void ReadXml()
        {
            var doc = XDocument.Load("ChessPlayers2.xml");

            var query = doc.Element("Players")
                           ?.Elements("Player")
                           .Where(item => (int)item.Attribute("Rating") > 2700)
                           .Select(item => item.Attribute("Lastname").Value)
                           ?? Enumerable.Empty<string>();

            foreach (var lastname in query)
            {
                Console.WriteLine(lastname);
            }
        }
    }
}
