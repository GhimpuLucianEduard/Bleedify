using BleedifyModels.Enums;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BleedifyModels.ModelsEF;
using System.Collections.Generic;

namespace BleedifyMedic.ViewModels
{
    public class ManageCereriViewModel : BaseViewModel
    {
        private CerereViewModel _selectedCerere;
        private bool _isDataLoaded;
        private string _selectedStare;

        public ObservableCollection<CerereViewModel> Cereri { get; private set; } = new ObservableCollection<CerereViewModel>();
        public ObservableCollection<string> Stari { get; private set; }

        public ICommand StareSelectionChanged
        {
            get;
            set;
        }

        public string SelectedStare
        {
            get { return _selectedStare; }
            set { SetValue(ref _selectedStare, value); }
        }

        public CerereViewModel SelectedCerere
        {
            get { return _selectedCerere; }
            set { SetValue(ref _selectedCerere, value); }
        }

        public ICommand LoadCereriCommand { get; private set; }

        public ManageCereriViewModel()
        {
            Stari = new ObservableCollection<string>();
            Stari.Add("Toate");
            foreach (var stare in Enum.GetValues(typeof(StareCerere)))
            {
                Stari.Add(stare.ToString());
            }

            SelectedStare = Stari[0];

            StareSelectionChanged = new BasicCommandWithParameter(GetCereriByStare);
        }

        private void LoadData()
        {
            if (_isDataLoaded)
            {
                return;
            }

            _isDataLoaded = true;

            var cereri = AppService.Instance.CerereService.GetAll(null);

            foreach (var c in cereri)
            {
                Cereri.Add(new CerereViewModel(c));
            }
        }

        void GetCereriByStare(object param)
        {
            var SelectedStare = (string)param;

            if (SelectedStare.CompareTo(Stari[0]) == 0)
            {
                SelectedStare = null;
            }

            var cereri = AppService.Instance.CerereService.GetAll(SelectedStare);

            Cereri.Clear();
            foreach (var c in cereri)
            {
                Cereri.Add(new CerereViewModel(c));
            }
        }
    }
}
