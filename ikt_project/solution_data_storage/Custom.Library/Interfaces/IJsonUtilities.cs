namespace Custom.Library.Interfaces;

public interface IJsonUtilities
{
    Task<List<T>> LoadDataFromJSON<T>(params string[] pathSegments);
    Task SaveDataToJSON<T>(ICollection<T> data, params string[] pathSegments);
}
