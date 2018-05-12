using System;
using BleedifyModels.ModelsEF;

namespace DomainViewModels
{
	public class ComponentaViewModel : BaseViewModel
	{
		private int _id;
		private string _tipComponenta;
		private int _idDonatie;
		private DateTime _dataDepunere;
		private Nullable<int> _idPrimitor;
		private string _stare;
		private Donatie _donatie;
		private Pacient _pacient;

        public ComponentaViewModel(Componenta componenta)
        {
            Id = componenta.Id;
            TipComponenta = componenta.TipComponenta;
            IdDonatie = componenta.IdDonatie;
            IdPrimitor = componenta.IdPrimitor;
            Stare = componenta.Stare;
            Donatie = componenta.Donatie;
            Pacient = componenta.Pacient;
            DataDepunere = componenta.DataDepunere;
        }

        public Nullable<int> IdPrimitor
        {
            get { return _idPrimitor; }
            set { SetValue(ref _idPrimitor, value); }
        }

		public int Id
		{
			get { return _id; }
			set { SetValue(ref _id, value); }
		}

		public string TipComponenta
		{
			get { return _tipComponenta; }
			set { SetValue(ref _tipComponenta, value); }
		}

        public int IdDonatie
        {
            get { return _idDonatie; }
            set { SetValue(ref _idDonatie, value); }
        }

        public DateTime DataDepunere
        {
            get { return _dataDepunere; }
            set { SetValue(ref _dataDepunere, value); }
        }

        public string Stare
        {
            get { return _stare; }
            set { SetValue(ref _stare, value); }
        }

        public Donatie Donatie
        {
            get { return _donatie; }
            set { SetValue(ref _donatie, value);  }
        }

        public Pacient Pacient
        {
            get { return _pacient; }
            set { SetValue(ref _pacient, value); }
        }
	}
}