using BleedifyModels.Enums;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BleedifyModels.ModelsEF;
using System.Windows;
using BleedifyMedic.Views;
using MaterialDesignThemes.Wpf;

namespace BleedifyMedic.ViewModels
{
    public class ManageCereriViewModel : BaseViewModel
    {
        private CerereViewModel _selectedCerere;
        private bool _isDataLoaded;
        private string _selectedStare;
        private GrupaDeSange _selectedGrupa;
        private string _selectedTip;

        public ObservableCollection<CerereViewModel> Cereri { get; private set; } = new ObservableCollection<CerereViewModel>();
        public ObservableCollection<ComponentaViewModel> Componente { get; private set; } = new ObservableCollection<ComponentaViewModel>();
        public ObservableCollection<string> Stari { get; private set; }
        public ObservableCollection<GrupaDeSange> Grupe { get; private set; }
        public ObservableCollection<string> Tipuri { get; private set; }

        public ICommand UpdateCerereCommand { get; private set; }
        public ICommand DeleteCerereCommand { get; private set; }
        public ICommand AddCerereCommand { get; private set; }
        public ICommand FilterCereriCommand { get; private set; }
        public ICommand ClearFilterCereriCommand { get; private set; }
        public ICommand LoadCereriCommand { get; private set; }
        public ICommand FilterComponenteCommand { get; private set; }
        public ICommand ClearFilterComponenteCommand { get; private set; }

        public string SelectedStare
        {
            get { return _selectedStare; }
            set { SetValue(ref _selectedStare, value); }
        }

        public GrupaDeSange SelectedGrupa
        {
            get { return _selectedGrupa; }
            set { SetValue(ref _selectedGrupa, value); }
        }

        public string SelectedTip
        {
            get { return _selectedTip; }
            set { SetValue(ref _selectedTip, value); }
        }

        public CerereViewModel SelectedCerere
        {
            get { return _selectedCerere; }
            set { SetValue(ref _selectedCerere, value); }
        }

        public ManageCereriViewModel()
        {
            Stari = new ObservableCollection<string>();
            Stari.Add("Toate");
            foreach (var stare in Enum.GetValues(typeof(StareCerere)))
            {
                Stari.Add(stare.ToString());
            }
            SelectedStare = Stari[0];

            Grupe = new ObservableCollection<GrupaDeSange>();
            Grupe.Add(new GrupaDeSange()
            {
                Id = 0,
                Nume = "Toate"
            });
            foreach (var g in AppService.Instance.GrupaDeSangeService.GetAll())
            {
                Grupe.Add(g);
            }
            SelectedGrupa = Grupe[0];

            Tipuri = new ObservableCollection<string>();
            Tipuri.Add("Toate");
            foreach (var tip in Enum.GetValues(typeof(TipComponenta)))
            {
                Tipuri.Add(tip.ToString());
            }
            SelectedTip = Tipuri[0];

            FilterCereriCommand = new BasicCommand(FilterCereri);
            ClearFilterCereriCommand = new BasicCommand(ClearFilterCereri);
            UpdateCerereCommand = new BasicCommand(UpdateCerere);
            DeleteCerereCommand = new BasicCommand(DeleteCerere);
            AddCerereCommand = new BasicCommand(AddCerere);
            LoadCereriCommand = new BasicCommand(LoadData);
        }

        private void LoadData()
        {
            if (_isDataLoaded)
            {
                return;
            }

            _isDataLoaded = true;

            var cereri = AppService.Instance.CerereService.GetAll();
            var componente = AppService.Instance.ComponentaService.GetAll();

            foreach (var c in cereri)
            {
                Cereri.Add(new CerereViewModel(c));
            }

            foreach(var c in componente)
            {
                Componente.Add(new ComponentaViewModel(c));
            }
        }

        public void FilterCereri()
        {
            int? ParamGrupa;
            string ParamStare;
            string ParamTip;

            if (SelectedStare.CompareTo(Stari[0]) == 0)
            {
                ParamStare = null;
            }
            else
            {
                ParamStare = SelectedStare;
            }

            if (SelectedTip.CompareTo(Tipuri[0]) == 0)
            {
                ParamTip = null;
            }
            else
            {
                ParamTip = SelectedTip;
            }

            if (SelectedGrupa == Grupe[0])
            {
                ParamGrupa = null;
            }
            else
            {
                ParamGrupa = SelectedGrupa.Id;
            }

            var cereri = AppService.Instance.CerereService.Filter(ParamGrupa, ParamTip, ParamStare);

            Cereri.Clear();
            foreach (var c in cereri)
            {
                Cereri.Add(new CerereViewModel(c));
            }
        }

        public void ClearFilterCereri()
        {
            var cereri = AppService.Instance.CerereService.GetAll();

            Cereri.Clear();
            foreach (var c in cereri)
            {
                Cereri.Add(new CerereViewModel(c));
            }

            SelectedStare = Stari[0];
            SelectedGrupa = Grupe[0];
            SelectedTip = Tipuri[0];
        }

        public void UpdateCerere()
        {
            if (SelectedCerere == null)
            {
                MessageBox.Show("You must select a cerere!", "Error", MessageBoxButton.OK);
            }
            else
            {
                var DetailViewModel = new CerereDetailViewModel(SelectedCerere);
                CerereMasterDetailView DetailPage = new CerereMasterDetailView(DetailViewModel);
	            DetailPage.Show();
                DetailViewModel.CerereUpdated += (source, cerere) =>
                {
                    var cererevm = new CerereViewModel(cerere);

                    Cereri.ToList().ForEach(x =>
                    {
                        if (x.Id == cererevm.Id)
                        {
                            x = cererevm;
                        }
                    });
	                DetailPage.Close();
                };
            }
        }

        public void AddCerere()
        {
            var DetailViewModel = new CerereDetailViewModel(new CerereViewModel());
            CerereMasterDetailView DetailPage = new CerereMasterDetailView(DetailViewModel);
	        DetailPage.Show();
            DetailViewModel.CerereAdded += (source, cerere) =>
            {
                Cereri.Add(new CerereViewModel(cerere));
                DetailPage.Close();
            };
        }

        public void DeleteCerere()
        {
            if (SelectedCerere == null)
            {
                MessageBox.Show("Trebuie sa selectezi o cerere!");
            }
            else
            {
                AppService.Instance.CerereService.Delete(SelectedCerere.Id);
                Cereri.Remove(SelectedCerere);
            }
        }
    }
}
