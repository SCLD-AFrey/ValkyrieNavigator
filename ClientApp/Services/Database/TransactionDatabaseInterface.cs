using ClientApp.Services.Infrastructure;
using DevExpress.Xpo;
using TransactionData;

namespace ClientApp.Services.Database;

public class TransactionDatabaseInterface
{
    private readonly IDatabaseInterface m_databaseInterface;

    public TransactionDatabaseInterface(DatabaseUtilities p_utilities, CommonFiles p_commonFiles)
    {
        DataLayer = p_utilities.GetDataLayer(p_commonFiles.DatabasePath);
    }
    
    public IDataLayer DataLayer     { get; }
    
    public UnitOfWork ProvisionUnitOfWork()
    {
        return new UnitOfWork(DataLayer);
    }
}