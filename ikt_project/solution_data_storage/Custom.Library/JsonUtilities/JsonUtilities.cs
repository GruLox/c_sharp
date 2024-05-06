
namespace Custom.Library.JsonUtilities;

public class JsonUtilities : IJsonUtilities
{
    private static readonly string _projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
    private static readonly JsonSerializerOptions _options = new()
    {
        Converters = { new JsonStringEnumConverter() },
        WriteIndented = true
    };

    public async Task<List<T>> LoadDataFromJSON<T>(params string[] pathSegments)
    {
        string path = Path.Combine(pathSegments);

        string json = await File.ReadAllTextAsync(path);

        return JsonSerializer.Deserialize<List<T>>(json, _options)!;
    }

    public async Task SaveDataToJSON<T>(ICollection<T> data, params string[] pathSegments)
    {
        // Combine the project directory with the path segments
        string[] fullPathSegments = new string[pathSegments.Length + 1];
        fullPathSegments[0] = _projectDirectory;
        Array.Copy(pathSegments, 0, fullPathSegments, 1, pathSegments.Length);
        string path = Path.Combine(fullPathSegments);
        string json = JsonSerializer.Serialize(data, _options);
        await File.WriteAllTextAsync(path, json, Encoding.UTF8);
    }
}
