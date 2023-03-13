using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ClientApp.Views.MainSections;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}