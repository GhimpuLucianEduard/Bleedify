using BleedifyModels.ModelsEF;

namespace DomainViewModels
{
	public class PersonalViewModel : UtilizatorViewModel
	{
		private int _id;
		private int? _idUtilizator;
		private string _nume;
		private string _prenume;
		private Utilizator _utilizator;

		public int Id
		{
			get { return _id; }
			set { SetValue(ref _id, value); }
		}

		public int? IdUtilizator
		{
			get { return _idUtilizator; }
			set { SetValue(ref _idUtilizator, value); }
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

		public Utilizator UtilizatorObj
		{
			get { return _utilizator; }
			set { SetValue(ref _utilizator, value); }
		}

		public PersonalViewModel()
		{
		}

		public PersonalViewModel(Utilizator utilizator) : base(utilizator)
		{

		}

		public PersonalViewModel(Personal personal) : base(personal.UtilizatorObj)
		{
			_id = personal.Id;
			_idUtilizator = personal.IdUtilizator;
			_nume = personal.Nume;
			_prenume = personal.Prenume;
			_utilizator = personal.UtilizatorObj;
		}
	}
}