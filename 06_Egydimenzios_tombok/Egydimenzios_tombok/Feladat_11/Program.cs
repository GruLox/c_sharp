using Custom.Library.ConsoleExtensions;
using Feladat_11;

BasketballPlayer[] players = GetPlayers(3);

int totalPoints = players.Sum(p => p.Points);

players = players.OrderBy(p => p.Points).ToArray();

BasketballPlayer mostPoints = players.Last();
Console.WriteLine($"A legtöbb pontot szerző játékos: {mostPoints.Name} - {mostPoints.Points}");

BasketballPlayer leastPoints = players.First();
Console.WriteLine($"A legkevesebb pontot szerző játékos: {leastPoints.Name} - {leastPoints.Points}");

double average = (double)totalPoints / players.Length;

int countOfBelowAveragePlayers = players.Count(p => p.Points < average);
Console.WriteLine($"Átlag alatti pontszámot szerző játékosok száma: {countOfBelowAveragePlayers}");

BasketballPlayer[] aboveAveragePlayers = players.Where(p => p.Points > average).ToArray();
Console.WriteLine("Átlag feletti pontszámot szerző játékosok:");
foreach (var player in aboveAveragePlayers)
{
    Console.WriteLine(player);
}


BasketballPlayer[] GetPlayers(int count)
{
    BasketballPlayer[] players = new BasketballPlayer[count];
    for (int i = 0; i < players.Length; i++)
    {
        string name = ExtendedConsole.ReadString("Játékos neve: ");
        int points = ExtendedConsole.ReadInteger("Pontok száma: ", int.MaxValue, 0);
        players[i] = new BasketballPlayer(name, points);
    }
    return players;
}   