using BleedifyMedic.Utils;
using BleedifyMedic.Views;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
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

namespace BleedifyMedic.ViewModels
{
    public class CerereDetailViewModel : BaseViewModel
    {
        public CerereViewModel CerereViewModel { get; set; }
        public CerereMasterDetailView View { get; set; }
        public ICommand AddCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public event EventHandler<CerereMedicPacient> CerereAdded;
        public event EventHandler<CerereMedicPacient> CerereUpdated;

        public CerereDetailViewModel(CerereViewModel ViewModel)
        {   
            if (ViewModel.Id == 0)
            {
                FieldsEnabled = true;
                SelectedGrupa = GrupeDeSange.First();
                SelectedTip = TipuriComponenta.First();
                SelectedStare = StariPosibile.First();
            }
            else
            {
                FieldsEnabled = false;
                NumePacient = ViewModel.Pacient.Nume;
                PrenumePacient = ViewModel.Pacient.Prenume;
                SelectedTip = ViewModel.TipComponenta;
                SelectedGrupa = ViewModel.GrupaDeSange;
                SelectedStare = ViewModel.Stare;
            }
            CerereViewModel = ViewModel;
            AddCommand = new BasicCommand(Save);
            CancelCommand = new BasicCommandWithParameter(Cancel);
        }

        private bool _fieldsEnabled;
        public bool FieldsEnabled
        {
            get { return _fieldsEnabled; }
            set { SetValue(ref _fieldsEnabled, value); }
        }

        public IEnumerable<GrupaDeSange> GrupeDeSange
        {
            get
            {
                return AppService.Instance.GrupaDeSangeService.GetAll();
            }
        }

        private GrupaDeSange _selectedGrupa;
        public GrupaDeSange SelectedGrupa
        {
            get { return _selectedGrupa; }
            set { SetValue(ref _selectedGrupa, value); }
        }

        private string _selectedStare;
        public string SelectedStare
        {
            get { return _selectedStare; }
            set { SetValue(ref _selectedStare, value); }
        }

        private string _selectedTip;
        public string SelectedTip
        {
            get { return _selectedTip; }
            set { SetValue(ref _selectedTip, value); }
        }

        public ObservableCollection<string> TipuriComponenta
        {
            get
            {
                ObservableCollection<string> Types = new ObservableCollection<string>(); 
                var ArrayTip = Enum.GetValues(typeof(TipComponenta));
                foreach (var t in ArrayTip)
                {
                    Types.Add(t.ToString());
                }
                return Types;
            }
        }

        public ObservableCollection<string> StariPosibile
        {
            get
            {
                ObservableCollection<string> Stari = new ObservableCollection<string>();
                var ArrayStari = Enum.GetValues(typeof(StareCerere));
                foreach (var s in ArrayStari)
                {
                    Stari.Add(s.ToString());
                }
                return Stari;
            }
        }

        public string NumePacient { get; set; }
        public string PrenumePacient { get; set; }

        public void Cancel(object param)
        {
            var window = (Window)param;
            window.Close();
        }

        public void Save()
        {
            if (String.IsNullOrEmpty(NumePacient) ||
                String.IsNullOrEmpty(PrenumePacient) ||
                SelectedGrupa == null)
            {
                MessageBox.Show("Please make sure you completed all the fields!", "Error", MessageBoxButton.OK);
            }
            else
            {
                try
                {
                    Pacient Pacient = AppService.Instance.PacientService.GetPacientByFullName(NumePacient, PrenumePacient).First();
                    CerereViewModel.IdMedic = Settings.LoggedMedic.Id;
                    CerereViewModel.IdPacient = Pacient.Id;
                    CerereViewModel.IdGrupaDeSange = SelectedGrupa.Id;
                    CerereViewModel.Medic = Settings.LoggedMedic;
                    CerereViewModel.Pacient = Pacient;
                    CerereViewModel.TipComponenta = SelectedTip;
                    CerereViewModel.GrupaDeSange = SelectedGrupa;
                    CerereViewModel.Stare = SelectedStare;
                    CerereViewModel.DataDepunere = DateTime.Now;

                    if (SelectedStare.CompareTo(StariPosibile.First()) != 0)
                    {
                        CerereViewModel.DataServire = DateTime.Now;
                    }
                    else
                    {
                        CerereViewModel.DataServire = DateTime.Parse("1970-01-01 00:00:00");
                    }

                    var Cerere = new CerereMedicPacient()
                    {
                        Id = CerereViewModel.Id,
                        IdPacient = CerereViewModel.IdPacient,
                        IdMedic = CerereViewModel.IdMedic,
                        GrupaDeSange = CerereViewModel.IdGrupaDeSange,
                        TipComponenta = CerereViewModel.TipComponenta,
                        Stare = CerereViewModel.Stare,
                        DataDepunere = CerereViewModel.DataDepunere,
                        DataServire = CerereViewModel.DataServire,
                        GrupaDeSange1 = CerereViewModel.GrupaDeSange,
                        Medic = CerereViewModel.Medic,
                        Pacient = CerereViewModel.Pacient
                    };

                    if (CerereViewModel.Id == 0)
                    { 
                        AppService.Instance.CerereService.Add(Cerere);
                        CerereAdded?.Invoke(this, Cerere);
                        MessageBox.Show("Cerere added successfully!", "Success", MessageBoxButton.OK);
                    }
                    else
                    {
                        AppService.Instance.CerereService.Update(Cerere);
                        CerereUpdated?.Invoke(this, Cerere);
                        MessageBox.Show("Cerere updated successfully!", "Success", MessageBoxButton.OK);
                    }
                }
                catch (ServiceException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Pacient not found or there is a problem with the database", "Error", MessageBoxButton.OK);
                }
            }
        }
    }
}
