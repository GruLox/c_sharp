namespace Feladat_12;

public class HandballPlayer
{
    public string Name { get; set; }
    public int Goals { get; set; }

    public HandballPlayer(string name, int goals)
    {
        Name = name;
        Goals = goals;
    }

    public override string ToString()
    {
        return $"{Name} - {Goals} gól";
    }
}
