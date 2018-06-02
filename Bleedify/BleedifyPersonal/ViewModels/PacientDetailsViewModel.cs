using System.Collections.ObjectModel;
using BleedifyModels.ModelsEF;
using BleedifyServices;
using DomainViewModels;

namespace BleedifyPersonal.ViewModels
{
	public class PacientDetailsViewModel : BaseViewModel
	{
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
			Pacient = pacientViewModel;
			GrupeDeSange = new ObservableCollection<GrupaDeSange>(AppService.Instance.GrupaDeSangeService.GetAll());
			InstitutiiAsociate = new ObservableCollection<InstitutieAsociata>(AppService.Instance.InstitutieAsociataService.GetAll());
			if (Pacient.Id == 0)
			{
				SelectedGrupa = GrupeDeSange[0];
				SelectedInstitutie = InstitutiiAsociate[0];
			}
			else
			{
				SelectedInstitutie = Pacient.InstitutieAsociata;
				SelectedGrupa = Pacient.GrupaDeSange;
			}
		}
	}
}