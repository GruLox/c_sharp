using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Feladat___01
{
    internal class Program
    {
        private static List<Player> _players = new List<Player>();

        private static void LoadData()
        {
            using (FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string jsonData = sr.ReadToEnd();

                    _players = JsonConvert.DeserializeObject<List<Player>>(jsonData);
                }
            }
        }

        private static void WriteToConsole(string text, ICollection<Player> players)
        {
            Console.WriteLine(text);
            Console.WriteLine(string.Join('\n', _players));
        }

        private static void WriteToConsole(string text, Player player)
        {
            Console.WriteLine(text);
            Console.WriteLine(player);
        }

        static void Main(string[] args)
        {
            LoadData();
            WriteToConsole("Data", _players);

            // hany jatekos van az adatbazisban
            int countOfPlayers = _players.Count;

            // atlagmagassag
            double averageHeight = _players.Average(x => x.Height);

            // legalacsonyabb neve
            Player shortestPlayer = _players.MinBy(x => x.Height);
            string nameOfShortestPlayer = shortestPlayer.Name;

            // 1980-ban szuletett jatekosok
            IEnumerable<Player> playersBornIn1980 = _players.Where(x => DateTime.Parse(x.Birthday).Year == 1980).ToList();

            // rendezzuk a jatekosokat nev szerint csokkeno sorrendbe, magassag szerint csokkenobe
            IEnumerable<Player> playersInDescendingOrderByNameThenByHeight = _players.OrderByDescending(x => x.Name)
                                                  .ThenByDescending(x => x.Height);

            // posztonkent (position) mennyi jatekos
            IEnumerable<PlayersPerPosition> playersPerPosition = _players.GroupBy(x => x.Position)
                                                                  .Select(x => new PlayersPerPosition
                                                                  {
                                                                      Position = x.Key,
                                                                      PlayerCount = x.Count()
                                                                  });

            // kik azok a jatekosok (nev), akik az 1990-es evekben szulettek
            IEnumerable<string> playersBornInThe90s = _players.Where(x => DateTime.Parse(x.Birthday).Year >= 1990 && 
                                                                  DateTime.Parse(x.Birthday).Year <= 1999)
                                                           .Select(x => x.Name);
            

            // jatekosok csapatonkent (csapatnev, jatekos(csak nev))
            IEnumerable<PlayersPerClub> playersPerClub = _players.GroupBy(p => p.Club)
                                                        .Select(x => new PlayersPerClub
                                                        {
                                                            Club = x.Key,
                                                            Players = x.Select(x => x.Name).ToList()
                                                        });
            




                                    
        }
    }
}
