namespace Feladat_16;

public class VolleyballPlayer
{

    public string Name { get; set; }
    public int Height { get; }
    public int TotalPoints { get; }

    public VolleyballPlayer(string name, int height, int totalPoints)
    {
        Name = name;
        Height = height;
        TotalPoints = totalPoints;
    }
    public override string ToString()
    {
        return $"{Name} - {Height} cm - {TotalPoints} pont";
    }
}
