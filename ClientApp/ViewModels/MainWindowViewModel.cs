using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Controls;
using ClientApp.Services;
using ClientApp.Services.Database;
using ClientApp.Services.Infrastructure;
using ClientApp.ViewModels.MainApp;
using ClientApp.Views.MainApp;
using DevExpress.Xpo;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TransactionData;

namespace ClientApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly TransactionDatabaseInterface m_dbInterface;
    private readonly CommonFiles m_commonFiles;
    private readonly PasswordHash m_passwordHash;
    public MainWindowViewModel(TransactionDatabaseInterface p_dbInterface, CommonFiles p_commonFiles, PasswordHash p_passwordHash)
    {
        m_dbInterface = p_dbInterface;
        m_commonFiles = p_commonFiles;
        m_passwordHash = p_passwordHash;
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
        using var unitOfWork = m_dbInterface.ProvisionUnitOfWork();
        User? user = unitOfWork.Query<User>().FirstOrDefault(p_x => p_x.Username.ToLower() == Username.ToLower());
        
        if (user != null)
        {
            if (m_passwordHash.VerifyPassword(Password, user.Password, user.Salt))
            {
                CurrentUserOid = user.Oid;
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
    }
    
}