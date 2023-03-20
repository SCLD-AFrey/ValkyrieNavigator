using System;
using System.IO;

namespace TransactionNavigator.Services.Infrastructure
{
    public class CommonFiles
    {
        

        public CommonFiles()
        {
            AppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), ".TransactionNavigatorXp");

            LogsPath = Path.Combine(AppDataPath, "logs", "events.log");
            SettingsPath = Path.Combine(AppDataPath, "settings.ini");
            DatabasePath = Path.Combine(AppDataPath, "data", "transaction.db");

            CreateFolders();
            CreateNecessaryDirectories();
        }

        public string LogsPath { get; }
        public string SettingsPath { get; }
        public string DatabasePath { get; }
        public string AppDataPath { get; }
        
        private void CreateFolders()
        {
            var newDirectory = Directory.CreateDirectory(AppDataPath);
        }

        private void CreateNecessaryDirectories()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(LogsPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(DatabasePath) ?? string.Empty);
        }
    }
}