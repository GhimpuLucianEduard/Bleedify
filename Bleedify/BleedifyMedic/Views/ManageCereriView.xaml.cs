using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BleedifyMedic.Utils;
using BleedifyMedic.ViewModels;
using BleedifyServices;

namespace BleedifyMedic.Views
{
    /// <summary>
    /// Interaction logic for ManageCereriView.xaml
    /// </summary>
    public partial class ManageCereriView : UserControl
    {
        public ManageCereriView()
        {
            InitializeComponent();
            ViewModel = new ManageCereriViewModel();
            ViewModel.LoadCereriCommand.Execute(null);

            Settings.LoggedMedic = AppService.Instance.MedicService.Find(159);
        }

        public ManageCereriViewModel ViewModel
        {
            get { return DataContext as ManageCereriViewModel; }
            set { DataContext = value; }
        }
    }
}
