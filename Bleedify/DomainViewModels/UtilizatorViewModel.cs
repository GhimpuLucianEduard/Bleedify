using BleedifyModels.ModelsEF;

namespace DomainViewModels
{
	public class UtilizatorViewModel : BaseViewModel
	{ 
		private int _id;
		private string _userName;
		private string _password;
		private string _tip;
		private int? _idInstitutie;
		private InstitutieAsociata _institutieAsociataObj;

		public int Id
		{
			get { return _id; }
			set { SetValue(ref _id, value); }
		}

		public string Username
		{
			get { return _userName; }
			set { SetValue(ref _userName, value); }
		}

		public string Password
		{
			get { return _password; }
			set { SetValue(ref _password, value); }
		}

		public string TipUtilizator
		{
			get { return _tip; }
			set { SetValue(ref _tip, value); }
		}

		public int? IdInstitutieAsociata
		{
			get { return _idInstitutie; }
			set { SetValue(ref _idInstitutie, value); }
		}

		public InstitutieAsociata InstitutieAsociataObj
		{
			get { return _institutieAsociataObj; }
			set { SetValue(ref _institutieAsociataObj, value); }
		}

		public UtilizatorViewModel()
		{
		}

		public UtilizatorViewModel(Utilizator utilizator)
		{
			_id = utilizator.Id;
			_userName = utilizator.UserName;
			_password = utilizator.Password;
			_tip = utilizator.TipUtilizator;
			_idInstitutie = utilizator.InstitutieAsociata;
			_institutieAsociataObj = utilizator.IntInstitutieAsociataObj;
		}
	}
}