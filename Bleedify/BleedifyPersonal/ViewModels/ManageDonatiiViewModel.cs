using BleedifyPersonal.Views;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Windows.Input;
using System;
using DomainViewModels.Converters;
using System.Collections.Generic;
using BleedifyModels.ModelsEF;

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
        public ICommand PrelucreazaDonatieCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }

        public ManageDonatiiViewModel()
        {	
            LoadDonationsCommand = new BasicCommand(LoadData);
            DeleteDonatieCommand = new BasicCommand(DeleteDonatie);
            AddDonatieCommand = new BasicCommand(AddDonatie);
            UpdateDonatieCommand = new BasicCommand(UpdateDonatie);
            PrelucreazaDonatieCommand = new BasicCommand(HandlePrelucreazaDonatie);
            FilterCommand = new BasicCommand(HandleFilter);
            Grupa = GrupeValues[0];
            Etapa = EtapaValues[0];
        }

        private void LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var donations = AppService.Instance.DonatieService.Filter(null, null);

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

        private void HandlePrelucreazaDonatie()
        {
            if (SelectedDonatie == null)
            {
                MessageBox.Show("You have to select a donation first...");
            }
            else
            {
                if (SelectedDonatie.EtapaDonare == "Prelucrata")
                {
                    MessageBox.Show("This donation was already prelucrata");
                }
                else
                {
                    if (SelectedDonatie.EtapaDonare != "Analizata")
                    {
                        MessageBox.Show("This donation cannot be prelucrata");
                    }
                    else
                    {
                        try
                        {
                            PrelucreazaDonatie();
                            MessageBox.Show("You have successfully PRELUCRATED the Donation!", "Success", MessageBoxButton.OK);
                        }
                        catch(ServiceException e)
                        {
                            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
                        }
                        
                    }
                }
            }

        }

        private void PrelucreazaDonatie()
        {
            SelectedDonatie.EtapaDonare = "Prelucrata";

            Donatii.ToList().ForEach(d =>
            {
                if (d.Id == SelectedDonatie.Id)
                {
                    d = SelectedDonatie;
                }
            });

            var donatie = VmToDmConverter.Convert(SelectedDonatie);
            AppService.Instance.ComponentaService.PrelucreazaDonatie(donatie);
            AppService.Instance.DonatieService.Update(donatie);
        }

        public List<string> EtapaValues
        {
            get
            {
                return new List<string>()
                {
                    "Toate", "De Analizat", "Analizata", "Invalida", "Prelucrata", "Donata"
                };
            }
        }

        public List<string> GrupeValues
        {
            get
            {
                return new List<string>()
                {
                    "Toate", "O+", "O-","A+","A-","B+","B-","AB+","AB-"
                };
            }
        }
        private string _grupa;
        public string Grupa
        {
            get { return _grupa; }
            set { SetValue(ref _grupa, value); }
        }

        private string _etapa;
        public string Etapa
        {
            get { return _etapa; }
            set { SetValue(ref _etapa, value); }
        }

        private void HandleFilter()
        {
            Donatii.Clear();

            IEnumerable<Donatie> donations;

            var paramEtapa = Etapa;
            int? paramGrupa;

            if (Etapa.Equals("Toate"))
            {
                paramEtapa = null;
            }

            if (Grupa.Equals("Toate"))
            {
                paramGrupa = null;
            }else
            {
                paramGrupa = AppService.Instance.GrupaDeSangeService.GetAll().First(d => d.Nume == Grupa).Id;
            }

            donations = AppService.Instance.DonatieService.Filter(paramEtapa, paramGrupa);
            
            foreach (var d in donations)
                Donatii.Add(new DonatieViewModel(d));
        }
    }
}