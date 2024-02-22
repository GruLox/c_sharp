public static class FileService
{
    public static async Task<List<Volleyballer>> ReadVolleyballersAsync(string fileName)
    {
        List<Volleyballer> volleyballers = new List<Volleyballer>();

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF8);

        while (!sr.EndOfStream)
        {
            string line = await sr.ReadLineAsync();
            string[] data = line.Split('\t');

            if (data.Length != 6)
            {
                continue;
            }

            volleyballers.Add(new Volleyballer
            {
                Name = data[0],
                Height = int.Parse(data[1]),
                Position = data[2],
                Nationality = data[3],
                Team = data[4],
                Country = data[5]
            });
        }
        return volleyballers;
    }

    public static async Task WriteVolleyballersAsync(string fileName, List<Volleyballer> volleyballers)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", fileName);

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (var volleyballer in volleyballers)
        {
            await sw.WriteLineAsync($"{volleyballer.Name}\t{volleyballer.Height}\t{volleyballer.Position}\t{volleyballer.Nationality}");

        }
    }

    public static async Task WriteVolleyballersWithHeightDifferenceAsync(string fileName, List<VolleyballerWithDifferenceFromAverage> volleyballers)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", fileName);

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (var volleyballer in volleyballers)
        {
            await sw.WriteLineAsync($"{volleyballer.Name}\t{volleyballer.Height} - {volleyballer.DifferenceFromAverage}");

        }
    }

    public static async Task WriteVolleyballersToFileByTeamsAsync(string fileName, List<TeamsWithPlayers> teamsWithPlayers)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", fileName);

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (var team in teamsWithPlayers)
        {
            await sw.WriteLineAsync($"{team.Team}: {string.Join(", ", team.Players)}");
        }
    }

    public static async Task WriteNationalityCountsToFileAsync(string fileName, List<NationalityWithCount> nationalitiesWithCount)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", fileName);

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach(var  nationality in nationalitiesWithCount)
        {

            await sw.WriteLineAsync($"{nationality.Nationality}: {nationality.Count}");
        }
    }

    public static async Task WritePositionsWithHeightSumsToFileAsync(string fileName, List<PositionWithHeightSum> positionsWithHeightSums)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", fileName);

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (var position in positionsWithHeightSums)
        {
            await sw.WriteLineAsync($"{position.Position}: {position.HeightSum}");
        }
    }
   


}
