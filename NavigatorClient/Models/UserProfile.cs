using System;

namespace NavigatorClient.Models;

public class UserProfile
{
    public UserProfile(int p_oid = default, string? p_username = null, DateTime p_lastLogin = default)
    {
        Oid = p_oid;
        Username = p_username;
        LastLogin = p_lastLogin;
    }

    public int Oid { get; set; }
    public string? Username { get; set; }
    public DateTime LastLogin { get; set; }
}
