using System.Collections.ObjectModel;
using TransactionData;

namespace NavigatorClient.Models;

public class Settings
{
    public UserProfile LastUser { get; set; } = new();
}
