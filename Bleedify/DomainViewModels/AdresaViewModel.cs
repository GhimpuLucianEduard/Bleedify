using BleedifyModels.ModelsEF;

namespace DomainViewModels
{
	public class AdresaViewModel : BaseViewModel
	{
		private int _id;
		private string _judet;
		private string _oras;
		private string _strada;
		private int _numar;
		private int _codPostal;

		public int Id
		{
			get { return _id; }
			set { SetValue(ref _id, value);}
		}

		public string Judet
		{
			get { return _judet; }
			set { SetValue(ref _judet, value);}
		}

		public string Oras
		{
			get { return _oras; }
			set { SetValue(ref _oras, value);}
		}

		public string Strada
		{
			get { return _strada; }
			set
			{
				SetValue(ref _strada, value);
			}
		}

		public int Numarul
		{
			get { return _numar; }
			set { SetValue(ref _numar, value);}
		}

		public int CodPostal
		{
			get
			{
				return _codPostal;
			}
			set
			{
				SetValue(ref _codPostal, value);
			}
		}

		public AdresaViewModel()
		{

		}

		public AdresaViewModel(Adresa adresa)
		{ 
			Id = adresa.Id;
			Numarul = adresa.Numarul;
			Strada = adresa.Strada;
			CodPostal = adresa.CodPostal;
			Oras = adresa.Oras;
			Judet = adresa.Judet;
		}
	}
}