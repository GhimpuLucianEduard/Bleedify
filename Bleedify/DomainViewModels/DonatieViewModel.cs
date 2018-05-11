using BleedifyModels.ModelsEF;
using System;

namespace DomainViewModels
{
    public class DonatieViewModel : BaseViewModel
    {
        public DonatieViewModel ()
        {

        }

        public DonatieViewModel (Donatie donatie)
        {
            DataDonare = donatie.DataDonare;
            EtapaDonare = donatie.EtapaDonare;
            InstitutieAsociata = donatie.InstitutieAsociataObj.Nume;
            GrupaDeSange = donatie.GrupaDeSangeObj.Nume;
            MotivRefuz = donatie.MotivRefuz;
        }

        public DateTime DataDonare { get; set; }
        public string EtapaDonare { get; set; }
        public string InstitutieAsociata { get; set; }
        public string GrupaDeSange { get; set; }
        public string MotivRefuz { get; set; }
    }
}
