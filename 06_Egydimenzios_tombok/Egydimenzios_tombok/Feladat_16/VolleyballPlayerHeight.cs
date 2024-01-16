
namespace Feladat_16;

public class VolleyballPlayerHeight
{
    public VolleyballPlayer TallestPlayer { get; set; }

    public VolleyballPlayer ShortestPlayer { get; set; }

    public int HeightDifference { get; }

    public VolleyballPlayerHeight (VolleyballPlayer tallestPlayer, VolleyballPlayer shortestPlayer)
    {
        TallestPlayer = tallestPlayer;
        ShortestPlayer = shortestPlayer;
        HeightDifference = tallestPlayer.Height - ShortestPlayer.Height;
    }

    public override string ToString()
    {
        return $"A legmagasabb játékos: {TallestPlayer.Name}({TallestPlayer.Height})\n" +
            $"A legalacsonyabb játékos: {ShortestPlayer.Name}({ShortestPlayer.Height})\n" +
            $"A különbség {HeightDifference} cm.";
    }
}
