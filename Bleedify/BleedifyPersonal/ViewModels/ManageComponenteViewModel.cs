using BleedifyModels.Enums;
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
        private string _selectedStareComponenta;
        private string _selectedTipComponenta;
        private bool _isDataLoaded;

        private ComponentaViewModel _selectedComponenta;
        public ComponentaViewModel SelectedComponenta
        {
            get { return _selectedComponenta; }
            set { SetValue(ref _selectedComponenta, value); }
        }

        public ObservableCollection<ComponentaViewModel> Componente { get; private set; } = new ObservableCollection<ComponentaViewModel>();
        public ObservableCollection<string> Stari { get; private set; }
        public ObservableCollection<string> Tipuri { get; private set; }

        public ICommand LoadComponenteCommand { get; private set; }
        public ICommand DeleteDonatieCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand FilterComponenteCommand { get; private set; }
        public ICommand ClearFilterComponenteCommand { get; private set; }

        public ManageComponenteViewModel()
        {
            Stari = new ObservableCollection<string>();
            Stari.Add("Toate");
            foreach (var stare in Enum.GetValues(typeof(StareCerere)))
            {
                Stari.Add(stare.ToString());
            }
            SelectedStareComponenta = Stari[0];

            Tipuri = new ObservableCollection<string>();
            Tipuri.Add("Toate");
            foreach (var tip in Enum.GetValues(typeof(TipComponenta)))
            {
                Tipuri.Add(tip.ToString());
            }
            SelectedTipComponenta = Tipuri[0];

            LoadComponenteCommand = new BasicCommand(LoadData);
            DeleteDonatieCommand = new BasicCommand(DeleteComponenta);
            UpdateCommand = new BasicCommand(UpdateComponenta);
            FilterComponenteCommand = new BasicCommand(FilterComponente);
            ClearFilterComponenteCommand = new BasicCommand(ClearFilterComponente);
        }

        private void FilterComponente()
        {
            string ParamStare;
            string ParamTip;

            if (SelectedStareComponenta.CompareTo(Stari[0]) == 0)
            {
                ParamStare = null;
            }
            else
            {
                if (SelectedStareComponenta.Equals("InAsteptare"))
                {
                    ParamStare = "In Asteptare";
                }
                else
                {
                    ParamStare = SelectedStareComponenta;
                }
            }

            if (SelectedTipComponenta.CompareTo(Tipuri[0]) == 0)
            {
                ParamTip = null;
            }
            else
            {
                if(SelectedTipComponenta.Equals("GlobuleRosii"))
                {
                    ParamTip = "GlobuleRosii";
                }
                else
                {
                    ParamTip = SelectedTipComponenta;
                }
            }

            var comp = AppService.Instance.ComponentaService.Filter(ParamTip, ParamStare);

            Componente.Clear();
            foreach (var c in comp)
            {
                Componente.Add(new ComponentaViewModel(c));
            }
        }

        private void ClearFilterComponente()
        {
            var comp = AppService.Instance.ComponentaService.GetAll();

            Componente.Clear();
            foreach (var c in comp)
            {
                Componente.Add(new ComponentaViewModel(c));
            }

            SelectedStareComponenta = Stari[0];
            SelectedTipComponenta = Tipuri[0];
        }

        public string SelectedTipComponenta
        {
            get { return _selectedTipComponenta; }
            set { SetValue(ref _selectedTipComponenta, value); }
        }

        public string SelectedStareComponenta
        {
            get { return _selectedStareComponenta; }
            set { SetValue(ref _selectedStareComponenta, value); }
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
