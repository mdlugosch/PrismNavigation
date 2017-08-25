using Microsoft.Practices.Prism.MefExtensions;
using System.ComponentModel.Composition.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismNavigation.MVVM
{
    public class MyBootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<ShellWindow>();
        }
        protected override void ConfigureAggregateCatalog()
        {
            var assemblyCatalog = new AssemblyCatalog(typeof(MyBootstrapper).Assembly);
            AggregateCatalog.Catalogs.Add(assemblyCatalog);

            /*
            assemblyCatalog = new AssemblyCatalog(typeof(AddInA.ModuleA).Assembly);
            AggregateCatalog.Catalogs.Add(assemblyCatalog);

            assemblyCatalog = new AssemblyCatalog(typeof(AddInB.ModuleB).Assembly);
            AggregateCatalog.Catalogs.Add(assemblyCatalog);
            */
            base.ConfigureAggregateCatalog();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (ShellWindow)Shell;
            Application.Current.MainWindow.Show();
        }
    }
}
