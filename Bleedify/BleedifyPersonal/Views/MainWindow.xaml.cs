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
using MahApps.Metro.Controls;

namespace BleedifyPersonal.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainWindowViewModel();
			MainGrid.Children.Add(new ManageDonatiiView());
		}

		private void ViewStoc(object sender, MouseButtonEventArgs e)
		{
			MainGrid.Children.Clear();
			MainGrid.Children.Add(new ManageComponenteView());
		}

		private void ViewDonatii(object sender, MouseButtonEventArgs e)
		{
			MainGrid.Children.Clear();
			MainGrid.Children.Add(new ManageDonatiiView());
		}
	}


}
