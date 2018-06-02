using System.CodeDom;
using BleedifyModels.ModelsEF;

namespace DomainViewModels
{
	public class InstitutieAsociataViewModel : BaseViewModel
	{
		private int _id;
		private int? _idAresa;
		private string _tip;
		private string _nume;
		private string _nrTel;
		private string _email;
		private Adresa _adresaObj;

		public int Id
		{
			get
			{
				return _id; 
			}
			set
			{
				SetValue(ref _id, value);
			}
		}

		public int? IdAdresa
		{
			get { return _idAresa; }
			set { SetValue(ref _idAresa, value);}
		}

		public string Tip
		{
			get { return _tip; }
			set { SetValue(ref _tip, value); }
		}

		public string Nume
		{
			get { return _nume; }
			set { SetValue(ref _nume, value); }
		}

		public string Email
		{
			get { return _email; }
			set { SetValue(ref _email, value); }
		}

		public string NrTel
		{
			get { return _nrTel; }
			set { SetValue(ref _nrTel, value); }
		}

		public Adresa Adresa
		{
			get { return _adresaObj; }
			set { SetValue(ref _adresaObj, value); } 
		}

		public InstitutieAsociataViewModel()
		{
		}

		public InstitutieAsociataViewModel(InstitutieAsociata institutie)
		{
			Id = institutie.Id;
			Tip = institutie.TipInstitutie;
			IdAdresa = institutie.Adresa;
			Adresa = institutie.AdresaObj;
			Email = institutie.Email;
			NrTel = institutie.NumarTelefon;
			Nume = institutie.Nume;
		}
	}
}