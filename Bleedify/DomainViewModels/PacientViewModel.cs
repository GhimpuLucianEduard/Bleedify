using System;
using BleedifyModels.ModelsEF;

namespace DomainViewModels
{
	public class PacientViewModel : BaseViewModel
	{
		private int _id;
		private string _nume;
		private string _prenume;
		private DateTime _dataNastere;
		private int? _idGrupaDeSange;
		private int? _idInstitutieAsociata;
		private GrupaDeSange _grupaDeSange;
		private InstitutieAsociata _institutieAsociata;

		public int Id
		{
			get { return _id; }
			set { SetValue(ref _id, value);}
		}

		public string Nume
		{
			get { return _nume; }
			set { SetValue(ref _nume, value);}
		}

		public string Prenume
		{
			get { return _prenume; }
			set { SetValue(ref _prenume, value);}
		}

		public System.DateTime DataNastere
		{
			get { return _dataNastere; }
			set { SetValue(ref _dataNastere, value);}
		}

		public int? IdGrupaDeSange
		{
			get { return _idGrupaDeSange; }
			set
			{
				SetValue(ref _idGrupaDeSange, value);
			}
		}

		public int? IdInstitutieAsociata
		{
			get { return _idInstitutieAsociata; }
			set { SetValue(ref _idInstitutieAsociata, value);}
		}

		public GrupaDeSange GrupaDeSange
		{
			get { return _grupaDeSange; }
			set { SetValue(ref _grupaDeSange, value);}
		}

		public virtual InstitutieAsociata InstitutieAsociata
		{
			get { return _institutieAsociata; }
			set { SetValue(ref _institutieAsociata, value);}
		}

		public PacientViewModel()
		{
		}

		public PacientViewModel(Pacient pacient)
		{
			Id = pacient.Id;
			IdGrupaDeSange = pacient.GrupaDeSange;
			IdInstitutieAsociata = pacient.InstitutieAsociata;
			GrupaDeSange = pacient.GrupaDeSange1;
			InstitutieAsociata = pacient.InstitutieAsociata1;
			Nume = pacient.Nume;
			Prenume = pacient.Prenume;
			DataNastere = pacient.DataNastere;
		}
	}
}