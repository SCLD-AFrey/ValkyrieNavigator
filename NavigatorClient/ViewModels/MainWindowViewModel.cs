using System;
using System.Text;
using Avalonia.Collections;
using Microsoft.Extensions.Logging;
using NavigatorClient.Models;
using NavigatorClient.Models.Logging;
using NavigatorClient.Services;
using NavigatorClient.ViewModels.MainApp;
using NavigatorClient.Views.MainApp;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TextCopy;
using TransactionData;

namespace NavigatorClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ILogger<MainWindowViewModel> m_logger;
    private readonly UserService m_userService;
    private readonly SettingsService m_settingsService;

    public MainWindowViewModel(ILogger<MainWindowViewModel> p_logger, 
        AccountsView p_accountsView, AccountsViewModel p_accountsViewModel, 
        HomeView p_homeView, HomeViewModel p_homeViewModel,
        LoginView p_loginView, LoginViewModel p_loginViewModel, 
        SettingsView p_settingsView, SettingsViewModel p_settingsViewModel, 
        TransactionsView p_transactionsView, TransactionsViewModel p_transactionsViewModel, 
        UserService p_userService, SettingsService p_settingsService)
    {
        m_logger = p_logger;
        LoginView = p_loginView;
        AccountsView = p_accountsView;
        AccountsViewModel = p_accountsViewModel;
        HomeView = p_homeView;
        HomeViewModel = p_homeViewModel;
        LoginViewModel = p_loginViewModel;
        SettingsView = p_settingsView;
        SettingsViewModel = p_settingsViewModel;
        TransactionsView = p_transactionsView;
        TransactionsViewModel = p_transactionsViewModel;
        m_userService = p_userService;
        m_settingsService = p_settingsService;

        WindowTitle = $"Valkyrie Navigator Client";
        m_logger.LogInformation("MainWindowViewModel was initialized");
        

        
        
        
    }

    [Reactive] public UserProfile CurrentUser { get; set; }
    [Reactive] public string WindowTitle { get; set; }
    public AccountsView AccountsView { get; set; }
    public AccountsViewModel AccountsViewModel { get; set; }
    public HomeView HomeView { get; set; }
    public HomeViewModel HomeViewModel { get; set; }
    public LoginView LoginView { get; set; }
    public LoginViewModel LoginViewModel { get; set; }
    public SettingsView SettingsView { get; set; }
    public SettingsViewModel SettingsViewModel { get; set; }
    public TransactionsView TransactionsView { get; set; }
    public TransactionsViewModel TransactionsViewModel { get; set; }

    [Reactive] public int SelectedPageIndex { get; set; } = 0;
    [Reactive] public AvaloniaList<ConsoleLogMessage> Messages         { get; set; } = new ();
    [Reactive] public AvaloniaList<ConsoleLogMessage> SelectedMessages { get; set; } = new ();

    public void CopyMessages()
    {
        var selectedText = new StringBuilder();

        foreach ( var message in SelectedMessages )
        {
            selectedText.AppendLine(message.Text);
        }
            
        ClipboardService.SetText(selectedText.ToString());
    }
}