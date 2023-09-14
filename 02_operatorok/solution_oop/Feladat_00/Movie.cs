namespace Feladat_00;

public class Movie
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }

    public string DirectorName { get; set; }

    public double IMDBRating { get; set; }

    public double RunTime { get; set; }

    public override string ToString()
    {
        return $"{this.Title} ({this.ReleaseYear}) directed by {this.DirectorName} - {this.IMDBRating} rating";
    }
}


