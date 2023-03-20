using Microsoft.Extensions.Logging;

namespace TransactionNavigator.ViewModels.MainApp;

public class TransactionsViewModel : ViewModelBase
{
    private readonly ILogger<TransactionsViewModel> m_logger;

    public TransactionsViewModel(ILogger<TransactionsViewModel> p_logger)
    {
        m_logger = p_logger;
        m_logger.LogInformation("TransactionsViewModel was initialized");
    }
}