namespace Feladat_15;

public class AlbumSong
{
    const int MAX_LENGTH = 500;
    const int MIN_LENGTH = 20;

    public int SongNumber { get; set; }
    public string Title { get; set; }
    public int Length { get; }

    public AlbumSong(int songNumber, string title)
    {
        SongNumber = songNumber;
        Title = title;
        Length = GetRandomLength();
    }

    private int GetRandomLength()
    {
        Random random = new Random();
        return random.Next(MIN_LENGTH, MAX_LENGTH);
    }

    public override string ToString()
    {
        return $"{SongNumber} - {Title} ({Length / 60} : {Length % 60})";
    }
}
