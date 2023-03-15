using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClientApp.Services.Infrastructure;
using DevExpress.Xpo;
using TransactionData;

namespace ClientApp.Services.Database;

public class TransactionDatabaseInitialization
{
    private readonly TransactionDatabaseInterface m_dbInterface;
    private readonly CommonFiles m_commonFiles;
    private readonly PasswordHash m_passwordHash;

    public TransactionDatabaseInitialization(TransactionDatabaseInterface p_dbInterface, CommonFiles p_commonFiles, PasswordHash p_passwordHash)
    {
        m_dbInterface = p_dbInterface;
        m_commonFiles = p_commonFiles;
        m_passwordHash = p_passwordHash;
    }
    public bool IsFirstRun { get; set; }

    public async Task DoFirstTimeSetup()
    {
        if (File.Exists(m_commonFiles.DatabasePath))
        {
            var fileInfo = new FileInfo(m_commonFiles.DatabasePath);
            if (fileInfo.Length == 0)
            {
                IsFirstRun = true;
                LoadDefaultUsers();
                LoadTransCategory();
                LoadTransMethod();
                LoadTransactions();
                IsFirstRun = true;
            }
        }
    }

    private void LoadTransactions()
    {
        using var unitOfWork = m_dbInterface.ProvisionUnitOfWork();
        var transaction = new Transaction(unitOfWork)
        {
            Amount = 0, 
            TransCategory = unitOfWork.Query<TransCategory>().First(p_x => p_x.Title == "Adjustment"),
            TransMethod = unitOfWork.Query<TransMethod>().First(p_x => p_x.Title == "Initial"),
            TransactionDate = DateTime.UtcNow
        };

        var history = new TransactionHistory(unitOfWork)
        {
            Transaction = transaction,
            DateModified = DateTime.UtcNow,
            ModifiedBy = unitOfWork.Query<User>().First(p_x => p_x.Username.ToLower() == "admin")
        };
        unitOfWork.CommitChanges();
    }
    private void LoadDefaultUsers()
    {
        using var unitOfWork = m_dbInterface.ProvisionUnitOfWork();
        var admin = new User(unitOfWork)
        {
            Username = "admin",
            Password = m_passwordHash.GeneratePasswordHash("password", out var salt1),
            Salt = salt1,
            IsAdmin = true,
            IsRoot = true 
        };
        var afrey = new User(unitOfWork)
        {
            Username = "afrey",
            Password = m_passwordHash.GeneratePasswordHash("password", out var salt2),
            Salt = salt2,
            IsAdmin = false,
            IsRoot = false 
        };
        unitOfWork.CommitChanges();
    }
    private void LoadTransCategory()
    {
        using var unitOfWork = m_dbInterface.ProvisionUnitOfWork();
        var q = new TransCategory(unitOfWork) { Title = "Housing" };
        var w = new TransCategory(unitOfWork) { Title = "Food" };
        var e = new TransCategory(unitOfWork) { Title = "Entertainment" };
        var r = new TransCategory(unitOfWork) { Title = "Clothing" };
        var t = new TransCategory(unitOfWork) { Title = "Utilities" };
        var y = new TransCategory(unitOfWork) { Title = "Adjustment", IsLocked = true};
        unitOfWork.CommitChanges();
    }
    private void LoadTransMethod()
    {
        using var unitOfWork = m_dbInterface.ProvisionUnitOfWork();
        var q = new TransMethod(unitOfWork) { Title = "Cash" };
        var e = new TransMethod(unitOfWork) { Title = "Debit Card" };
        var w = new TransMethod(unitOfWork) { Title = "Check" };
        var r = new TransMethod(unitOfWork) { Title = "E-Payment" };
        var t = new TransMethod(unitOfWork) { Title = "Initial", IsLocked = true};
        unitOfWork.CommitChanges();
    }
    
}