using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TransactionNavigator.Models;

namespace TransactionNavigator.Services;

public class UserService
{
    private readonly ILogger<UserService> m_logger;
    private readonly PasswordHash m_passwordHash;
    
    public UserProfile CurrentUser { get; set; }
    
    
    public UserService(ILogger<UserService> p_logger, PasswordHash p_passwordHash)
    {
        m_logger = p_logger;
        m_passwordHash = p_passwordHash;
        m_logger.LogInformation("UserService was initialized");
    }
    
    public async Task<UserProfile> AttemptLogin(string p_username, string p_password)
    {
        m_logger.LogDebug("Attempting Login");
        if (p_username == "test" && p_password == "test")
        {
            return new UserProfile()
            {
                Username = p_username,
                LastLogin = DateTime.UtcNow
            };
        }
        throw new Exception("Incorrect Username or Password");
    }


    
}