namespace TransactionNavigator.Models;

public class Settings
{
    public UserProfile LastUser { get; set; } = new();
    public string RootDataFolder { get; set; } = ".TransactionNavigatorXp";
}
