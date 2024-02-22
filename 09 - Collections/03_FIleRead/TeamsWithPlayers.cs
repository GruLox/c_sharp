public class TeamsWithPlayers
{
    public string Team { get; set; }
    public List<string> Players { get; set; }

    public TeamsWithPlayers() { }
    public TeamsWithPlayers(string team, List<string> players)
    {
        Team = team;
        Players = players;
    }
}
