using Microsoft.Extensions.Logging;

namespace NavigatorClient.ViewModels.MainApp;

public class SettingsViewModel : ViewModelBase
{
    private readonly ILogger<SettingsViewModel> m_logger;

    public SettingsViewModel(ILogger<SettingsViewModel> p_logger)
    {
        m_logger = p_logger;
        m_logger.LogInformation("SettingsViewModel was initialized");
    }
}