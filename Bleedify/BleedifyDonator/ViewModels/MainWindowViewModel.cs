using System.Windows;
using System.Windows.Input;
using BleedifyDonator.Utils;
using BleedifyMedic.Views;
using BleedifyModels.ModelsEF;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyDonator.ViewModels
{
	class MainWindowViewModel : BaseViewModel
	{	
		public ICommand HandleLogoutCommand { get; private set; }

		public string NumeUtilizator{ get; set; }
		public string GrupaDeSange { get; set; }
		public string InstitutieUtilizator { get; set; }

		public MainWindowViewModel()
		{
			var utilizator = AppSettings.LoggedDonator;
			NumeUtilizator = utilizator.Nume + " " + AppSettings.LoggedDonator.Prenume;
			InstitutieUtilizator = utilizator.Utilizator.InstitutieAsociata1.Nume;
			GrupaDeSange = utilizator.GrupaDeSangeObj.ToString();
			HandleLogoutCommand = new BasicCommand(Logout);
		}

		private void Logout()
		{
			var loginView = new LoginView();
			loginView.Show();
			Application.Current.MainWindow.Close();
			Application.Current.MainWindow = loginView;
		}
	}
}
