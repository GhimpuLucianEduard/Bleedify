using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BleedifyMedic.Utils;
using BleedifyMedic.Views;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyMedic.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		public UtilizatorViewModel User { get; set; }
		private PasswordBox passwordBox;
		public ICommand HandleLoginCommand { get; set; }
		public ICommand HandleRegister { get; set; }

		public LoginViewModel()
		{	
			User = new UtilizatorViewModel();
			HandleLoginCommand = new BasicCommandWithParameter(Login);
			HandleRegister = new BasicCommand(Register);
		}

		private void Register()
		{
			var win = new RegisterMedic();
			win.Show();
			Application.Current.MainWindow.Close();
			Application.Current.MainWindow = win;
		}

		private void Login(object obj)
		{
			var pwBox = obj as PasswordBox;
			if (string.IsNullOrWhiteSpace(User.Username) || string.IsNullOrWhiteSpace(pwBox.Password))
			{
				MessageBox.Show("Nume sau parola invalide!", "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else
			{
				var utilizator = AppService.Instance.UtilizatorService.Login(User.Username, pwBox.Password, TipUtilizator.Medic);
				if (utilizator != null)
				{
					MessageBox.Show("Login efectuat cu succes!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
					AppSettings.LoggedMedic = utilizator as Medic;
					var win = new MainWindow();
					win.Show();
					Application.Current.MainWindow.Close();
					Application.Current.MainWindow = win;
				}
				else
				{
					MessageBox.Show("Nume sau parola invalide!", "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}
	}
}