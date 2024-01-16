using Custom.Library.ConsoleExtensions;
using Feladat_12;

HandballPlayer[] players = GetHandballPlayers(3);
players = players.OrderBy(p => p.Goals).ToArray();

double averageGoals = players.Average(p => p.Goals);

int countOfPlayersWithBelowAverageGoals = players.Count(p => p.Goals < averageGoals);
Console.WriteLine($"Átlag alatti gólszámot szerző játékosok száma: {countOfPlayersWithBelowAverageGoals}");

HandballPlayer[] playersWithAboveAverageGoals = players.Where(p => p.Goals > averageGoals).ToArray();
Console.WriteLine("Átlag feletti gólszámot szerző játékosok:");
foreach (var player in playersWithAboveAverageGoals)
{
    Console.WriteLine(player);
}

HandballPlayer leastGoals = players.First();
Console.WriteLine($"A legkevesebb gólt szerző játékos: {leastGoals.Name} - {leastGoals.Goals}");



static HandballPlayer[] GetHandballPlayers(int count)
{
    HandballPlayer[] players = new HandballPlayer[count];
    for (int i = 0; i < players.Length; i++)
    {
        string name = ExtendedConsole.ReadString("Játékos neve: ");
        int goals = ExtendedConsole.ReadInteger("Gólok száma: ", int.MaxValue, 0);
        players[i] = new HandballPlayer(name, goals);
    }
    return players;

}