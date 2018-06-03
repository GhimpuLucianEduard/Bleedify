using System.Windows;
using BleedifyMedic.ViewModels;

namespace BleedifyMedic.Views
{
	/// <summary>
	/// Interaction logic for PacientDetails.xaml
	/// </summary>
	public partial class PacientDetails : Window
	{
		public PacientDetailsViewModel ViewModel
		{
			get { return DataContext as PacientDetailsViewModel; }
			set { DataContext = value; }
		}

		public PacientDetails(DomainViewModels.PacientViewModel pacientViewModel)
		{
			InitializeComponent();
			DataContext = new PacientDetailsViewModel(pacientViewModel);
		}

		private void OnCancel(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
