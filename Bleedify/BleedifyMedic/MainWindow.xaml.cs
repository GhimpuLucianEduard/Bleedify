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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BleedifyMedic.ViewModels;
using BleedifyMedic.Views;

namespace BleedifyMedic
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainWindowViewModel();
			MainGrid.Children.Add(new ManageCereriView());
		}

		private void ViewStoc(object sender, MouseButtonEventArgs e)
		{
			MainGrid.Children.Clear();
			MainGrid.Children.Add(new ManageStocView());
		}

		private void ViewCereri(object sender, MouseButtonEventArgs e)
		{
			MainGrid.Children.Clear();
			MainGrid.Children.Add(new ManageCereriView());
		}

		private void ViewPacienti(object sender, MouseButtonEventArgs e)
		{
			MainGrid.Children.Clear();
			MainGrid.Children.Add(new ManagePacienti());
		}
	}
}
