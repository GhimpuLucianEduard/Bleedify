using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using BleedifyModels.ModelsEF;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyPersonal.ViewModels
{
	public class PacientDetailsViewModel : BaseViewModel
	{
		public event EventHandler<PacientViewModel> PacientAdded;
		public event EventHandler<PacientViewModel> PacientUpdated;

		public ICommand SalveazaCommand { get; private set; }

		public ObservableCollection<GrupaDeSange> GrupeDeSange { get; set; }
		public ObservableCollection<InstitutieAsociata> InstitutiiAsociate { get; set; }

		private InstitutieAsociata _selectedInstitutie;
		private GrupaDeSange _selectedGrupa;

		public InstitutieAsociata SelectedInstitutie
		{
			get { return _selectedInstitutie; }
			set { SetValue(ref _selectedInstitutie, value); }
		}

		public GrupaDeSange SelectedGrupa
		{
			get { return _selectedGrupa; }
			set { SetValue(ref _selectedGrupa, value); }
		}

		public PacientViewModel Pacient { get; set; }

		public PacientDetailsViewModel(PacientViewModel pacientViewModel)
		{
			if (pacientViewModel.Id != 0)
			{
				Pacient = new PacientViewModel();
				Pacient.Id = pacientViewModel.Id;
				Pacient.GrupaDeSange = pacientViewModel.GrupaDeSange;
				Pacient.DataNastere = pacientViewModel.DataNastere;
				Pacient.IdGrupaDeSange = pacientViewModel.IdGrupaDeSange;
				Pacient.InstitutieAsociata = pacientViewModel.InstitutieAsociata;
				Pacient.IdInstitutieAsociata = pacientViewModel.IdInstitutieAsociata;
				Pacient.Nume = pacientViewModel.Nume;
				Pacient.Prenume = pacientViewModel.Prenume;
			}
			GrupeDeSange = new ObservableCollection<GrupaDeSange>(AppService.Instance.GrupaDeSangeService.GetAll());
			InstitutiiAsociate = new ObservableCollection<InstitutieAsociata>(AppService.Instance.InstitutieAsociataService.GetAll());
			if (pacientViewModel.Id == 0)
			{
				SelectedGrupa = GrupeDeSange[0];
				SelectedInstitutie = InstitutiiAsociate[0];
			}
			else
			{
				SelectedInstitutie = Pacient.InstitutieAsociata;
				SelectedGrupa = Pacient.GrupaDeSange;
			}

			SalveazaCommand = new BasicCommand(Salveaza);
		}

		private void Salveaza()
		{
			if (string.IsNullOrWhiteSpace(Pacient.Nume)||
			    string.IsNullOrWhiteSpace(Pacient.Prenume))
			{
				MessageBox.Show("Date invalide.", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				try
				{
					var pacient = new Pacient();
					pacient.Nume = Pacient.Nume;
					pacient.Prenume = Pacient.Prenume;
					pacient.GrupaDeSange = SelectedGrupa.Id;
					pacient.InstitutieAsociata = SelectedInstitutie.Id;
					pacient.DataNastere = Pacient.DataNastere;


					var pacientVm = new PacientViewModel(pacient);
					pacientVm.GrupaDeSange = SelectedGrupa;
					pacientVm.InstitutieAsociata = SelectedInstitutie;

					if (Pacient.Id == 0)
					{
						// add
						AppService.Instance.PacientService.Add(pacient);
						PacientAdded?.Invoke(this, pacientVm);
					}
					else
					{	
						// update
						pacient.Id = Pacient.Id;
						pacientVm.Id = Pacient.Id;
						AppService.Instance.PacientService.Update(pacient);
						PacientUpdated?.Invoke(this, pacientVm);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
				}
			}
		}
	}
}