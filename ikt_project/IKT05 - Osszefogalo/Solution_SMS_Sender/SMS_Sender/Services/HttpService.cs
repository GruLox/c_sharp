using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace SMS_Sender.Services;

public class HttpService : IHttpService
{
    private static HttpClient _httpClient;
    private const string BASE_URL = "https://localhost:7112";
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public HttpService()
    {
        _httpClient = new HttpClient();
        SetHeaders();
    }

    /// <summary>
    /// Sends a POST request to the specified route, containing the body serialized as a JSON in the request body
    /// </summary>
    /// <param name="route">The route part without the base url</param>
    /// <param name="body">The request body object</param>
    /// <returns></returns>
    public async Task<TResponse> SendPostRequestAsync<TResponse>(string route, object body)
    {
        try
        {
            var request = BuildRequestMessage(HttpMethod.Post, route, body);

            var response = await _httpClient.SendAsync(request); 
            //response.EnsureSuccessStatusCode();

            var content = await SerializeResponseAsync<TResponse>(response.Content);
            return content;
        }
        catch (Exception ex)
        {
            return (TResponse)default;
        }
    }

    private async Task<T> SerializeResponseAsync<T>(HttpContent content)
    {
        var encoding = content.Headers.ContentEncoding.FirstOrDefault();
        var responseStream = await content.ReadAsStreamAsync();
        var stream = encoding switch
        {
            "gzip" => new GZipStream(responseStream, CompressionMode.Decompress),
            "deflate" => new DeflateStream(responseStream, CompressionMode.Decompress),
            "br" => new BrotliStream(responseStream, CompressionMode.Decompress),
            _ => responseStream

        };

        var result = JsonSerializer.Deserialize<T>(stream, _options);
        return result;
    }

    private HttpRequestMessage BuildRequestMessage(HttpMethod httpMethod, string route, object body)
    {
        return new HttpRequestMessage
        {
            Method = httpMethod,
            RequestUri = BuildUri(route),
            Content = body is not null ?
                      new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, MediaTypeNames.Application.Json) :
                      null
        };
    }

    private void SetHeaders()
    {
        _httpClient.BaseAddress ??= new Uri(BASE_URL);

        if (!_httpClient.DefaultRequestHeaders.Any())
        {
            _httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("plain/text"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }

    private Uri BuildUri(string route) => new Uri($"{BASE_URL}/{route}");

    private Uri BuildUri(string route, object routParam) => new Uri($"{BASE_URL}/{route}/{routParam}");
}
