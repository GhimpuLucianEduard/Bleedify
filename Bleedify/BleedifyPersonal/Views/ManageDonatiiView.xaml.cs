using BleedifyPersonal.ViewModels;
using System.Windows;

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
