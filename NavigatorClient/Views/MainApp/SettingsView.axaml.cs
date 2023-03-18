using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using NavigatorClient.ViewModels.MainApp;


namespace NavigatorClient.Views.MainApp;

public partial class SettingsView : UserControl
{
#pragma warning disable CS8618
    public SettingsView() { }
#pragma warning restore CS8618
    private readonly ILogger<SettingsView> m_logger;
    public SettingsView(ILogger<SettingsView> p_logger, SettingsViewModel p_viewModel)
    {
        m_logger = p_logger;
        InitializeComponent();
        DataContext = p_viewModel;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}