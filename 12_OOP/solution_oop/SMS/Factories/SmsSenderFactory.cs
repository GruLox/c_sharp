namespace SMS.Factories;

public class SmsSenderFactory 
{
    public ISmsSender GetSmsSender(Platform platform)
    {
        return platform switch
        {
            Platform.Windows => new WindowsSmsSender(),
            Platform.iOS => new IosSmsSender(),
            Platform.Android => new AndroidSmsSender(),
            _ => throw new NotImplementedException()
        };
    }
}
