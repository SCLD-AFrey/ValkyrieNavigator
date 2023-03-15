using System.IO;
using ClientApp.Services.Infrastructure;

namespace ClientApp.Models
{
    public class Settings
    {
        public int LastUserId { get; set; } = 0;
        private readonly CommonFiles m_commonFilesService;

        public Settings(CommonFiles p_commonFilesService)
        {
            m_commonFilesService = p_commonFilesService;
            
            if(!File.Exists(m_commonFilesService.SettingsPath))
                File.Create(m_commonFilesService.SettingsPath);
            File.WriteAllText(m_commonFilesService.SettingsPath, LastUserId.ToString());
            
        }

    }
}