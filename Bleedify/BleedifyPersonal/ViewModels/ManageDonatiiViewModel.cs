using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BleedifyPersonal.ViewModels
{
	public class ManageDonatiiViewModel : BaseViewModel
	{
        private DonatieViewModel _selectedDonatie;
        private bool _isDataLoaded;

        public ObservableCollection<DonatieViewModel> Donatii { get; private set; } = new ObservableCollection<DonatieViewModel>();

        public DonatieViewModel SelectedDonatie
        {
            get { return _selectedDonatie; }
            set { SetValue(ref _selectedDonatie, value); }
        }

        public ICommand LoadDonationsCommand { get; private set; }
        public ICommand DeleteDonatieCommand { get; private set; }

        public ManageDonatiiViewModel()
        {
            LoadDonationsCommand = new BasicCommand(LoadData);
            DeleteDonatieCommand = new BasicCommand(DeleteDonatie);
        }

        private void LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var donations = AppService.Instance.DonatieService.GetAll();

            foreach (var d in donations)
                Donatii.Add(new DonatieViewModel(d));
        }

        private void DeleteDonatie()
        {
            if(SelectedDonatie == null)
            {
                MessageBox.Show("You have to select a donation first...");
            }
            else
            {
                AppService.Instance.DonatieService.Delete(SelectedDonatie.Id);
                Donatii.Remove(SelectedDonatie);
            }
        }
    }
}