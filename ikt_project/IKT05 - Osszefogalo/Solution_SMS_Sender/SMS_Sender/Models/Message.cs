namespace SMS_Sender.Models;

public class Message
{
    [JsonPropertyName("system")]
    public MobileOperatingSystem System { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("mobileNumber")]
    public string MobileNumber { get; set; }

    [JsonPropertyName("message")]
    public string MessageContent { get; set; }
}
