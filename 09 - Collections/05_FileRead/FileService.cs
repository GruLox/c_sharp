public static class FileService
{
    public static async Task<List<Absence>> ReadAbsencesFromFileAsync(string fileName)
    {
        List<Absence> absences = new();
        Absence absence = null;

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        // skip the header
        await sr.ReadLineAsync();

        while (!sr.EndOfStream)
        {
            string line = await sr.ReadLineAsync()!;
            string[] data = line.Split(';');

            if (data.Length < 5)
            {
                continue;
            }

            absence = new Absence
            {
                Name = data[0],
                Class = data[1],
                FirstDay = int.Parse(data[2]),
                LastDay = int.Parse(data[3]),
                HoursOfAbsence = int.Parse(data[4])
            };

            absences.Add(absence);
        }

        return absences;
    }

    public static async Task WriteAbsenceSummaryToFile(string fileName, List<ClassesWithAbsenceCount> summary)
    {
        Directory.CreateDirectory("output");

        string path = Path.Combine("output", fileName);

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (var item in summary)
        {
            await sw.WriteLineAsync(item.ToString());
        }
    }
}
