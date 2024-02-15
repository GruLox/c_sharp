public static class FileService
{
    #region File Read
    public static async Task<List<Student>> ReadStudentsFromFileV1Async(string fileName)
    {
        var students = new List<Student>();

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        await sr.ReadLineAsync(); // kiolvassa a fejlecet, csak epp nem csinalunk vele semmit, skippeljuk

        while (!sr.EndOfStream)
        {
            string line = await sr.ReadLineAsync();
            string[] data = line.Split('\t');
            if (data.Length != 2)
            {
                throw new FormatException("Invalid file format");
            }

            string name = data[0];
            double average = double.Parse(data[1]);
            Student student = new Student(name, average);

            students.Add(student);
        }
        
        return students;
    }

    public static async Task<List<Student>> ReadStudentsFromFileV2Async(string fileName)
    {
        string path = Path.Combine("source", fileName);
        Student student = null;
        List<Student> students = new List<Student>();

        string[] lines = await File.ReadAllLinesAsync(path, Encoding.UTF7);

        foreach (var line in lines.Skip(1)) // .Skip(1) - skip the header
        {
            string[] data = line.Split('\t');
            if (data.Length != 2)
            {
                throw new FormatException("Invalid file format");
            }

            string name = data[0];
            double average = double.Parse(data[1]);
            student = new Student(name, average);

            students.Add(student);
        }

        return students;
    }

    public static async Task<List<Student>> ReadStudentsFromFileV3Async(string fileName)
    {
        string path = Path.Combine("source", fileName);
        Student student = null;
        List<Student> students = new List<Student>();
        bool isNumber = false;

        IAsyncEnumerable<string> lines = File.ReadLinesAsync(path, Encoding.UTF7);

        await foreach (var line in lines)
        {
            string[] data = line.Split('\t');
            if (data.Length != 2)
            {
                throw new FormatException("Invalid file format");
            }

            string name = data[0];
            isNumber = double.TryParse(data[1], out double average);

            if (!isNumber)
            {
                continue;
            }

            student = new Student(name, average);
            students.Add(student);
        }

        return students;
    }

    public static async Task<List<Student>> ReadStudentsFromFileV4Async(string fileName)
    {
        string path = Path.Combine("source", fileName);
        Student student = null;
        List<Student> students = new List<Student>();

        string text = File.ReadAllText(path, Encoding.UTF7);

        string[] lines = text.Split(Environment.NewLine);

        foreach (var line in lines.Skip(1))
        {
            string[] data = line.Split('\t');
            if (data.Length != 2)
            {
                throw new FormatException("Invalid file format");
            }

            string name = data[0];
            double average = double.Parse(data[1]);
            student = new Student(name, average);

            students.Add(student);
        }

        return students;
    }

    #endregion

    #region File Write
    public static async Task WriteToFileV1Async(string fileName, ICollection<Student> students)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", $"{fileName}.txt");


        using FileStream fs
            = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF7);

        foreach (var student in students)
        {
            await sw.WriteLineAsync($"{student.Name}\t{student.Average}");
        }


    }

    public static async Task WriteToFileV2Async(string fileName, ICollection<Student> students)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", $"{fileName}.txt");

        List<string> data = new List<string>();
        foreach (var student in students)
        {
            data.Add($"{student.Name}\t{student.Average}");
        }

        await File.WriteAllLinesAsync(path, data);
    }

    public static async Task WriteToFileV3Async(string fileName, ICollection<Student> students)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", $"{fileName}.txt");

        StringBuilder contents = new StringBuilder();

        foreach(var student in students)
        {
            contents.AppendLine($"{student.Name}\t{student.Average}");
        }

        await File.WriteAllTextAsync(path, contents.ToString(), Encoding.UTF8);
    }

    #endregion
}
