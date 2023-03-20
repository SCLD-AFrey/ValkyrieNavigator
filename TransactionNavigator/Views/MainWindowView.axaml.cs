using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using TransactionNavigator.ViewModels;

namespace TransactionNavigator.Views;

public partial class MainWindowView : Window
{
    private readonly ILogger<MainWindowViewModel> m_logger;

    //Needed Annoyance
#pragma warning disable CS8618
    public MainWindowView() { }
#pragma warning restore CS8618
    public MainWindowView(ILogger<MainWindowViewModel> p_logger, MainWindowViewModel p_viewModel)
    {
        {
            m_logger = p_logger;
            DataContext = p_viewModel;
            InitializeComponent();
            m_logger.LogInformation("MainWindow was initialized");

#if DEBUG
            this.AttachDevTools();
#endif
        }
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