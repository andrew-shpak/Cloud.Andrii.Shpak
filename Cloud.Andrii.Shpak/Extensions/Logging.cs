using Amazon.CloudWatchLogs;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.AwsCloudWatch;
using Serilog.Sinks.SystemConsole.Themes;
using ILogger = Serilog.ILogger;

namespace Cloud.Andrii.Shpak.Extensions;

internal static class Logging
{
    internal static void AddLogging(this WebApplicationBuilder builder)
    {
        var client = new AmazonCloudWatchLogsClient();
        builder.Logging.ClearProviders();
        var configuration = new LoggerConfiguration();
        if (builder.Environment.IsProduction())
            configuration.WriteTo.AmazonCloudWatch(
                $"{builder.Environment.EnvironmentName}/{builder.Environment.ApplicationName}",
                DateTime.UtcNow.ToString("yyyyMMddHHmmssfff"),
                cloudWatchClient: client,
                textFormatter: new JsonFormatter(),
                restrictedToMinimumLevel: LogEventLevel.Information,
                logGroupRetentionPolicy: LogGroupRetentionPolicy.SixMonths
            );
        else
            configuration.WriteTo.Console(theme: AnsiConsoleTheme.Code);

        ILogger logger = configuration.CreateLogger();

        builder.Logging.AddSerilog(logger);
        builder.Services.AddSingleton(logger);
    }
}