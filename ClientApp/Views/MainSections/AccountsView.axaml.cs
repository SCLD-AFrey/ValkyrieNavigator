using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ClientApp.Views.MainSections;

public partial class AccountsView : UserControl
{
    public AccountsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}