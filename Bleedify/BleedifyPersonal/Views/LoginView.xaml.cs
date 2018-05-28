using BleedifyPersonal.ViewModels;
using MahApps.Metro.Controls;

namespace BleedifyPersonal.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : MetroWindow
    {
        public LoginView()
        {
            InitializeComponent();
	        DataContext = new LoginViewModel();
        }
    }
}
