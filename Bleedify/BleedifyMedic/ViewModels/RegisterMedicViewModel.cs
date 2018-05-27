using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BleedifyMedic.Views;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;
using MahApps.Metro.Controls.Dialogs;
using MaterialDesignThemes.Wpf;

namespace BleedifyMedic.ViewModels
{
	public class RegisterMedicViewModel : BaseViewModel
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

		public MedicViewModel MedicViewModel
		{
			get;
			set;
		}

		public ObservableCollection<InstitutieAsociata> InstitutiiAsociate
		{
			get;
			set;
		}

		public RegisterMedicViewModel()
		{
			MedicViewModel = new MedicViewModel();
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
				var medic = new Medic();
				medic.Nume = MedicViewModel.Nume;
				medic.Prenume = MedicViewModel.Prenume;
				medic.IdentificatorMedic = MedicViewModel.IdentificatorMedic;
				medic.UserName = MedicViewModel.Username;
				medic.Password = pass;
				medic.TipUtilizator = TipUtilizator.Medic.ToString();
				medic.InstitutieAsociata = InstitutieSelectata.Id;
				AppService.Instance.MedicService.Add(medic);
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