public static class FileService
{
    public static async Task<List<Gambler>> ReadLotteryTipsFromFileAsync(string fileName)
    {
        var lotteryTips = new List<Gambler>();
        Gambler tip = null;

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string[] data = line.Split('\t');

            if (data.Length < 2)
            {
                continue;
            }

            tip = new Gambler
            {
                Name = data[0],
                Tips = data[1].Split(',').Select(int.Parse).ToList()
            };

            lotteryTips.Add(tip);
        }

        return lotteryTips;
    }

    public static async Task WriteWinningNumbersToFileAsync(string fileName, List<int> winningNumbers)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", fileName);

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        await sw.WriteLineAsync(string.Join(", ", winningNumbers));
    }

    public static async Task WriteCollectionToFileAsync<T>(string fileName, IEnumerable<T> collection) where T : class
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", fileName);

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (var item in collection)
        {
            await sw.WriteLineAsync(item.ToString());
        }
    }
}
