using BleedifyMedic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace BleedifyMedic.Views
{
    /// <summary>
    /// Interaction logic for CerereMasterDetailView.xaml
    /// </summary>
    public partial class CerereMasterDetailView : MetroWindow
    {
        public CerereMasterDetailView(CerereDetailViewModel CerereViewModel)
        {
            InitializeComponent();
            HereViewModel = CerereViewModel;
        }

        public CerereDetailViewModel HereViewModel
        {
            get { return DataContext as CerereDetailViewModel; }
            set { DataContext = value; }
        }
	}
}
