﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using TransactionNavigator.ViewModels.MainApp;

namespace TransactionNavigator.Views.MainApp;

public partial class AccountsView : UserControl
{
#pragma warning disable CS8618
    public AccountsView() { }
#pragma warning restore CS8618
    private readonly ILogger<AccountsView> m_logger;
    public AccountsView(ILogger<AccountsView> p_logger, AccountsViewModel p_viewModel)
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