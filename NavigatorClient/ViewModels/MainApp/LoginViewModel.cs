using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Microsoft.Extensions.Logging;
using NavigatorClient.Models;
using NavigatorClient.Services;
using NavigatorClient.Views.MainApp;
using ReactiveUI.Fody.Helpers;

namespace NavigatorClient.ViewModels.MainApp;

public class LoginViewModel : ViewModelBase
{
    private readonly ILogger<LoginViewModel> m_logger;
    private readonly UserService            m_userService;
    private readonly  IServiceProvider            m_serviceProvider;

    public LoginViewModel(ILogger<LoginViewModel> p_logger, 
        UserService p_userService, 
        IServiceProvider p_serviceProvider)
    {
        m_logger = p_logger;
        m_userService = p_userService;
        m_serviceProvider = p_serviceProvider;
        m_logger.LogInformation("LoginViewModel was initialized");
    }

    [Reactive] public string ValidationError { get; set; }
    [Reactive] public bool                        IsBusy                    { get; set; }
    public            int                         AttemptedLoginCount       { get; set; }
    [Reactive] public string                      Username                  { get; set; }
    [Reactive] public string                      Password                  { get; set; }

    public async Task ClickLogin()
    {
        IsBusy             = true;
            
        await Task.Delay(GetLoginDelayTime(AttemptedLoginCount));
        m_userService.CurrentUser = new UserProfile();

        try
        {
            m_userService.CurrentUser = await m_userService.AttemptLogin(Username, Password);
            m_logger.LogInformation("User logged in successfully");
        }
        catch (Exception e)
        {
            AttemptedLoginCount++;
            IsBusy          = false;
            ValidationError = e.Message;
            m_logger.LogError(e, "User failed to login");
        }
    }
    
    private int GetLoginDelayTime(int p_attemptedLoginCount)
    {
        return p_attemptedLoginCount switch
        {
            >= 3 and < 6 => 1000,
            >= 6 and < 8 => 2000,
            >= 8         => 30000,
            _            => 0
        };
    }

}