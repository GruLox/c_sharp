public static class FileService
{
    public static async Task<List<Student>> ReadStudentsFromFileAsync(string fileName)
    {
        var students = new List<Student>();

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF8);

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
}
