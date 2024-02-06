using System.Text.Encodings.Web;
using System.Text.Json;

public class Game
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Cím
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Előnézeti kép
    /// </summary>
    public string Thumbnail { get; set; }
    
    /// <summary>
    /// Rövid leírás
    /// </summary>
    public string ShortDescription { get; set; }
    
    /// <summary>
    /// Játek web címe
    /// </summary>
    public string GameUrl { get; set; }
    
    /// <summary>
    /// Zsáner
    /// </summary>
    public string Genre { get; set; }
    
    /// <summary>
    /// Platform
    /// </summary>
    public string Platform { get; set; }

    /// <summary>
    /// Forgalmazó
    /// </summary>
    public string Publisher { get; set; }

    /// <summary>
    /// Fejlesztő
    /// </summary>
    public string Developer { get; set; }

    /// <summary>
    /// Megejelnés dátuma
    /// </summary>
    public string ReleaseDate { get; set; }
    public string ProfileUrl { get; set; }

    public Game()
    {
    }

    public Game(int id, string title, string thumbnail, string short_description, string game_url, string genre, string platform, string publisher, string developer, string release_date, string profile_url)
    {
        Id = id;
        Title = title;
        Thumbnail = thumbnail;
        ShortDescription = short_description;
        GameUrl = game_url;
        Genre = genre;
        Platform = platform;
        Publisher = publisher;
        Developer = developer;
        ReleaseDate = release_date;
        ProfileUrl = profile_url;
    }

    public override string ToString()
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
        };

        return JsonSerializer.Serialize(this, options);
    }
}
