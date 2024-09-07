using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PlaygroundGenericHostConsole.Services;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureAppConfiguration(config => {
    config.AddCommandLine(args);
});
builder.ConfigureLogging(config => {
    // REF: https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/logging/?view=aspnetcore-8.0
    // REF: https://learn.microsoft.com/ja-jp/dotnet/core/extensions/logging?tabs=command-line
    // REF; https://qiita.com/TsuyoshiUshio@github/items/1ed49c90dc137d55bcfb
    config.ClearProviders();
    config.AddConsole();

    // https://learn.microsoft.com/ja-jp/dotnet/core/extensions/console-log-formatter
    config.AddSimpleConsole(options => {
        options.SingleLine = true;
        options.IncludeScopes = true;
        options.UseUtcTimestamp = true;
        options.TimestampFormat = "yyyy/MM/dd HH:mm:ss.ffffff ";
    });
});

builder.ConfigureServices(config => {
    config.AddHostedService<ConsoleApplicationHostedService>();
});

var app = builder.Build();

await app.RunAsync();
