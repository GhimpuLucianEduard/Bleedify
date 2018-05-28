using BleedifyDonator.ViewModels;
using MahApps.Metro.Controls;

namespace BleedifyDonator.Views
{
    /// <summary>
    /// Interaction logic for RegisterMedic.xaml
    /// </summary>
    public partial class RegisterDonator : MetroWindow
    {
        public RegisterDonator()
        {
            InitializeComponent();
	        DataContext = new RegisterDonatorViewModel();
        }
    }
}
