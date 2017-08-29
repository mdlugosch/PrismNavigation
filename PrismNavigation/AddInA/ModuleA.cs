using AddInA.Views;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using PrismNavigation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddInA
{
    [ModuleExport(typeof(ModuleA))]
    public class ModuleA : IModule
    {
        [Import]
        public IRegionManager regionManager;

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion, typeof(AddInANavigationView));
        }

    }
}
