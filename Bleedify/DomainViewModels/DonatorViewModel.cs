using System;
using BleedifyModels.ModelsEF;

namespace DomainViewModels
{
	public class DonatorViewModel : UtilizatorViewModel
	{ 
		private int _id;
		private int? _idUtilizator;
		private string _nume;
		private string _prenume;
		private int? _grupaDeSange;
		private DateTime _dataDonarePosibila;
		private GrupaDeSange _grupaDeSangeObj;
		private Utilizator _utilizatorObj;

		public int Id
		{
			get { return _id; }
			set { SetValue(ref _id, value); } 
		}

		public int? IdUtilizator
		{
			get { return _idUtilizator; }
			set { SetValue(ref _idUtilizator, value);}
		}

		public string Nume
		{
			get { return _nume; }
			set { SetValue(ref _nume, value); }
		}

		public string Prenume
		{
			get { return _prenume; }
			set { SetValue(ref _prenume, value); }
		}

		public int? GrupaDeSange
		{
			get { return _grupaDeSange; }
			set { SetValue(ref _grupaDeSange, value); }
		}

		public DateTime DataDonarePosibila
		{
			get { return _dataDonarePosibila; }
			set { SetValue(ref _dataDonarePosibila, value); }
		}

		public GrupaDeSange GrupaDeSangeObj
		{
			get { return _grupaDeSangeObj; }
			set { SetValue(ref _grupaDeSangeObj, value); }
		}

		public Utilizator UtilizatorObj
		{
			get { return _utilizatorObj; }
			set { SetValue(ref _utilizatorObj, value); }
		}

		public DonatorViewModel()
		{
		}

		public DonatorViewModel(Donator donator) : base(donator.UtilizatorObj)
		{
			IdUtilizator = donator.IdUtilizator;
			Nume = donator.Nume;
			Prenume = donator.Prenume;
			DataDonarePosibila = donator.DataDonarePosibila;
			GrupaDeSange = donator.GrupaDeSange;
		}
	}
}