using BleedifyModels.ModelsEF;
using BleedifyPersonal.Views;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BleedifyPersonal.ViewModels
{
    public class ManageComponenteViewModel : BaseViewModel
    {
        private bool _isDataLoaded;

        private ComponentaViewModel _selectedComponenta;
        public ComponentaViewModel SelectedComponenta
        {
            get { return _selectedComponenta; }
            set
            {
                SetValue(ref _selectedComponenta, value);
                LoadCereri();
            }
        }

        private CerereViewModel _selectedCerere;
        public CerereViewModel SelectedCerere
        {
            get { return _selectedCerere; }
            set
            {
                SetValue(ref _selectedCerere, value);
            }
        }

        public ObservableCollection<ComponentaViewModel> Componente { get; private set; } = new ObservableCollection<ComponentaViewModel>();
        public ObservableCollection<CerereViewModel> Cereri { get; private set; } = new ObservableCollection<CerereViewModel>();

        public ICommand LoadComponenteCommand { get; private set; }
        public ICommand DeservireComponentaCommand { get; private set; }
        public ICommand DeleteDonatieCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }

        public ManageComponenteViewModel()
        {
            LoadComponenteCommand = new BasicCommand(LoadData);
            DeleteDonatieCommand = new BasicCommand(DeleteComponenta);
            UpdateCommand = new BasicCommand(UpdateComponenta);
            DeservireComponentaCommand = new BasicCommand(DeservireComponenta);
        }

        private void LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var components = AppService.Instance.ComponentaService.Filter(null, null);

            foreach (var c in components)
                Componente.Add(new ComponentaViewModel(c));
        }

        private void LoadCereri()
        {
            Cereri.Clear();

            var grupa = SelectedComponenta.Donatie.GrupaDeSange;
            var tip = SelectedComponenta.TipComponenta;
            var stare = SelectedComponenta.Stare;

            if(stare.Equals("In Asteptare"))
            {
                stare = "InAsteptare";
            }

            if(tip.Equals("Globule Rosii"))
            {
                tip = "GlobuleRosii";
            }

            var cereri = AppService.Instance.CerereService.Filter(grupa, tip, stare);

            foreach (var c in cereri)
                Cereri.Add(new CerereViewModel(c));
        }

        private void DeleteComponenta()
        {
            if (SelectedComponenta == null)
            {
                MessageBox.Show("You have to select a Componenta first...");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Componenta?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    AppService.Instance.ComponentaService.Delete(SelectedComponenta.Id);
                    Componente.Remove(SelectedComponenta);
                }
            }
        }

        private void DeservireComponenta()
        {
            if (SelectedCerere == null || SelectedComponenta == null)
            {
                MessageBox.Show("You have to select a cerere and a componenta first...");
            }
            else
            {
                SelectedComponenta.Stare = "Donata";
                var pacient = AppService.Instance.PacientService.Find(SelectedCerere.Pacient.Id);
                SelectedComponenta.Pacient = new Pacient();
                SelectedComponenta.Pacient.Nume = pacient.Nume;
                SelectedComponenta.Pacient.Prenume = pacient.Prenume;
                var componenta = new Componenta(SelectedComponenta.Id, SelectedComponenta.TipComponenta, SelectedComponenta.IdDonatie,
                                SelectedComponenta.DataDepunere, SelectedComponenta.IdPrimitor, SelectedComponenta.Stare,
                                SelectedComponenta.Pacient.Nume, SelectedComponenta.Pacient.Prenume);
                AppService.Instance.ComponentaService.Update(componenta);


                SelectedCerere.Stare = "IncheiataPozitiv";
                var cerere = AppService.Instance.CerereService.Find(SelectedCerere.Id);
                cerere.Stare = SelectedComponenta.Stare;
                AppService.Instance.CerereService.Update(cerere);

            
            }

        }

        private void UpdateComponenta()
        {
            if (SelectedComponenta == null)
            {
                MessageBox.Show("You have to select a donation first...");
            }
            else
            {
                var viewModel = new ComponentaDetailViewModel(SelectedComponenta);
                ComponentaMasterDetailView DetailPage = new ComponentaMasterDetailView(viewModel);
                DetailPage.Show();

                viewModel.ComponentaUpdated += (source, componenta) =>
                {
                    var componentavm = new ComponentaViewModel(componenta);

                    Componente.ToList().ForEach(d =>
                    {
                        if (d.Id == componentavm.Id)
                        {
                            d = componentavm;
                            d.Pacient.Nume = componentavm.Pacient.Nume;
                            d.Pacient.Prenume = componentavm.Pacient.Prenume;
                        }
                    });

                    DetailPage.Close();
                };
            }
        }
    }
}
