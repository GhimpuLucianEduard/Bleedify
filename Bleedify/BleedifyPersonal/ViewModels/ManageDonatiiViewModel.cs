using BleedifyPersonal.Views;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
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
        public ICommand AddDonatieCommand { get; private set; }
        public ICommand UpdateDonatieCommand { get; private set; }

        public ManageDonatiiViewModel()
        {
            LoadDonationsCommand = new BasicCommand(LoadData);
            DeleteDonatieCommand = new BasicCommand(DeleteDonatie);
            AddDonatieCommand = new BasicCommand(AddDonatie);
            UpdateDonatieCommand = new BasicCommand(UpdateDonatie);
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
                if(MessageBox.Show("Are you sure you want to delete this donation?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    AppService.Instance.DonatieService.Delete(SelectedDonatie.Id);
                    Donatii.Remove(SelectedDonatie);
                }
            }
        }

        private void AddDonatie()
        {
            var viewModel = new DonatieDetailViewModel(new DonatieViewModel());
            DonatieMasterDetailView DetailPage = new DonatieMasterDetailView(viewModel);
            DetailPage.Show();
            viewModel.DonatieAdded += (source, donatie) =>
            {
                Donatii.Add(new DonatieViewModel(donatie));
                DetailPage.Close();
            };
        }

        private void UpdateDonatie()
        {
            if (SelectedDonatie == null)
            {
                MessageBox.Show("You have to select a donation first...");
            }
            else
            {
                var viewModel = new DonatieDetailViewModel(SelectedDonatie);
                DonatieMasterDetailView DetailPage = new DonatieMasterDetailView(viewModel);
                DetailPage.Show();

                viewModel.DonatieUpdated += (source, donatie) =>
                {
                    var donatievm = new DonatieViewModel(donatie);
                    int index = 0;

                    Donatii.ToList().ForEach(d =>
                    {
                        if(d.Id == donatievm.Id)
                        {
                            d = donatievm;
                        }
                    });

                    DetailPage.Close();
                };
            }
        }
    }
}