using System.Windows.Input;
using BleedifyDonator.ViewModels;

namespace BleedifyDonator.Views
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
			MainGrid.Children.Add(new DonatiiView());
		}
	}
}
