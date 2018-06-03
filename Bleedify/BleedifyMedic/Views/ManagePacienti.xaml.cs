using System.Windows.Controls;
using BleedifyMedic.ViewModels;

namespace BleedifyMedic.Views
{
	/// <summary>
	/// Interaction logic for ManagePacienti.xaml
	/// </summary>
	public partial class ManagePacienti : UserControl
	{
		public ManagePacientiViewModel ViewModel
		{
			get { return DataContext as ManagePacientiViewModel; }
			set { DataContext = value; }
		}

		public ManagePacienti()
		{
			InitializeComponent();
			DataContext = new ManagePacientiViewModel();
		}
	}
}
