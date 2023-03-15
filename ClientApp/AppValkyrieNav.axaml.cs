using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ClientApp.Services;
using ClientApp.Services.Database;
using ClientApp.Services.Infrastructure;
using ClientApp.ViewModels;
using ClientApp.ViewModels.MainApp;
using ClientApp.ViewModels.MainSections;
using ClientApp.Views;
using ClientApp.Views.MainApp;
using ClientApp.Views.MainSections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ClientApp;

public partial class AppValkyrieNav : Application
{
    private readonly IHost m_appHost;
    
    public AppValkyrieNav()
    {
        m_appHost = Host.CreateDefaultBuilder()
            .ConfigureLogging(p_options =>
            {
                p_options.AddDebug();
                p_options.AddSerilog();
            })
            .ConfigureServices(ConfigureServices).Build();
    }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void ConfigureServices(IServiceCollection p_services)
    {
        p_services.AddSingleton<CommonDirectories>();
        p_services.AddSingleton<CommonFiles>();
        p_services.AddSingleton<PasswordHash>();
        
        p_services.AddSingleton<DatabaseUtilities>();
        p_services.AddSingleton<TransactionDatabaseInterface>();
        p_services.AddSingleton<TransactionDatabaseInitialization>();
        
        p_services.AddSingleton<SettingsService>();
        
        p_services.AddSingleton<MainWindowViewModel>();
        p_services.AddSingleton<MainWindowView>();
        
        
        p_services.AddSingleton<MainViewModel>();
        p_services.AddSingleton<AccountsViewModel>();
        p_services.AddSingleton<HomeViewModel>();
        p_services.AddSingleton<SettingsViewModel>();
        p_services.AddSingleton<TransactionsViewModel>();
        
        
        p_services.AddSingleton<LoginView>();
        p_services.AddSingleton<MainView>();
        p_services.AddSingleton<AccountsView>();
        p_services.AddSingleton<HomeView>();
        p_services.AddSingleton<SettingsView>();
        p_services.AddSingleton<TransactionsView>();
        
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindowView
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}