using System.IO;

namespace ClientApp.Services.Infrastructure
{
    public class CommonFiles
    {
        private readonly CommonDirectories m_commonDirectories;

        public CommonFiles(CommonDirectories p_commonDirectories)
        {
            m_commonDirectories = p_commonDirectories;


            LogsPath = Path.Combine(m_commonDirectories.m_appDataPath, "logs", "events.log");
            SettingsPath = Path.Combine(m_commonDirectories.m_appDataPath, "settings.ini");
            DatabasePath = Path.Combine(m_commonDirectories.m_appDataPath, "data", "transaction.db");

            CreateNecessaryDirectories();
        }

        public string LogsPath { get; }
        public string SettingsPath { get; }
        public string DatabasePath { get; }

        private void CreateNecessaryDirectories()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(LogsPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(DatabasePath) ?? string.Empty);
        }
    }
}