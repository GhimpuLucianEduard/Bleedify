using BleedifyModels.Enums;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BleedifyMedic.ViewModels
{
    public class ManageStocViewModel : BaseViewModel
    {
        private string _selectedStareComponenta;
        private string _selectedTipComponenta;
        private bool _isDataLoaded;

        public ObservableCollection<ComponentaViewModel> Componente { get; private set; } = new ObservableCollection<ComponentaViewModel>();
        public ObservableCollection<string> Stari { get; private set; }
        public ObservableCollection<string> Tipuri { get; private set; }

        public ICommand LoadComponenteCommand { get; private set; }
        public ICommand FilterComponenteCommand { get; private set; }
        public ICommand ClearFilterComponenteCommand { get; private set; }

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

        public ManageStocViewModel()
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
            FilterComponenteCommand = new BasicCommand(FilterComponente);
            ClearFilterComponenteCommand = new BasicCommand(ClearFilterComponente);
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
                ParamStare = SelectedStareComponenta;
            }

            if (SelectedTipComponenta.CompareTo(Tipuri[0]) == 0)
            {
                ParamTip = null;
            }
            else
            {
                ParamTip = SelectedTipComponenta;
            }

            var comp = AppService.Instance.ComponentaService.Filter(ParamTip, ParamStare);

            Componente.Clear();
            foreach (var c in comp)
            {
                Componente.Add(new ComponentaViewModel(c));
            }
        }

        private void LoadData()
        {
            if (_isDataLoaded)
            {
                return;
            }

            _isDataLoaded = true;

            var componente = AppService.Instance.ComponentaService.GetAll();

            foreach (var c in componente)
            {
                Componente.Add(new ComponentaViewModel(c));
            }
        }
    }
}
