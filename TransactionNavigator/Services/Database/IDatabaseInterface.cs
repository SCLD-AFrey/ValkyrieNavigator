using DevExpress.Xpo;

namespace TransactionNavigator.Services.Database;

public interface IDatabaseInterface
{
    public IDataLayer DataLayer { get; }

    public UnitOfWork ProvisionUnitOfWork();
}