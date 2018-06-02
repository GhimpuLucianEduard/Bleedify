using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BleedifyModels.ModelsEF;
using BleedifyPersonal.Views;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyPersonal.ViewModels
{
	public class ManageInstitutiiViewModel : BaseViewModel
	{

		public ObservableCollection<InstitutieAsociataViewModel> Institutii { get; set; }

		private InstitutieAsociataViewModel _selectedInstitutie;

		public ICommand DeleteInstCommand { get; private set; }
		public ICommand AdaugaInstitutieCommand { get; private set; }
		public ICommand UpdateInstitutieCommand { get; private set; }

		public InstitutieAsociataViewModel SelectedInstitutie
		{
			get { return _selectedInstitutie; }
			set { SetValue(ref _selectedInstitutie, value); }
		}

		public ManageInstitutiiViewModel()
		{
			Institutii = new ObservableCollection<InstitutieAsociataViewModel>();
			LoadData();
			SelectedInstitutie = Institutii[0];
			DeleteInstCommand = new BasicCommand(DeleteInst);
			AdaugaInstitutieCommand = new BasicCommand(AdaugaInstitutie);
			UpdateInstitutieCommand = new BasicCommand(UpdateInstitutie);
		}

		private void UpdateInstitutie()
		{
			if (SelectedInstitutie == null)
			{
				MessageBox.Show("Selecteaza o Institutie", "Atentie", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				var win = new InstitutieDetail(SelectedInstitutie);
				win.Show();

				win.ViewModel.InstitutieUpdated += (sender, args) =>
				{
					var newInst = args;
					//				var old = Institutii.FirstOrDefault(x => x.Id == newInst.Id);
					//				old = new InstitutieAsociataViewModel(newInst);
					Institutii.ToList().ForEach(x =>
					{
						if (x.Id == newInst.Id)
						{
							x = new InstitutieAsociataViewModel(newInst);
						}
					});
					OnPropertyChanged(nameof(Institutii));
					win.Close();
				};
			}
		}

		private void AdaugaInstitutie()
		{	
			var win = new InstitutieDetail(new InstitutieAsociataViewModel());
			win.Show();
			win.ViewModel.InstitutieAdded += (sender, args) =>
			{
				var inst = args;
				Institutii.Add(new InstitutieAsociataViewModel(inst));
				win.Close();
			};
		}

		private void DeleteInst()
		{
			if (SelectedInstitutie == null)
			{
				MessageBox.Show("Selecteaza o Institutie", "Atentie", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				var canDelete = true;
				AppService.Instance.UtilizatorService.GetAll().ToList().ForEach(x =>
				{
					if (x.InstitutieAsociata == SelectedInstitutie.Id)
					{
						canDelete = false;
					}
				});

				AppService.Instance.PacientService.GetAll().ToList().ForEach(x =>
				{
					if (x.InstitutieAsociata == SelectedInstitutie.Id)
					{
						canDelete = false;
					}
				});

				if (canDelete)
				{
					AppService.Instance.InstitutieAsociataService.Delete(SelectedInstitutie.Id);
					Institutii.Remove(SelectedInstitutie);
				}
				else
				{
					MessageBox.Show("Institutia nu poate fi stearsa. \n Exista utilizatori legate la aceasta institutie.", "Atentie", MessageBoxButton.OK, MessageBoxImage.Information);
				}
			}
		}

		public void LoadData()
		{
			var institutiiToAdd = AppService.Instance.InstitutieAsociataService.GetAll();
			institutiiToAdd.ToList().ForEach(x=>
			{
				Institutii.Add(new InstitutieAsociataViewModel(x));
			});
		}
	}
}