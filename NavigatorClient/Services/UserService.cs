using System;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.Extensions.Logging;
using NavigatorClient.Models;
using NavigatorClient.Services.Database;
using TransactionData;

namespace NavigatorClient.Services;

public class UserService
{
    private ILogger<UserService> m_logger;
    private TransactionDatabaseInterface m_transactionDatabaseInterface;
    private PasswordHash m_passwordHash;
    public UserService(ILogger<UserService> p_logger, TransactionDatabaseInterface p_transactionDatabaseInterface, PasswordHash p_passwordHash)
    {
        m_logger = p_logger;
        m_transactionDatabaseInterface = p_transactionDatabaseInterface;
        m_passwordHash = p_passwordHash;
    }

    public async Task<UserProfile> AttemptLogin(string p_username, string p_password)
    {
        UnitOfWork uow = m_transactionDatabaseInterface.ProvisionUnitOfWork();
        m_logger.LogDebug("Attempting Login");
        User user = await uow.Query<User>().FirstOrDefaultAsync(p_u => p_u.Username == p_username);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        if (!m_passwordHash.VerifyPassword(p_password, user.Password, user.Salt))
        {
            throw new Exception("Incorrect Password");
        }
        return new UserProfile()
        {
            Oid = user.Oid,
            Username = user.Username,
            LastLogin = DateTime.UtcNow
        };
    }
    
}