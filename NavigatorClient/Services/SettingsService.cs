using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using NavigatorClient.Models;
using NavigatorClient.Services.Infrastructure;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace NavigatorClient.Services;

public class SettingsService
{
    private readonly ILogger<SettingsService> m_logger;
    private readonly CommonFiles m_commonFiles;
    public Settings Settings { get; set; } = new();

    public SettingsService(ILogger<SettingsService> p_logger, CommonFiles p_commonFiles)
    {
        m_logger = p_logger;
        m_commonFiles = p_commonFiles;
        Settings = new Settings();
        m_logger.LogInformation("SettingsService was initialized");
        Read();
    }

    public void Write()
    {
        JsonSerializerOptions options = 
            new() { 
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, 
                WriteIndented = true
            };
        var jsonString = JsonSerializer.Serialize(this, options);
        File.WriteAllText(m_commonFiles.SettingsPath, jsonString);
    }
    
    public void Read()
    {
        if (!File.Exists(m_commonFiles.SettingsPath))
        {
            Write();
        } 
        var jsonString = File.ReadAllText(m_commonFiles.SettingsPath);
        Settings = JsonConvert.DeserializeObject<Settings>(jsonString);

    }
}
    
