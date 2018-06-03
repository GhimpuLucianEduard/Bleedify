using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Input;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyPersonal.ViewModels
{
	public class ManageCereriViewModel : BaseViewModel
	{
		private Componenta _selectedComponenta;
		private CerereViewModel _selectedCerere;
		private bool _isDataLoaded;
		private string _selectedStare;
		private GrupaDeSange _selectedGrupa;
		private string _selectedTip;

		public ObservableCollection<CerereViewModel> Cereri { get; private set; } =
			new ObservableCollection<CerereViewModel>();

		public ObservableCollection<Componenta> Componente { get; private set; } =
			new ObservableCollection<Componenta>();


		public ObservableCollection<string> Stari { get; private set; }
		public ObservableCollection<GrupaDeSange> Grupe { get; private set; }
		public ObservableCollection<string> Tipuri { get; private set; }


		public ICommand FilterCereriCommand { get; private set; }
		public ICommand ClearFilterCereriCommand { get; private set; }
		public ICommand LoadCereriCommand { get; private set; }
		public ICommand LoadComponenteCommand { get; private set; }
		public ICommand DeservireCommand { get; private set; }

		public Componenta SelectedComponenta
		{
			get { return _selectedComponenta; }
			set { SetValue(ref _selectedComponenta, value); } 
		}

		public string SelectedStare
		{
			get { return _selectedStare; }
			set { SetValue(ref _selectedStare, value); }
		}

		public GrupaDeSange SelectedGrupa
		{
			get { return _selectedGrupa; }
			set { SetValue(ref _selectedGrupa, value); }
		}

		public string SelectedTip
		{
			get { return _selectedTip; }
			set { SetValue(ref _selectedTip, value); }
		}

		public CerereViewModel SelectedCerere
		{
			get { return _selectedCerere; }
			set { SetValue(ref _selectedCerere, value); }
		}

		public ManageCereriViewModel()
		{
			Stari = new ObservableCollection<string>();
			Stari.Add("Toate");
			foreach (var stare in Enum.GetValues(typeof(StareCerere)))
			{
				Stari.Add(stare.ToString());
			}

			SelectedStare = Stari[0];

			Grupe = new ObservableCollection<GrupaDeSange>();
			Grupe.Add(new GrupaDeSange()
			{
				Id = 0,
				Nume = "Toate"
			});
			foreach (var g in AppService.Instance.GrupaDeSangeService.GetAll())
			{
				Grupe.Add(g);
			}

			SelectedGrupa = Grupe[0];

			Tipuri = new ObservableCollection<string>();
			Tipuri.Add("Toate");
			foreach (var tip in Enum.GetValues(typeof(TipComponenta)))
			{
				Tipuri.Add(tip.ToString());
			}

			SelectedTip = Tipuri[0];

			FilterCereriCommand = new BasicCommand(FilterCereri);
			ClearFilterCereriCommand = new BasicCommand(ClearFilterCereri);
			LoadCereriCommand = new BasicCommand(LoadData);
			LoadComponenteCommand = new BasicCommand(LoadComponente);
			DeservireCommand = new BasicCommand(Deservire);
		}

		private void Deservire()
		{
			if (SelectedCerere == null)
			{
				MessageBox.Show("Selecteaza o cerere.", "Atentie", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				if (SelectedCerere.Stare !="InAsteptare")
				{
					MessageBox.Show("Selecteaza o cerere in asteptare.", "Atentie", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				else
				{
					if (SelectedComponenta == null)
					{
						MessageBox.Show("Selecteaza o componenta.", "Atentie", MessageBoxButton.OK, MessageBoxImage.Information);
					}
					else
					{
						// modifica cererea
						try
						{
							var idDonator = SelectedComponenta.Donatie.IdDonator;
							var cerere = new CerereMedicPacient();
							cerere.Id = SelectedCerere.Id;
							cerere.IdPacient = SelectedCerere.IdPacient;
							cerere.IdMedic = SelectedCerere.IdMedic;
							cerere.DataDepunere = SelectedCerere.DataDepunere;
							cerere.DataServire = DateTime.Now;
							cerere.GrupaDeSange = SelectedCerere.IdGrupaDeSange;
							cerere.TipComponenta = SelectedCerere.TipComponenta;
							cerere.Stare = StareCerere.IncheiataPozitiv.ToString();

							AppService.Instance.CerereService.Update(cerere);
							SelectedCerere.Stare = StareCerere.IncheiataPozitiv.ToString();


							// modifica componenta

							var componenta = new Componenta();
							componenta.Id = SelectedComponenta.Id;
							componenta.TipComponenta = SelectedComponenta.TipComponenta;
							componenta.IdDonatie = SelectedComponenta.IdDonatie;
							componenta.DataDepunere = SelectedComponenta.DataDepunere;
							componenta.IdPrimitor = SelectedCerere.IdPacient;
							componenta.Stare = StareComponenta.Donata.ToString();

							AppService.Instance.ComponentaService.Update(componenta);
							Componente.Remove(SelectedComponenta);

							// adauga anunt la donator
							var anunt = new AnuntDonator();
							anunt.DataAnunt = DateTime.Now;
							anunt.IdDonator = idDonator;
							anunt.TipAnuntDonator = TipAnuntDonator.Info.ToString();
							anunt.Mesaj = "Salut, \n componenta ta de tipul:" + componenta.TipComponenta + " a fost donata cu succes!";
							AppService.Instance.AnuntDonatorService.Add(anunt);

							MessageBox.Show("Componenta a fost distribuita cu succes!", "Informare", MessageBoxButton.OK,
								MessageBoxImage.Information);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Atentie", MessageBoxButton.OK, MessageBoxImage.Information);
						}
					}
				}
			}
		}

		private void LoadData()
		{
			if (_isDataLoaded)
			{
				return;
			}

			_isDataLoaded = true;

			var cereri = AppService.Instance.CerereService.GetAll();
			

			foreach (var c in cereri)
			{
				Cereri.Add(new CerereViewModel(c));
			}
		}

		private void LoadComponente()
		{
			if (SelectedCerere == null)
			{
				MessageBox.Show("Selecteaza o cerere.", "Atentie", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				var filtru = "";
				if (SelectedCerere.TipComponenta.CompareTo("GlobuleRosii") == 0)
				{
					filtru= "Globule Rosii";
				}
				else
				{
					filtru = SelectedCerere.TipComponenta;
				}
				var componente = AppService.Instance.ComponentaService.Filter(
					filtru, 
					"In Asteptare", 
					SelectedCerere.GrupaDeSange.Nume);
				Componente.Clear();
				foreach (var x in componente)
				{
					Componente.Add(x);
				}
			}
		}

		public void FilterCereri()
		{
			int? ParamGrupa;
			string ParamStare;
			string ParamTip;

			if (SelectedStare.CompareTo(Stari[0]) == 0)
			{
				ParamStare = null;
			}
			else
			{
				ParamStare = SelectedStare;
			}

			if (SelectedTip.CompareTo(Tipuri[0]) == 0)
			{
				ParamTip = null;
			}
			else
			{
				ParamTip = SelectedTip;
			}

			if (SelectedGrupa == Grupe[0])
			{
				ParamGrupa = null;
			}
			else
			{
				ParamGrupa = SelectedGrupa.Id;
			}

			var cereri = AppService.Instance.CerereService.Filter(ParamGrupa, ParamTip, ParamStare);

			Cereri.Clear();
			foreach (var c in cereri)
			{
				Cereri.Add(new CerereViewModel(c));
			}
		}

		public void ClearFilterCereri()
		{
			var cereri = AppService.Instance.CerereService.GetAll();

			Cereri.Clear();
			foreach (var c in cereri)
			{
				Cereri.Add(new CerereViewModel(c));
			}

			SelectedStare = Stari[0];
			SelectedGrupa = Grupe[0];
			SelectedTip = Tipuri[0];
		}
	}
}
