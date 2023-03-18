using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using NavigatorClient.ViewModels.MainApp;

namespace NavigatorClient.Views.MainApp;

public partial class TransactionsView : UserControl
{
#pragma warning disable CS8618
    public TransactionsView() { }
#pragma warning restore CS8618
    private readonly ILogger<TransactionsView> m_logger;
    public TransactionsView(ILogger<TransactionsView> p_logger, TransactionsViewModel p_viewModel)
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