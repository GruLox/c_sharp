namespace Feladat_00;

public class Song
{
    public string Title { get; set; }

    public string Artist { get; set; }

    public int ReleaseYear { get; set; }

    public string Publisher { get; set; }

    public int Streams { get; set; }

    public override string ToString()
    {
        return $"{this.Artist} {this.Title} ({this.ReleaseYear})";
    }
}


