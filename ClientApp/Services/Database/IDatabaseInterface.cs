using DevExpress.Xpo;

namespace ClientApp.Services.Database;

public interface IDatabaseInterface
{
    public IDataLayer DataLayer { get; }

    public UnitOfWork ProvisionUnitOfWork();
}