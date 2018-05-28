using BleedifyPersonal.ViewModels;
using MahApps.Metro.Controls;

namespace BleedifyPersonal.Views
{
    /// <summary>
    /// Interaction logic for RegisterMedic.xaml
    /// </summary>
    public partial class RegisterPersonal : MetroWindow
    {
        public RegisterPersonal()
        {
            InitializeComponent();
	        DataContext = new RegisterPersonalViewModel();
        }
    }
}
