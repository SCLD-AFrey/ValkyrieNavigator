using Serilog.Events;

namespace TransactionNavigator.Models.Logging;

public class ConsoleLogMessage
{
    public LogEventLevel LogLevel { get; set; }
    public string? Text { get; set; }
}