namespace SMS_Sender.Interfaces;

public interface IHttpService
{
    Task<T> SendPostRequestAsync<T>(string route, object requestBody);
}
