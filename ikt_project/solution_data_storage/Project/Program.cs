var host = CreateHostBuilder(args).Build();

var studentManager = host.Services.GetRequiredService<IStudentManager>();
await studentManager.Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IConsoleService, ConsoleService>();
            services.AddSingleton<IJsonUtilities, JsonUtilities>();
            services.AddSingleton<IStudentManager>(serviceProvider =>
                new StudentManager(
                    serviceProvider.GetRequiredService<IConsoleService>(),
                    serviceProvider.GetRequiredService<IJsonUtilities>(),
                    "students.json",
                    "subjects.json"
                ));
        });

