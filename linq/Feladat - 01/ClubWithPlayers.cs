using Feladat___01;
using System.Collections.Generic;
using System.Text;

public class ClubWithPlayers
{
    public ICollection<string> PlayerNames{ get; set; }

    public string Club { get; set; }

    public ClubWithPlayers() { }

    public ClubWithPlayers(ICollection<string> players, string team)
    {
        PlayerNames = players;
        Club = team;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(Club);

        foreach (var player in PlayerNames)
        {
            sb.AppendLine($"\t-{player}");
        }

        return sb.ToString();
    }
}

