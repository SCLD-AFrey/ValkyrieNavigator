using System;
using System.Collections.ObjectModel;
using ClientApp.Services;
using DevExpress.Xpo;
using ReactiveUI.Fody.Helpers;
using TransactionData;

namespace ClientApp.ViewModels.MainSections;

public class TransactionsViewModel : ViewModelBase
{
    private readonly TransactionService m_transactionService;

    public TransactionsViewModel(TransactionService p_transactionService)
    {
        m_transactionService = p_transactionService;
        var Transactions = m_transactionService.GetTransactions();
    }
    
    [Reactive] public DateTime StartDate { get; set; } = DateTime.UtcNow.AddMonths(-1);
    [Reactive] public DateTime EndDate { get; set; } = DateTime.UtcNow;
    [Reactive] public Collection<Transaction> Transactions { get; set; } = new();
}