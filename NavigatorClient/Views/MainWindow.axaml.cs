using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using NavigatorClient.ViewModels;

namespace NavigatorClient.Views;

public partial class MainWindow : Window
{

    private readonly ILogger<MainWindow> m_logger;
    
    //Needed Annoyance
    #pragma warning disable CS8618
        public MainWindow() { }
    #pragma warning restore CS8618
    
    public MainWindow(ILogger<MainWindow> p_logger, MainWindowViewModel p_viewModel)
    {
        m_logger = p_logger;
        DataContext = p_viewModel;
        InitializeComponent();
        m_logger.LogInformation("MainWindow was initialized");

#if DEBUG
        this.AttachDevTools();
#endif
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void MainWindow_OnClosing(object? p_sender, CancelEventArgs p_e)
    {
        m_logger.LogDebug("Closing application was triggered");
    }
}