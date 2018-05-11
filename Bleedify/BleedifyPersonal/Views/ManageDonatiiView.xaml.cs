using BleedifyPersonal.ViewModels;
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
using System.Windows.Shapes;

namespace BleedifyPersonal.Views
{
    /// <summary>
    /// Interaction logic for ManageDonatiiView.xaml
    /// </summary>
    public partial class ManageDonatiiView : Window
    {
        public ManageDonatiiView()
        {
            ViewModel = new ManageDonatiiViewModel();

            InitializeComponent();

            ViewModel.LoadDonationsCommand.Execute(null);
        }

        public ManageDonatiiViewModel ViewModel
        {
            get { return DataContext as ManageDonatiiViewModel; }
            set { DataContext = value;  }
        }
    }
}
