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
using BleedifyDonator.ViewModels;

namespace BleedifyDonator.Views
{
	/// <summary>
	/// Interaction logic for MesajeView.xaml
	/// </summary>
	public partial class MesajeView : UserControl
	{
		public MesajeView()
		{
			InitializeComponent();
			DataContext = new MesajeViewModel();
		}
	}
}
