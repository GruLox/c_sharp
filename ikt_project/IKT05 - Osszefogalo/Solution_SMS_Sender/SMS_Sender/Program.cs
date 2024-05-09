var host = CreateHostBuilder(args).Build();

var userInterface = host.Services.GetRequiredService<IUserInterface>();
await userInterface.RunAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
            services.AddTransient<IHttpService, HttpService>()
                    .AddTransient<IJsonUtilities, JsonUtilities>()
                    .AddTransient<IMessageSender, WindowsMessageSender>()
                    .AddTransient<IMessageSender, IOSMessageSender>()
                    .AddTransient<IMessageSender, AndroidMessageSender>()
                    .AddTransient<IMessageSenderFactory, MessageSenderFactory>()
                    .AddTransient<IMenuService, MenuService>()
                    .AddTransient<IMessageManager, MessageManager>()
                    .AddTransient<IUserInterface, UserInterface>());