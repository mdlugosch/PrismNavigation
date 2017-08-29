using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddInA.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    class ViewModelA : BindableBase, INavigationAware
    {
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { }

        public void OnNavigatedTo(NavigationContext navigationContext)
        { }
    }
}
