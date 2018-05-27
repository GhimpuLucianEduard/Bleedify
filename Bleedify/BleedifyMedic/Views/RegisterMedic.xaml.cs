using BleedifyMedic.ViewModels;
using MahApps.Metro.Controls;

namespace BleedifyMedic.Views
{
    /// <summary>
    /// Interaction logic for RegisterMedic.xaml
    /// </summary>
    public partial class RegisterMedic : MetroWindow
    {
        public RegisterMedic()
        {
            InitializeComponent();
	        DataContext = new RegisterMedicViewModel();
        }
    }
}
