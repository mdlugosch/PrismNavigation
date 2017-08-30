using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using PrismNavigation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrismNavigation
{
    /// <summary>
    /// Interaktionslogik für ShellWindow.xaml
    /// </summary>
    [Export]
    public partial class ShellWindow : Window, IPartImportsSatisfiedNotification
    {
        private const string StartModuleName = "ModuleA";
        private static Uri StartViewUri = new Uri("/AddInAView", UriKind.Relative);       

        public ShellWindow()
        {
            InitializeComponent();
        }

        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        [Import(AllowRecomposition = false)]
        public IRegionManager regionManager;

        public void OnImportsSatisfied()
        {                                        
            this.ModuleManager.LoadModuleCompleted += this.ModuleManager_LoadModuleCompleted;
        }

        private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            if (e.ModuleInfo.ModuleName == StartModuleName)
                this.regionManager.RequestNavigate(RegionNames.MainContentRegion, StartViewUri, CheckForError);
            else Console.WriteLine("Boom");
        }
        
        void CheckForError(Microsoft.Practices.Prism.Regions.NavigationResult nr)
        {
            if (nr.Result == false)
            {
                throw new Exception(nr.Error.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { }
    }
}
