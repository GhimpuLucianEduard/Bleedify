using BleedifyPersonal.ViewModels;
using DomainViewModels;
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
    /// Interaction logic for ComponentaMasterDetailView.xaml
    /// </summary>
    public partial class ComponentaMasterDetailView : Window
    {
        public ComponentaMasterDetailView(ComponentaDetailViewModel componenta)
        {
            InitializeComponent();

            ViewModel = componenta;
        }

        public ComponentaDetailViewModel ViewModel
        {
            get { return DataContext as ComponentaDetailViewModel; }
            set { DataContext = value; }
        }
    }
}
