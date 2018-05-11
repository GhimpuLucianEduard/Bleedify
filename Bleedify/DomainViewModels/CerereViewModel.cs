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
        public Nullable<int> IdGrupaDeSange { get; set; }
        public string TipComponenta { get; set; }
        public string Stare { get; set; }
        public System.DateTime DataDepunere { get; set; }
        public System.DateTime DataServire { get; set; }
        public GrupaDeSange GrupaDeSange { get; set; }
        public Pacient Pacient { get; set; }
        public Medic Medic { get; set; }
    }
}
