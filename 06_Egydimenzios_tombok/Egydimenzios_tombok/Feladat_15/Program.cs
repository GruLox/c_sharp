using Custom.Library.ConsoleExtensions;
using Feladat_15;

AlbumSong[] songs = GetAlbumSongs(3);

int totalLength = songs.Sum(s => s.Length);
Console.WriteLine($"Album hossza: {totalLength / 60} : {totalLength % 60}");

int averageLength = (int)Math.Round(songs.Average(s => s.Length));
Console.WriteLine($"Átlagos szám: {averageLength / 60} : {averageLength % 60}");

AlbumSong shortestSong = songs.OrderBy(s => s.Length).First();
Console.WriteLine($"A legrövidebb szám: {shortestSong}");

bool wasThereAnySongLongerThan4Minutes = songs.Any(s => s.Length > 240);
Console.WriteLine($"{(wasThereAnySongLongerThan4Minutes ? "volt" : "nem volt")} 4 percnél hosszabb szám.");

AlbumSong longestSong = songs.OrderByDescending(s => s.Length).First();
int indexOfLongestSong = Array.IndexOf(songs, longestSong);
Console.WriteLine($"{indexOfLongestSong + 1}. volt a leghosszabb szám.");

bool wasThereAnySongsWithTheSameLength = songs.GroupBy(s => s.Length).Any(g => g.Count() > 1);  
if (wasThereAnySongsWithTheSameLength)
{
    Console.WriteLine("Voltak azonos hosszúságú számok:");
    foreach (var group in songs.GroupBy(s => s.Length).Where(g => g.Count() > 1))
    {
        foreach (var song in group)
        {
            Console.WriteLine(song);
        }
    }
}
else
{
    Console.WriteLine("Nem voltak azonos hosszúságú számok.");
}



static AlbumSong[] GetAlbumSongs(int count)
{
    AlbumSong[] songs = new AlbumSong[count];
    for (int i = 0; i < songs.Length; i++)
    {
        int songNumber = i + 1;
        string title = ExtendedConsole.ReadString("Cím: ");
        songs[i] = new AlbumSong(songNumber, title);
    }
    return songs;
}