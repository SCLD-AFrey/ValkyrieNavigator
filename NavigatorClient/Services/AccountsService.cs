using Microsoft.Extensions.Logging;

namespace NavigatorClient.Services;

public class AccountsService
{
    private readonly ILogger<AccountsService> m_logger;
    public AccountsService(ILogger<AccountsService> p_logger)
    {
        m_logger = p_logger;
    }
}