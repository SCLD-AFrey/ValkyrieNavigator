using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using TransactionNavigator.Services.Infrastructure;

namespace TransactionNavigator.Services.Database;

public class DatabaseUtilities
{
    private readonly CommonFiles m_commonFilesService;

    public DatabaseUtilities(CommonFiles p_commonFilesService)
    {
        m_commonFilesService = p_commonFilesService;
    }

    public IDataLayer GetDataLayer(string p_databaseLocation)
    {
        var connectionString = SQLiteConnectionProvider.GetConnectionString(m_commonFilesService.DatabasePath);
        return new SimpleDataLayer(XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema));
    }
}