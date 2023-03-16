using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using NavigatorClient.ViewModels.MainApp;


namespace NavigatorClient.Views.MainApp;

public partial class MainView : UserControl
{
#pragma warning disable CS8618
    public MainView() { }
#pragma warning restore CS8618
    private readonly ILogger<MainView> m_logger;
    public MainView(ILogger<MainView> p_logger, MainViewModel p_viewModel)
    {
        m_logger = p_logger;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}