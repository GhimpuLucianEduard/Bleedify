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
using System.Windows.Threading;
using BleedifyDonator.ViewModels;
using MahApps.Metro.Controls;

namespace BleedifyDonator.Views
{
	/// <summary>
	/// Interaction logic for MainViewDonator.xaml
	/// </summary>
	public partial class DonatiiView : UserControl
	{
		public IstoricViewModel ViewModel
		{
			get { return DataContext as IstoricViewModel; }
			set { DataContext = value; }

		}

		public DonatiiView()
		{
			InitializeComponent();
			ViewModel = new IstoricViewModel();
			ViewModel.LoadDonationsCommand.Execute(null);
		}

		private void DonationDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ViewModel.SelectionChanged.Execute(null);
		}
	}
}
