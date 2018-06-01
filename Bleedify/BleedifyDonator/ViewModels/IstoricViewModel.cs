using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using BleedifyDonator.Utils;
using BleedifyDonator.Views;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyDonator.ViewModels
{
	public class IstoricViewModel : BaseViewModel
	{

		//public DateTime DataDonarePosibila { get; set; }
		public ObservableCollection<Componenta> Componente { get; set; }

		public ObservableCollection<DonatieViewModel> Donatii
		{
			get;
			set;
		}

		public DonatieViewModel SelectedTonatie
		{
			get { return _selecteDonatie; }
			set
			{
				SetValue(ref _selecteDonatie, value);
			}
		}

		private DonatieViewModel _selecteDonatie;

		public ICommand LoadDonationsCommand { get; private set; }
		public ICommand SelectionChanged { get; private set; }
		public ICommand DoneazaCommand { get; private set; }

		public IstoricViewModel()
		{	
			Donatii = new ObservableCollection<DonatieViewModel>();
			LoadDonationsCommand = new BasicCommand(LoadData);
			SelectionChanged = new BasicCommand(GetComponente);
			DoneazaCommand = new BasicCommand(DoneazaAction);
			Componente = new ObservableCollection<Componenta>();
			//SetTimer();
		}

//		public void SetTimer()
//		{
//			DataDonarePosibila = AppSettings.LoggedDonator.DataDonarePosibila;
//		}

		private void DoneazaAction()
		{
			var viewModel = new DonatieFormViewModel();
			var win = new DoneazaForm(viewModel);
			win.Show();
			viewModel.DonatieAdded += (sender, args) =>
			{
				Donatii.Add(new DonatieViewModel(args as Donatie));
				win.Close();
			};
			
		}

		private void LoadData()
		{	
			var donations = AppService.Instance.DonatieService.GetAllByDonator(AppSettings.LoggedDonator.Id);
			foreach (var d in donations)
				Donatii.Add(new DonatieViewModel(d));
		}

		private Componenta _plasma;
		private Componenta _trombocite;
		private Componenta _globuleRosii;

		public Componenta Plasma
		{
			get { return _plasma; }
			set { SetValue(ref _plasma, value); }
		}

		public Componenta Trombocite
		{
			get { return _trombocite; }
			set { SetValue(ref _trombocite, value); }
		}

		public Componenta GlobuleRosii
		{
			get { return _globuleRosii; }
			set { SetValue(ref _globuleRosii, value); }
		}

		private void GetComponente()
		{
			Componente = new ObservableCollection<Componenta>(AppService.Instance.ComponentaService.GetComponenteByIdDonatie(SelectedTonatie.Id));
			if (Componente.Count >= 3)
			{
				Componente.ToList().ForEach(x =>
				{
					if (x.TipComponenta.CompareTo(TipComponenta.Plasma.ToString()) == 0)
					{
						Plasma = x;
					}
					else if (x.TipComponenta.CompareTo(TipComponenta.GlobuleRosii.ToString()) == 0 || x.TipComponenta.CompareTo("Globule Rosii")==0)
					{
						GlobuleRosii = x;
					}
					else if (x.TipComponenta.CompareTo(TipComponenta.Trombocite.ToString())==0)
					{
						Trombocite = x;
					}
				});
			}
		}
	}
}