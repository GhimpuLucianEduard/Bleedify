using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BleedifyMedic.Utils;
using BleedifyMedic.ViewModels;
using BleedifyServices;

namespace BleedifyMedic.Views
{
    /// <summary>
    /// Interaction logic for ManageCereriView.xaml
    /// </summary>
    public partial class ManageCereriView : Window
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

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var sel = e.AddedItems;
            ViewModel.StareSelectionChanged.Execute(sel[0]);
        }
    }
}
