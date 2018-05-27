using BleedifyModels.ModelsEF;

namespace DomainViewModels
{
	public class MedicViewModel : UtilizatorViewModel
	{
		private int _id;
		private int? _idutilizator;
		private string _nume;
		private string _prenume;
		private string _identificatorMedic;
		private Utilizator _utilizatorObj;

		public int Id
		{
			get { return _id; }
			set { SetValue(ref _id, value);}
		}

		public int? IdUtilizator
		{
			get { return _idutilizator; }
			set { SetValue(ref _idutilizator, value); }
		}

		public string Nume
		{
			get { return _nume; }
			set { SetValue(ref _nume, value); }
		}

		public string Prenume
		{
			get { return _prenume; }
			set { SetValue(ref _prenume, value);}
		}

		public string IdentificatorMedic
		{
			get { return _identificatorMedic; }
			set { SetValue(ref _identificatorMedic, value); }
		}

		public Utilizator UtilizatorObj
		{
			get { return _utilizatorObj; }
			set { SetValue(ref _utilizatorObj, value); } 
		}

		public MedicViewModel()
		{
		}

		public MedicViewModel(Medic medic) : base(medic.UtilizatorObj)
		{ 
			_id = medic.Id;
			_idutilizator = medic.IdUtilizator;
			_utilizatorObj = medic.UtilizatorObj;
			_nume = medic.Nume;
			_prenume = medic.Prenume;
			_identificatorMedic = medic.IdentificatorMedic;
		}
	}
}