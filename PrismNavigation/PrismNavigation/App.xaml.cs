﻿using PrismNavigation.MVVM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrismNavigation
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        MyBootstrapper bs = new MyBootstrapper();

        protected override void OnStartup(StartupEventArgs e)
        {
            bs.Run();
        }
    }
}
