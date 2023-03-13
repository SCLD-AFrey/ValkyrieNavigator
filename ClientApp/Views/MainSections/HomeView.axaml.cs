using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ClientApp.Views.MainSections;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}