using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;
using System.Collections.ObjectModel;
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

        public ManageDonatiiViewModel()
        {
            LoadDonationsCommand = new BasicCommand(LoadData);
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
    }
}