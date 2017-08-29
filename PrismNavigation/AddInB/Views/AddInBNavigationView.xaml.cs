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

namespace AddInB.Views
{
    /// <summary>
    /// Interaktionslogik für AddInBNavigationView.xaml
    /// </summary>
    [Export]
    [ViewSortHint("02")]
    public partial class AddInBNavigationView : UserControl
    {
        private static Uri AddInAViewUri = new Uri("AddInBView", UriKind.Relative);

        [Import]
        public IRegionManager regionManager;

        public AddInBNavigationView()
        {
            InitializeComponent();
        }

        private void NavigateToModuleB_Click(object sender, RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate(RegionNames.MainContentRegion, AddInAViewUri, CheckForError);
        }

        void CheckForError(Microsoft.Practices.Prism.Regions.NavigationResult nr)
        {
            if (nr.Result == false)
            {
                throw new Exception(nr.Error.Message);
            }
        }
    }
}
