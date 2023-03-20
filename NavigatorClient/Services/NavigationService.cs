using System.Security.Cryptography;
using Microsoft.Extensions.Logging;
using NavigatorClient.ViewModels;
using NavigatorClient.ViewModels.MainApp;
using NavigatorClient.Views.MainApp;
using ReactiveUI;

namespace NavigatorClient.Services;

public class NavigationService
{
    private readonly ILogger<AccountsService> m_logger;
    public NavigationService(
        AccountsView p_accountsView, 
        HomeView p_homeView,  
        LoginView p_loginView,  
        SettingsView p_settingsView,  
        TransactionsView p_transactionsView, 
        ILogger<AccountsService> p_logger)
    {
        m_logger = p_logger;
        AccountsView = p_accountsView;
        HomeView = p_homeView;
        LoginView = p_loginView;
        SettingsView = p_settingsView;
        TransactionsView = p_transactionsView;
        m_logger.LogInformation("NavigationService was initialized");
    }
    public int SelectedPageIndex { get; set; } = 0;
    public int CurrentUserOid { get; set; }

    public AccountsView AccountsView { get; set; }
    public HomeView HomeView { get; set; }
    public LoginView LoginView { get; set; }
    public SettingsView SettingsView { get; set; }
    public TransactionsView TransactionsView { get; set; }
}