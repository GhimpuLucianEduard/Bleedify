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
        public InstitutieAsociata InstitutieAsociataObj { get; set; } = new InstitutieAsociata();
        public Nullable<int> GrupaDeSangeId { get; set; }
        public GrupaDeSange GrupaDeSange { get; set; } = new GrupaDeSange();
        public Nullable<int> DonatorId { get; set; }
        public Donator Donator { get; set; } = new Donator();

        public override string ToString()
        {
            return DonatorId.ToString() + DataDonare.ToString() + EtapaDonare + InstitutieAsociataId + GrupaDeSangeId + MotivRefuz;
            
        }

        private DateTime _dataDonare;
        public DateTime DataDonare
        {
            get
            {
                return _dataDonare;
            }
            set
            {
                SetValue(ref _dataDonare, value);
            }
        }

        private string _etapaDonare;
        public string EtapaDonare
        {
            get
            {
                return _etapaDonare;
            }
            set
            {
                SetValue(ref _etapaDonare, value);
            }
        }

        private string _motivRefuz;
        public string MotivRefuz
        {
            get
            {
                return _motivRefuz;
            }
            set
            {
                SetValue(ref _motivRefuz, value);
            }
        }
    
    }
}
