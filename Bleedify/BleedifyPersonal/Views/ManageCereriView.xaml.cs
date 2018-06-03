using System.Windows.Controls;
using BleedifyPersonal.ViewModels;

namespace BleedifyPersonal.Views
{
    /// <summary>
    /// Interaction logic for ManageCereriView.xaml
    /// </summary>
    public partial class ManageCereriView : UserControl
    {
	    public ManageCereriViewModel ViewModel
	    {
		    get { return DataContext as ManageCereriViewModel; }
		    set { DataContext = value; }
	    }

	    public ManageCereriView()
	    {
		    InitializeComponent();
		    ViewModel = new ManageCereriViewModel();
		    ViewModel.LoadCereriCommand.Execute(null);
	    }

	    private void LoadComponente(object sender, SelectionChangedEventArgs e)
	    {
		   ViewModel.LoadComponenteCommand.Execute(null);
	    }
    }
}
