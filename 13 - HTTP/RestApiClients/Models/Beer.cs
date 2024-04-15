
namespace Models;
public class Beer
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("price")]
    public string Price { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("rating")]
    public Rating Rating { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"========== BEER DETAILS ==========");
        sb.AppendLine($"ID: {Id}");
        sb.AppendLine($"Name: {Name}");
        sb.AppendLine($"Price: {Price}");
        sb.AppendLine($"Image URL: {Image}");
        sb.AppendLine($"Rating: {Rating.Average} ({Rating.Reviews} reviews)");
        sb.AppendLine($"==================================");

        return sb.ToString();
    }
}
