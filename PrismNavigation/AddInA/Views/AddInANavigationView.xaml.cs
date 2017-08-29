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

namespace AddInA.Views
{
    /// <summary>
    /// Interaktionslogik für AddInANavigationView.xaml
    /// </summary>
    [Export]
    [ViewSortHint("01")]
    public partial class AddInANavigationView : UserControl
    {

        
        private static Uri AddInAViewUri = new Uri("AddInAView", UriKind.Relative);

        [Import]
        public IRegionManager regionManager;
 
        public AddInANavigationView()
        {           
            InitializeComponent();
        }

        private void NavigateToModuleA_Click(object sender, RoutedEventArgs e)
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
