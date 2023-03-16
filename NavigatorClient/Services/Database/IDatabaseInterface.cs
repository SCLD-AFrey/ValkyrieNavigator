using DevExpress.Xpo;

namespace NavigatorClient.Services.Database;

public interface IDatabaseInterface
{
    public IDataLayer DataLayer { get; }

    public UnitOfWork ProvisionUnitOfWork();
}