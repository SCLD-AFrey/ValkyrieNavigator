using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using NavigatorClient.ViewModels.MainApp;


namespace NavigatorClient.Views.MainApp;

public partial class HomeView : UserControl
{
#pragma warning disable CS8618
    public HomeView() { }
#pragma warning restore CS8618
    private readonly ILogger<HomeView> m_logger;
    public HomeView(ILogger<HomeView> p_logger, HomeViewModel p_viewModel)
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