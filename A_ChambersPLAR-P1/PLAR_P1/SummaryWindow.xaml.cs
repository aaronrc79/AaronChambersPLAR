using System;
using System.Collections.Generic;
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

namespace PLAR_P1
{
    /// <summary>
    /// Interaction logic for SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : UserControl
    {
        public SummaryWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calls the DBL file (Database helper methods) to get the list of vehicles in the database
        /// sets the dataview to the result of the fetch
        /// </summary>
      public void ReloadData()
        {
            
            datagridVehicles.ItemsSource = DBL.GetVehicleList().DefaultView;
        }
    }
}
