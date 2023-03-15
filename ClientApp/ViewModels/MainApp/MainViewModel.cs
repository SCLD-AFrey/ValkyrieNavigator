using System;
using System.Threading.Tasks;
using ClientApp.ViewModels.MainSections;
using ClientApp.Views.MainSections;
using ReactiveUI.Fody.Helpers;

namespace ClientApp.ViewModels.MainApp;

public class MainViewModel : ViewModelBase
{
    private readonly IServiceProvider m_serviceProvider;
    public MainViewModel(IServiceProvider p_serviceProvider)
    {
        m_serviceProvider = p_serviceProvider;
        SelectedIndex = 0;
        HomeView = new HomeView() { DataContext = new HomeViewModel() };
        TransactionsView = new TransactionsView() { DataContext = new TransactionsViewModel() };
        AccountsView = new AccountsView() { DataContext = new AccountsViewModel() };
        SettingsView = new SettingsView() { DataContext = new SettingsViewModel() };
    }
    
    public void Navigation(object p_parameter)
    {
        SelectedIndex = p_parameter switch
        {
            "home" => 0,
            "transactions" => 1,
            "accounts" => 2,
            "settings" => 3,
            _ => 0
        };
    }
    
    [Reactive] public int SelectedIndex { get; set; } = 0;
    
    [Reactive] public HomeView HomeView { get; set; }
    [Reactive] public TransactionsView TransactionsView { get; set; }
    [Reactive] public AccountsView AccountsView { get; set; }
    [Reactive] public SettingsView SettingsView { get; set; }
}