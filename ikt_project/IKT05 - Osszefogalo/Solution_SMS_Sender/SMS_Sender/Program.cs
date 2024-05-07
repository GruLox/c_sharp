var host = CreateHostBuilder(args).Build();

var userInterface = host.Services.GetRequiredService<IUserInterface>();
await userInterface.Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
            services.AddScoped<IHttpService, HttpService>()
                    .AddScoped<IJsonUtilities, JsonUtilities>()
                    .AddScoped<IMessageSender, WindowsMessageSender>()
                    .AddScoped<IMessageSender, IOSMessageSender>()
                    .AddScoped<IMessageSender, AndroidMessageSender>()
                    .AddScoped<IMessageSenderFactory, MessageSenderFactory>()
                    .AddScoped<IMenuService, MenuService>()
                    .AddScoped<IMessageManager, MessageManager>()
                    .AddScoped<IUserInterface, UserInterface>());