using System;
using System.Collections.ObjectModel;
using System.Linq;
using ClientApp.Services.Database;
using DevExpress.Xpo;
using ReactiveUI.Fody.Helpers;
using TransactionData;

namespace ClientApp.Services;

public class TransactionService
{
    private readonly TransactionDatabaseInterface m_dbInterface;
    public DateTime StartDate { get; set; } = DateTime.UtcNow.AddMonths(-1);
    public DateTime EndDate { get; set; } = DateTime.UtcNow;
    
    
    public TransactionService(TransactionDatabaseInterface p_dbInterface)
    {
        m_dbInterface = p_dbInterface;
    }

    public Collection<Transaction> GetTransactions()
    {
        using var unitOfWork = m_dbInterface.ProvisionUnitOfWork();
        var transactions = unitOfWork.Query<Transaction>().Where(p_x => p_x.TransactionDate >= StartDate && p_x.TransactionDate <= EndDate);
        return new Collection<Transaction>(transactions.ToList());;
    }
    public Transaction GetTransaction(int p_oid)
    {
        using var unitOfWork = m_dbInterface.ProvisionUnitOfWork();
        return unitOfWork.GetObjectByKey<Transaction>(p_oid);
    }
}