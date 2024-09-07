using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PlaygroundGenericHostConsole.Services;

public class ConsoleApplicationHostedService(
    IHostEnvironment HostEnvironment,
    IConfiguration Configuration,
    ILogger<ConsoleApplicationHostedService> Logger,
    IHostApplicationLifetime ApplicationLifetime
) : IHostedService
{
    // REF: https://learn.microsoft.com/ja-jp/dotnet/api/system.threading.tasks.task.yield?view=net-8.0

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        ApplicationLifetime.ApplicationStarted.Register(OnStarted);
        ApplicationLifetime.ApplicationStopping.Register(OnStopping);
        ApplicationLifetime.ApplicationStopped.Register(OnStopped);

        Logger.LogInformation(new EventId(), "Called -> StartAsync()");

#if DEBUG
        var applicationName = HostEnvironment.ApplicationName;
        var environmentName = HostEnvironment.EnvironmentName;
        var configurations = Configuration.AsEnumerable().ToList();
#endif

        await Task.Yield();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Logger.LogInformation(new EventId(), "Called -> StopAsync()");

        await Task.Yield();
    }

    private async void OnStarted()
    {
        Logger.LogInformation("Called -> OnStarted()");

        await Task.Yield();
    }

    private async void OnStopping()
    {
        Logger.LogInformation("Called -> OnStopping()");

        await Task.Yield();
    }

    private async void OnStopped()
    {
        Logger.LogInformation("Called -> OnStopped()");

        await Task.Yield();
    }
}
