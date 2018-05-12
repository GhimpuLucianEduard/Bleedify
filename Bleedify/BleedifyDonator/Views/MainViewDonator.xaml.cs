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
using BleedifyDonator.ViewModels;

namespace BleedifyDonator.Views
{
	/// <summary>
	/// Interaction logic for MainViewDonator.xaml
	/// </summary>
	public partial class MainViewDonator : Window
	{
		public IstoricViewModel ViewModel
		{
			get { return DataContext as IstoricViewModel; }
			set { DataContext = value; }
		}

		public MainViewDonator()
		{
			InitializeComponent();
			ViewModel = new IstoricViewModel();
			ViewModel.LoadDonationsCommand.Execute(null);
		}
	}
}
