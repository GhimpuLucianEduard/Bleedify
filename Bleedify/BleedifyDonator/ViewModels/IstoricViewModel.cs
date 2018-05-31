using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using BleedifyDonator.Utils;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyDonator.ViewModels
{
	public class IstoricViewModel : BaseViewModel
	{	
		public ObservableCollection<Componenta> Componente { get; set; }
		private bool _isDataLoaded;
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

		public IstoricViewModel()
		{
			Donatii = new ObservableCollection<DonatieViewModel>();
			LoadDonationsCommand = new BasicCommand(LoadData);
			SelectionChanged = new BasicCommand(GetComponente);
			Componente = new ObservableCollection<Componenta>();
		}

		private void LoadData()
		{
			if (_isDataLoaded)
				return;

			_isDataLoaded = true;
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