using Custom.Library.ConsoleExtensions;
using Feladat_16;

VolleyballPlayer[] players = GetVolleyballPlayers(3);

double heightAverage = players.Average(p => p.Height);
VolleyballPlayer[] belowAverageHeightPlayers = players.Where(p => p.Height < heightAverage).ToArray();
Console.WriteLine("Átlag alatti játékosok:");
PrintPlayersToConsole(belowAverageHeightPlayers);

double percentageOfPlayersAboveAverageHeight = (double)players.Count(p => p.Height > heightAverage) / players.Length * 100;
Console.WriteLine($"Átlag feletti játékosok aránya: {percentageOfPlayersAboveAverageHeight} %");

int TotalPointsScored = players.Sum(p => p.TotalPoints);
Console.WriteLine($"Összpontszám: {TotalPointsScored}");

VolleyballPlayer bestPlayer = players.OrderByDescending(p => p.TotalPoints).First();
Console.WriteLine($"Legjobb játékos: {bestPlayer}");

VolleyballPlayer worstPlayer = players.OrderBy(p => p.TotalPoints).First();
Console.WriteLine($"Legrosszabb játékos: {worstPlayer}");


static VolleyballPlayer[] GetVolleyballPlayers(int count)
{
    VolleyballPlayer[] players = new VolleyballPlayer[count];
    for (int i = 0; i < players.Length; i++)
    {
        string name = ExtendedConsole.ReadString("Név: ");
        int height = ExtendedConsole.ReadInteger("Magasság: ");
        int totalPoints = ExtendedConsole.ReadInteger("Összpontszám: ");
        players[i] = new VolleyballPlayer(name, height, totalPoints);
    }
    return players;
}

static void PrintPlayersToConsole(VolleyballPlayer[] players)
{
    foreach (var player in players)
    {
        Console.WriteLine(player);
    }
}