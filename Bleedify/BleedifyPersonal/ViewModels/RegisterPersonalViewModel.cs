using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
using BleedifyPersonal.Views;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyPersonal.ViewModels
{
	public class RegisterPersonalViewModel : BaseViewModel
	{
		public ICommand HandleRegisterCommand
		{
			get;
			private set;
		}

		public InstitutieAsociata InstitutieSelectata
		{
			get;
			set;
		}

		public PersonalViewModel PersonalViewModel
		{
			get;
			set;
		}

		public ObservableCollection<InstitutieAsociata> InstitutiiAsociate
		{
			get;
			set;
		}

		public RegisterPersonalViewModel()
		{
			PersonalViewModel = new PersonalViewModel();
			InstitutiiAsociate = new ObservableCollection<InstitutieAsociata>();
			HandleRegisterCommand = new BasicCommandWithParameter(Register);
			var institutii = AppService.Instance.InstitutieAsociataService.GetAll();
			institutii.ToList().ForEach(x =>
			{
				InstitutiiAsociate.Add(x);
			});

			InstitutieSelectata = InstitutiiAsociate[0];
		}

		private void Register(object obj)
		{	
			// check if fields null
			try
			{
				var pass = ((PasswordBox)obj).Password;
				var personal = new Personal();
				personal.Nume = PersonalViewModel.Nume;
				personal.Prenume = PersonalViewModel.Prenume;
				personal.UserName = PersonalViewModel.Username;
				personal.Password = pass;
				personal.TipUtilizator = TipUtilizator.Personal.ToString();
				personal.InstitutieAsociata = InstitutieSelectata.Id;
				AppService.Instance.PersonalService.Add(personal);
				MessageBox.Show("Contol a fost creat cu succes!", "Info", MessageBoxButton.OK);
				var loginView = new LoginView();
				loginView.Show();
				Application.Current.MainWindow.Close();
				Application.Current.MainWindow = loginView;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
			}
		}
	}
}