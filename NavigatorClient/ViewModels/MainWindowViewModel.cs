using System;
using System.Text;
using Avalonia.Collections;
using Microsoft.Extensions.Logging;
using NavigatorClient.Models;
using NavigatorClient.Models.Logging;
using NavigatorClient.Services;
using NavigatorClient.ViewModels.MainApp;
using NavigatorClient.Views.MainApp;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TextCopy;
using TransactionData;

namespace NavigatorClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ILogger<MainWindowViewModel> m_logger;
    private readonly  IServiceProvider            m_serviceProvider;


    public MainWindowViewModel(ILogger<MainWindowViewModel> p_logger, 
        UserService p_userService, 
        SettingsService p_settingsService, 
        NavigationService p_navigationService, 
        IServiceProvider p_serviceProvider)
    {
        m_logger = p_logger;
        
        SettingsService = p_settingsService;
        UserService = p_userService;
        NavigationService = p_navigationService;
        
        m_serviceProvider = p_serviceProvider;

        WindowTitle = $"Valkyrie Navigator Client";
        m_logger.LogInformation("MainWindowViewModel was initialized");

    }
    [Reactive] public NavigationService NavigationService { get; set; }
    [Reactive] public UserService UserService { get; set; }
    [Reactive] public SettingsService SettingsService { get; set; }
    [Reactive] public string WindowTitle { get; set; }

    [Reactive] public AvaloniaList<ConsoleLogMessage> Messages         { get; set; } = new ();
    [Reactive] public AvaloniaList<ConsoleLogMessage> SelectedMessages { get; set; } = new ();

    public void CopyMessages()
    {
        var selectedText = new StringBuilder();

        foreach ( var message in SelectedMessages )
        {
            selectedText.AppendLine(message.Text);
        }
            
        ClipboardService.SetText(selectedText.ToString());
    }
}