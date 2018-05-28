using BleedifyPersonal.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace BleedifyPersonal.Views
{
    /// <summary>
    /// Interaction logic for ManageDonatiiView.xaml
    /// </summary>
    public partial class ManageDonatiiView : UserControl
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
