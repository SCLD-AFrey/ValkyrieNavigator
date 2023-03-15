﻿using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace ClientApp.Services.Infrastructure;

public class CommonDirectories
{

    public CommonDirectories()
    {
        CreateFolders();
    }

    public string m_appDataPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), ".TransactionNavigatorXp");

    private void CreateFolders()
    {
        var newDirectory = Directory.CreateDirectory(m_appDataPath);
    }
}