using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BleedifyPersonal.Views;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyPersonal.ViewModels
{
	public class ManagePacientiViewModel : BaseViewModel
	{
		public ObservableCollection<PacientViewModel> Pacienti { get; set; }

		private PacientViewModel _selectedPacient;

		public PacientViewModel SelectedPacient
		{
			get { return _selectedPacient; }
			set { SetValue(ref _selectedPacient, value); }
		}

		public ICommand DeletePacientCommand { get; private set; }
		public ICommand AddPacientCommand { get; private set; }
		public ICommand UpdatePacientCommand { get; private set; }

		public ManagePacientiViewModel()
		{
			Pacienti = new ObservableCollection<PacientViewModel>();
			AppService.Instance.PacientService.GetAll().ToList().ForEach(x =>
			{
				Pacienti.Add(new PacientViewModel(x));
			});
			DeletePacientCommand = new BasicCommand(DeletePacient);
			AddPacientCommand = new BasicCommand(AddPacient);
			UpdatePacientCommand = new BasicCommand(UpdatePacient);
//			Pacienti.CollectionChanged += (sender, args) =>
//			{
//				Debug.WriteLine("col event triggerd " + args.Action);
//			};
		}

		private void UpdatePacient()
		{
			if (SelectedPacient == null)
			{
				MessageBox.Show("Selecteaza un pacient.", "Atentie", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				var win = new PacientDetails(SelectedPacient);
				win.Show();
				win.ViewModel.PacientUpdated += OnUpdate;
			}
		}

		private void OnUpdate(object sender, PacientViewModel e)
		{
			Pacienti.ToList().ForEach(x =>
			{
				if (x.Id == e.Id)
				{
					x = e;
					x.Nume = e.Nume;
				}
			});
//			win.Close();
		}


		private void AddPacient()
		{
			var win = new PacientDetails(new PacientViewModel());
			win.Show();
			win.ViewModel.PacientAdded += (sender, args) =>
			{	

				Pacienti.Add(args);
				win.Close();
			};
		}

		private void DeletePacient()
		{
			if (SelectedPacient == null)
			{
				MessageBox.Show("Selecteaza un pacient.", "Atentie", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				var canDelete = true;
				AppService.Instance.CerereService.GetAll().ToList().ForEach(x =>
				{
					if (x.IdPacient == SelectedPacient.Id)
					{
						canDelete = false;
					}
				});

				if (!canDelete)
				{
					MessageBox.Show("Pacientul nu poate fi sters. \n Exista cereri pe numele pacientului.", "Atentie", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				else
				{
					AppService.Instance.PacientService.Delete(SelectedPacient.Id);
					Pacienti.Remove(SelectedPacient);
				}
			}
		}
	}
}