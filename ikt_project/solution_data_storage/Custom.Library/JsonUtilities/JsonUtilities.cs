

namespace Custom.Library.JsonUtilities;

public static class JsonUtilities
{
    public static async Task<List<T>> LoadDataFromJSON<T>(string fileName)
    {
        string path = Path.Combine("Data", fileName);

        string json = await File.ReadAllTextAsync(path);
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter());
        return JsonSerializer.Deserialize<List<T>>(json, options)!;
    }

    public static async Task SaveDataToJSON<T>(ICollection<T> data, string fileName)
    {
        // Get the project directory
        string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;

        string path = Path.Combine(projectDirectory, "Data", fileName);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        options.Converters.Add(new JsonStringEnumConverter());

        string json = JsonSerializer.Serialize(data, options);

        await File.WriteAllTextAsync(path, json, Encoding.UTF8);
    }
}
