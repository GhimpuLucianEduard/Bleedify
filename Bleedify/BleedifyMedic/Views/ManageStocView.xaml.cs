using BleedifyMedic.ViewModels;
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

namespace BleedifyMedic.Views
{
    /// <summary>
    /// Interaction logic for ManageStocView.xaml
    /// </summary>
    public partial class ManageStocView : Window
    {
        public ManageStocView()
        {
            InitializeComponent();
            ViewModel = new ManageStocViewModel();
            ViewModel.LoadComponenteCommand.Execute(null);
        }

        public ManageStocViewModel ViewModel
        {
            get { return DataContext as ManageStocViewModel; }
            set { DataContext = value; }
        }
    }
}
