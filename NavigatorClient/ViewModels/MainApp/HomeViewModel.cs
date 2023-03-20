using Microsoft.Extensions.Logging;

namespace NavigatorClient.ViewModels.MainApp;

public class HomeViewModel : ViewModelBase
{
    private readonly ILogger<HomeViewModel> m_logger;

    public HomeViewModel(ILogger<HomeViewModel> p_logger)
    {
        m_logger = p_logger;
        m_logger.LogInformation("HomeViewModel was initialized");
    }
}