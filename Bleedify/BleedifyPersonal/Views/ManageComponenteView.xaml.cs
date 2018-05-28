using BleedifyPersonal.ViewModels;
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

namespace BleedifyPersonal.Views
{
    /// <summary>
    /// Interaction logic for ManageComponenteView.xaml
    /// </summary>
    public partial class ManageComponenteView : UserControl
    {
        public ManageComponenteView()
        {
            ViewModel = new ManageComponenteViewModel();

            InitializeComponent();

            ViewModel.LoadComponenteCommand.Execute(null);
        }

        public ManageComponenteViewModel ViewModel
        {
            get { return DataContext as ManageComponenteViewModel; }
            set { DataContext = value; }
        }
    }
}
