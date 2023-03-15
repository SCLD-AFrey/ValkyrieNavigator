using System.IO;
using ClientApp.Services.Infrastructure;
using TransactionData;

namespace ClientApp.Models
{
    public class Settings
    {
        public string? AppName { get; set; } = "ClientApp";
        public string? AppVersion { get; set; } = "1.0.0";
        public int LastUserOid { get; set; } = 0;
    }
}