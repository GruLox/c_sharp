using Feladat___01;
using System.Collections.Generic;

public class PlayersPerClub
{
    public List<string> Players{ get; set; }

    public string Club { get; set; }

    public PlayersPerClub() { }

    public PlayersPerClub(List<string> players, string club)
    {
        Players = players;
        Club = club;
    }
}

