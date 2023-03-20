using System;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using TransactionNavigator.Services;
using TransactionNavigator.Views.MainApp;

namespace TransactionNavigator.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    
    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly ILogger<MainWindowViewModel> m_logger;
    private readonly UserService m_userService;
    private readonly SettingsService m_settingsService;

    public MainWindowViewModel(ILogger<MainWindowViewModel> p_logger, UserService p_userService, SettingsService p_settingsService)
    {
        m_logger = p_logger;
        m_userService = p_userService;
        m_settingsService = p_settingsService;
        m_selectedIndex = 0;
        this.WhenAnyValue(p_x => p_x.SelectedIndex)
            .Subscribe(p_x => OnSelectedIndexChanged());
        m_logger.LogInformation("MainWindowViewModel was initialized");
    }

    private void OnSelectedIndexChanged()
    {
        switch (SelectedIndex)
        {
            case 1:
                CurrentView = m_homeView;
                m_logger.LogInformation("m_homeView was set as CurrentView");
                break;
            case 2:
                CurrentView = m_accountsView;
                m_logger.LogInformation("m_accountsView was set as CurrentView");
                break;
            case 3:
                CurrentView = m_transactionsView;
                m_logger.LogInformation("m_transactionsView was set as CurrentView");
                break;
            case 4:
                CurrentView = m_settingsView;
                m_logger.LogInformation("m_settingsView was set as CurrentView");
                break;
            default:
                CurrentView = m_loginView;
                m_logger.LogInformation("m_loginView was set as CurrentView");
                break;
        }
    }
    
    private int m_selectedIndex;
    public int SelectedIndex
    {
        get => m_selectedIndex;
        set => this.RaiseAndSetIfChanged(ref m_selectedIndex, value);
    }
    
    private object _currentView;
    public object CurrentView
    {
        get { return _currentView; }
        set { this.RaiseAndSetIfChanged(ref _currentView, value); }
    }
    
    
    private readonly AccountsView m_accountsView = new();
    private readonly HomeView m_homeView = new();
    private readonly LoginView m_loginView = new();
    private readonly SettingsView m_settingsView = new();
    private readonly TransactionsView m_transactionsView = new();

}