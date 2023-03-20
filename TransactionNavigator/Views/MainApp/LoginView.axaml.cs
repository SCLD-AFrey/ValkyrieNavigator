using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using TransactionNavigator.ViewModels.MainApp;

namespace TransactionNavigator.Views.MainApp;

public partial class LoginView : UserControl
{
#pragma warning disable CS8618
    public LoginView() { }
#pragma warning restore CS8618
    private readonly ILogger<LoginView> m_logger;
    public LoginView(ILogger<LoginView> p_logger, LoginViewModel p_viewModel)
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