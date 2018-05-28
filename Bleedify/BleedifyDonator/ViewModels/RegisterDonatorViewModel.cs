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

namespace BleedifyDonator.ViewModels
{
	public class RegisterDonatorViewModel : BaseViewModel
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

		public DonatorViewModel DonatorViewModel
		{
			get;
			set;
		}

		public ObservableCollection<GrupaDeSange> GrupeDeSange
		{
			get;
			set;
		}

		public ObservableCollection<InstitutieAsociata> InstitutiiAsociate
		{
			get;
			set;
		}

		public GrupaDeSange GrupaDeSange
		{
			get;
			set;
		}

		public RegisterDonatorViewModel()
		{	

			DonatorViewModel = new DonatorViewModel();
			InstitutiiAsociate = new ObservableCollection<InstitutieAsociata>();
			HandleRegisterCommand = new BasicCommandWithParameter(Register);
			var institutii = AppService.Instance.InstitutieAsociataService.GetAll();
			institutii.ToList().ForEach(x =>
			{
				InstitutiiAsociate.Add(x);
			});

			GrupeDeSange = new ObservableCollection<GrupaDeSange>();
			var grupe = AppService.Instance.GrupaDeSangeService.GetAll();
			grupe.ToList().ForEach(x =>
			{
				GrupeDeSange.Add(x);
			});

			GrupaDeSange = GrupeDeSange[0];
			InstitutieSelectata = InstitutiiAsociate[0];
		}

		private void Register(object obj)
		{	
			// check if fields null
			try
			{
				var pass = ((PasswordBox)obj).Password;
				var donator = new Donator();
				donator.Nume = DonatorViewModel.Nume;
				donator.Prenume = DonatorViewModel.Prenume;
				donator.DataDonarePosibila = DateTime.Now;
				donator.UserName = DonatorViewModel.Username;
				donator.Password = pass;
				donator.GrupaDeSange = GrupaDeSange.Id;
				donator.TipUtilizator = TipUtilizator.Donator.ToString();
				donator.InstitutieAsociata = InstitutieSelectata.Id;
				AppService.Instance.DonatorService.Add(donator);
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