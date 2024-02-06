

namespace Feladat___02;

public class GamesByGenre
{
    public string Genre { get; set; }
    public int Count { get; set; }

    public GamesByGenre()
    {
    }

    public GamesByGenre(string genre, int count)
    {
        Genre = genre;
        Count = count;
    }
}
