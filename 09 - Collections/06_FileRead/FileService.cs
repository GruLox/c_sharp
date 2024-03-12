public static class FileService
{
    public static async Task<List<DancePair>> ReadDancePairsFromFileAsync(string fileName)
    {
        List<DancePair> dancePairs = new();
        DancePair dancePair;

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        int index = 0;
        while (!sr.EndOfStream)
        {
            string dance = await sr.ReadLineAsync()!;
            string femaleDancer = await sr.ReadLineAsync()!;
            string maleDancer = await sr.ReadLineAsync()!;

            dancePair = new DancePair(index, maleDancer, femaleDancer, dance);
            dancePairs.Add(dancePair);
            index++;
        }

        return dancePairs;
    }

    public static async Task AppendToFileAsync(string caption, IEnumerable<string> content, string fileName)
    {
        Directory.CreateDirectory("output");

        string path = Path.Combine("output", fileName);

        using FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        await sw.WriteLineAsync(caption);
        await sw.WriteLineAsync(string.Join(", ", content));
    }
}
