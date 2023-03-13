using System.Reactive;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Controls;
using ClientApp.ViewModels.MainApp;
using ClientApp.Views.MainApp;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ClientApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        LoginView = new LoginView()
        {
            DataContext = this
        };
        MainView = new MainView();
        SelectedIndex = CurrentUserOid switch
        {
            > 0 when SelectedIndex == 0 => 1,
            0 => 0,
            _ => SelectedIndex
        };
    }


    [Reactive] public int SelectedIndex { get; set; } = 0;
    [Reactive] public MainView MainView { get; set; }
    [Reactive] public LoginView LoginView { get; set; }
    public string WindowTitle => "Valkyrie Client Navigator";
    [Reactive] public int CurrentUserOid { get; private set; } = 0;
    [Reactive] public string Username { get; private set; } = "";
    [Reactive] public string Password { get; private set; } = "";
    [Reactive] public string LoginMessage { get; set; } = string.Empty;

    public async Task LoginCommand()
    {
        CurrentUserOid = 0;
        
        if (Username.Trim().ToLower() == "admin")
        {
            if (Password.Equals("password"))
            {
                CurrentUserOid = 1;
            }
            else
            {
                LoginMessage = "Invalid Password";
            }
        }
        else
        {
            LoginMessage = "Invalid Username";
        }
        if(CurrentUserOid > 0)
        {
            MainView.DataContext = new MainViewModel();
            SelectedIndex = 1;
        }
    }
    
}