using Custom.Library.ConsoleExtensions;

const int PLAYER_COUNT = 3;

HockeyPlayer[] hockeyPlayers = GetHockeyPlayers();

double goalAverage = hockeyPlayers.Average(player => player.GoalCount);
var belowAveragePlayers = hockeyPlayers.Where(player => player.GoalCount < goalAverage).ToArray();
PrintPlayersToConsole(belowAveragePlayers, "Átlag alatt teljesítők");

int aboveAverageCount = hockeyPlayers.Count(player => player.GoalCount > goalAverage);
Console.WriteLine($"{aboveAverageCount} játékos teljesített átlag felett.");

var playerWithMostGoals = GetPlayerWithMostGoals(hockeyPlayers);
Console.WriteLine("A legtöbb gólt szerzett játékos: ");
Console.WriteLine(playerWithMostGoals);

static HockeyPlayer[] GetHockeyPlayers()
{
    var hockeyPlayers = new HockeyPlayer[PLAYER_COUNT];
    for (int i = 0; i < PLAYER_COUNT; i++)
    {

        string name = ExtendedConsole.ReadString($"Kérem adja meg a {i + 1}. játékos nevét: ");
        int goalCount = ExtendedConsole.ReadInteger($"Kérem adja meg a {i + 1}. játékos góljainak számát: ");

        hockeyPlayers[i] = new HockeyPlayer(name, goalCount);
    }
    return hockeyPlayers;
}

static void PrintPlayersToConsole(HockeyPlayer[] hockeyPlayers, string title = "")
{
    Console.WriteLine(title);

    foreach (var hockeyPlayer in hockeyPlayers)
    {
        Console.WriteLine(hockeyPlayer);
    }
}

static HockeyPlayer GetPlayerWithMostGoals(HockeyPlayer[] hockeyPlayers)
{
    int maxGoalCount = hockeyPlayers.Max(player => player.GoalCount);

    var playerWithMostGoals = hockeyPlayers.First(player => player.GoalCount == maxGoalCount);

    return playerWithMostGoals;
}