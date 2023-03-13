using ReactiveUI.Fody.Helpers;

namespace ClientApp.ViewModels.MainSections;

public class HomeViewModel : ViewModelBase
{
    public HomeViewModel()
    {
        PageHeaderText = "Home Page";
    }
    [Reactive] public string PageHeaderText { get; private set; }
}