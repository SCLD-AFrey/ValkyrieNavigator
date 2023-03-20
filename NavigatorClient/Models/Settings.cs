using System.Collections.ObjectModel;
using System.Data.Common;
using TransactionData;

namespace NavigatorClient.Models;

public class Settings
{
    public UserProfile LastUser { get; set; } = new();
    public string RootDataFolder { get; set; } = ".TransactionNavigatorXp";
}
