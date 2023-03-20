using Microsoft.Extensions.Logging;

namespace TransactionNavigator.Services;

public class NavigationService
{
    private readonly ILogger<AccountsService> m_logger;
    public NavigationService( 
        ILogger<AccountsService> p_logger)
    {
        m_logger = p_logger;
        m_logger.LogInformation("NavigationService was initialized");
    }
    public int SelectedPageIndex { get; set; } = 0;
}