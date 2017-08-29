using Microsoft.Practices.Prism.MefExtensions;
using System.ComponentModel.Composition.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;

namespace PrismNavigation.MVVM
{
    public class MyBootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<ShellWindow>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override void ConfigureAggregateCatalog()
        {
 

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(MyBootstrapper).Assembly));
            //this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AddInA.ModuleA).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AddInB.ModuleB).Assembly));

            base.ConfigureAggregateCatalog();

            //var assemblyCatalog = new AssemblyCatalog(typeof(MyBootstrapper).Assembly);
            //AggregateCatalog.Catalogs.Add(assemblyCatalog);

            //assemblyCatalog = new AssemblyCatalog(typeof(AddInA.ModuleA).Assembly);

            //AggregateCatalog.Catalogs.Add(assemblyCatalog);

            //assemblyCatalog = new AssemblyCatalog(typeof(AddInB.ModuleB).Assembly);
            //AggregateCatalog.Catalogs.Add(assemblyCatalog);

            //base.ConfigureAggregateCatalog();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (ShellWindow)Shell;
            Application.Current.MainWindow.Show();
        }
    }
}
