public class Volleyballer
{
     
    public string Name { get; set; }
    public int Height { get; set; }
    public string Position { get; set; }
    public string Nationality { get; set; }

    public string Team { get; set; }

    public string Country { get; set; }

    public Volleyballer() { }

    public Volleyballer(string name, int height, string position, string nationality, string team)
    {
        Name = name;
        Height = height;
        Position = position;
        Nationality = nationality;
        Team = team;
    }

    public override string ToString()
    {
        return $"{Name} ({Nationality}) - {Team}";
    }
}
