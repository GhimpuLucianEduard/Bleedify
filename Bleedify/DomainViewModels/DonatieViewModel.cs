using BleedifyModels.ModelsEF;
using System;
using System.ComponentModel;

namespace DomainViewModels
{
    public class DonatieViewModel : BaseViewModel
    {
        public DonatieViewModel()
        {

        }

        public DonatieViewModel(Donatie donatie)
        {
            Donatie = donatie;
            DataDonare = donatie.DataDonare;
            EtapaDonare = donatie.EtapaDonare;
            GrupaDeSangeId = donatie.GrupaDeSange;
            GrupaDeSange = donatie.GrupaDeSangeObj;
            InstitutieAsociataId = donatie.InstitutieAsociata;
            InstitutieAsociataObj = donatie.InstitutieAsociataObj;
            MotivRefuz = donatie.MotivRefuz;
            Id = donatie.Id;
            DonatorId = donatie.IdDonator;
            Donator = donatie.Donator;
        }

        public Donatie Donatie { get; set; }

        public int Id { get; set; }
        public Nullable<int> InstitutieAsociataId { get; set; }
        public InstitutieAsociata InstitutieAsociataObj{get;set;}
        public DateTime DataDonare { get; set; }
        public string EtapaDonare { get; set; }
        public string MotivRefuz { get; set; }
        public Nullable<int> GrupaDeSangeId { get; set; }
        public GrupaDeSange GrupaDeSange { get; set; }
        public Nullable<int> DonatorId { get; set; }
        public Donator Donator { get; set; }
    }
}
