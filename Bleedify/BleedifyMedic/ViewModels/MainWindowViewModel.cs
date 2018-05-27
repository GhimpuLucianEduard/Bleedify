using System.Windows;
using System.Windows.Input;
using BleedifyMedic.Utils;
using BleedifyMedic.Views;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyMedic.ViewModels
{
	class MainWindowViewModel : BaseViewModel
	{	
		public ICommand HandleLogoutCommand { get; private set; }

		public string NumeUtilizator{ get; set; }

		public string InstitutieUtilizator { get; set; }

		public MainWindowViewModel()
		{
			var utilizator = AppSettings.LoggedMedic;
			NumeUtilizator = utilizator.Nume + " " + AppSettings.LoggedMedic.Prenume;
			InstitutieUtilizator = utilizator.Utilizator.InstitutieAsociata1.Nume;
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
