using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClientApp.Models;
using ClientApp.Services.Database;
using ClientApp.Services.Infrastructure;
using DevExpress.Xpo;
using TransactionData;

namespace ClientApp.Services;

public class SettingsService
{
    private readonly CommonFiles m_fileService;
    private readonly TransactionDatabaseInterface m_dbInterface;
    public SettingsService(CommonFiles p_fileService, TransactionDatabaseInterface p_dbInterface)
    {
        m_fileService = p_fileService;
        m_dbInterface = p_dbInterface;
        if (!File.Exists(m_fileService.SettingsPath))
        {
            JsonSerializerOptions options =
                new()
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    WriteIndented = true
                };
            var jsonString = JsonSerializer.Serialize(new Settings(), options);
            File.WriteAllText(m_fileService.SettingsPath, jsonString);
        }

        //Get Settings
        var newJsonString = File.ReadAllText(m_fileService.SettingsPath);
        var settings = JsonSerializer.Deserialize<Settings>(newJsonString)!;
        
        using var unitOfWork = m_dbInterface.ProvisionUnitOfWork();
        CurrentUser = settings.LastUserOid switch
        {
            > 0 => unitOfWork.GetObjectByKey<User>(settings.LastUserOid),
            _ => new User(unitOfWork)
        };
        AppName = settings.AppName;
        AppVersion = settings.AppVersion;
    }
    
    public User? CurrentUser { get; set; }
    public string? AppVersion { get; set; }
    public string? AppName { get; set; }
    
    public void SaveSettings()
    {
        JsonSerializerOptions options =
            new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            };
        var jsonString = JsonSerializer.Serialize(new Settings()
        {
            LastUserOid = CurrentUser.Oid,
            AppName = AppName,
            AppVersion = AppVersion
        }, options);
        File.WriteAllText(m_fileService.SettingsPath, jsonString);
    }

}