using BleedifyModels.ModelsEF;
using System;

namespace DomainViewModels
{
    public class CerereViewModel : BaseViewModel
    {
        public CerereViewModel()
        {

        }

        public CerereViewModel(CerereMedicPacient cerere)
        {
            Id = cerere.Id;
            IdPacient = cerere.IdPacient;
            IdMedic = cerere.IdMedic;
            IdGrupaDeSange = cerere.GrupaDeSange;
            TipComponenta = cerere.TipComponenta;
            DataDepunere = cerere.DataDepunere;
            DataServire = cerere.DataServire;
            GrupaDeSange = cerere.GrupaDeSangeObj;
            Pacient = cerere.PacientObj;
            Medic = cerere.MedicObj;
            Stare = cerere.Stare;
            TipComponenta = cerere.TipComponenta;
        }

        public int Id { get; set; }
        public Nullable<int> IdPacient { get; set; }
        public Nullable<int> IdMedic { get; set; }

        private Nullable<int> _idGrupaDeSange;
        public Nullable<int> IdGrupaDeSange
        {
            get
            {
                return _idGrupaDeSange;
            }
            set
            {
                SetValue(ref _idGrupaDeSange, value);
            }
        }

        private string _tipComponenta;
        public string TipComponenta
        {
            get
            {
                return _tipComponenta;
            }
            set
            {
                SetValue(ref _tipComponenta, value);
            }
        }

        private string _stare;
        public string Stare
        {
            get
            {
                return _stare;
            }
            set
            {
                SetValue(ref _stare, value);
            }
        }

        public System.DateTime DataDepunere { get; set; }

        private System.DateTime _dataServire;
        public System.DateTime DataServire
        {
            get
            {
                return _dataServire;
            }
            set
            {
                SetValue(ref _dataServire, value);
            }
        }

        private GrupaDeSange _grupaDeSange;
        public GrupaDeSange GrupaDeSange
        {
            get
            {
                return _grupaDeSange;
            }
            set
            {
                SetValue(ref _grupaDeSange, value);
            }
        }

        public Pacient Pacient { get; set; }
        public Medic Medic { get; set; }
    }
}
