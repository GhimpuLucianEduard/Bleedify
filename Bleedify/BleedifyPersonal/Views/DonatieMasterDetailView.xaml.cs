

using BleedifyPersonal.ViewModels;
using System.Windows;

namespace BleedifyPersonal.Views
{
    /// <summary>
    /// Interaction logic for DonatieMasterDetailView.xaml
    /// </summary>
    public partial class DonatieMasterDetailView : Window
    {
        public DonatieMasterDetailView(DonatieDetailViewModel donatieViewModel)
        {

            InitializeComponent();


            ViewModel = donatieViewModel;
            


        }

        public DonatieDetailViewModel ViewModel
        {
            get { return DataContext as DonatieDetailViewModel; }
            set { DataContext = value; }
        }
    }
}
