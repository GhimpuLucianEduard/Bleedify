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

        public CerereDetailViewModel(CerereViewModel ViewModel)
        {
            CerereViewModel = ViewModel;
            AddCommand = new BasicCommand(Save);
            CancelCommand = new BasicCommandWithParameter(Cancel);
            SelectedGrupa = GrupeDeSange.First();
            CerereViewModel.TipComponenta = TipuriComponenta.First();
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
                    CerereViewModel.GrupaDeSange = SelectedGrupa;
                    CerereViewModel.Stare = StareCerere.InAsteptare.ToString();
                    CerereViewModel.DataDepunere = DateTime.Now;
                    CerereViewModel.DataServire = DateTime.Parse("1970-01-01 00:00:00");

                    if (CerereViewModel.Id == 0)
                    {
                        var Cerere = new CerereMedicPacient()
                        {
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
                        AppService.Instance.CerereService.Add(Cerere);
                        CerereAdded?.Invoke(this, Cerere);
                    }
                }
                catch (ServiceException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
                }
            }
        }
    }
}
