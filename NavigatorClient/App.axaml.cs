using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NavigatorClient.Models.Logging;
using NavigatorClient.Services;
using NavigatorClient.Services.Database;
using NavigatorClient.Services.Infrastructure;
using NavigatorClient.ViewModels;
using NavigatorClient.ViewModels.MainApp;
using NavigatorClient.Views;
using NavigatorClient.Views.MainApp;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace NavigatorClient;

public partial class App : Application
{
    public readonly IHost m_appHost;
    
    public App()
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

        p_services.AddSingleton<MainWindowViewModel>();
        p_services.AddSingleton<MainWindow>();

        p_services.AddSingleton<MainViewModel>();
        p_services.AddSingleton<LoginViewModel>();
        p_services.AddSingleton<AccountsViewModel>();
        p_services.AddSingleton<HomeViewModel>();
        p_services.AddSingleton<SettingsViewModel>();
        p_services.AddSingleton<TransactionsViewModel>();

        p_services.AddSingleton<MainView>();
        p_services.AddSingleton<LoginView>();
        p_services.AddSingleton<AccountsView>();
        p_services.AddSingleton<HomeView>();
        p_services.AddSingleton<SettingsView>();
        p_services.AddSingleton<TransactionsView>();
    }

    public override async void OnFrameworkInitializationCompleted()
    {
#if DEBUG
        var logLevel = LogEventLevel.Debug;
#else
        var logLevel = LogEventLevel.Information;
#endif
        
        var filesService = m_appHost.Services.GetRequiredService<CommonFiles>();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(logLevel)
            .WriteTo.Sink(new CollectionSink())
            .WriteTo.File(new JsonFormatter(), filesService.LogsPath)
            .CreateLogger();
    
    
        await m_appHost.StartAsync();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var dbInitializationService = m_appHost.Services.GetRequiredService<TransactionDatabaseInitialization>();
            await dbInitializationService.DoFirstTimeSetup();
            
            desktop.ShutdownRequested += DesktopOnShutdownRequested;
            desktop.MainWindow = new MainWindow()
            {
                DataContext = m_appHost.Services.GetRequiredService<MainWindowViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private async void DesktopOnShutdownRequested(object? p_sender, ShutdownRequestedEventArgs p_e)
    {
        await m_appHost.StopAsync();
    }
}