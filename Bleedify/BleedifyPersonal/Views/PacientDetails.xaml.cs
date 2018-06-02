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
using BleedifyPersonal.ViewModels;

namespace BleedifyPersonal.Views
{
	/// <summary>
	/// Interaction logic for PacientDetails.xaml
	/// </summary>
	public partial class PacientDetails : Window
	{
		public PacientDetails(DomainViewModels.PacientViewModel pacientViewModel)
		{
			InitializeComponent();
			DataContext = new PacientDetailsViewModel(pacientViewModel);
		}
	}
}
