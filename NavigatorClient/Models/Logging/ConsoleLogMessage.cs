using Serilog.Events;

namespace NavigatorClient.Models.Logging;

public class ConsoleLogMessage
{
    public LogEventLevel LogLevel { get; set; }
    public string? Text { get; set; }
}