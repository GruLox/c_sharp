public class PlayersPerPosition
{
    public int PlayerCount { get; set; }

    public string Position { get; set; }

    public PlayersPerPosition() { }

    public PlayersPerPosition(int playerCount, string position)
    {
        PlayerCount = playerCount;
        Position = position;
    }
}