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
using DomainViewModels;

namespace BleedifyPersonal.Views
{
	/// <summary>
	/// Interaction logic for InstitutieDetail.xaml
	/// </summary>
	public partial class InstitutieDetail : Window
	{
		public InstitutieDetailViewModel ViewModel
		{
			get { return DataContext as InstitutieDetailViewModel; }
			set { DataContext = value; }

		}

		public InstitutieDetail(InstitutieAsociataViewModel viewModel)
		{
			InitializeComponent();
			DataContext = new InstitutieDetailViewModel(viewModel);
		}

		private void OnCancel(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
