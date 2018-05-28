using System.Collections.ObjectModel;
using System.Windows.Input;
using BleedifyDonator.Utils;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyDonator.ViewModels
{
	public class IstoricViewModel : BaseViewModel
	{
		private bool _isDataLoaded;
		public ObservableCollection<DonatieViewModel> Donatii
		{
			get;
			set;
		}

		public ICommand LoadDonationsCommand { get; private set; }

		public IstoricViewModel()
		{
			Donatii = new ObservableCollection<DonatieViewModel>();
			LoadDonationsCommand = new BasicCommand(LoadData);
		}

		private void LoadData()
		{
			if (_isDataLoaded)
				return;

			_isDataLoaded = true;
			//TODO de modificat in id donator logat
			var donations = AppService.Instance.DonatieService.GetAllByDonator(AppSettings.LoggedDonator.Id);
			foreach (var d in donations)
				Donatii.Add(new DonatieViewModel(d));
		}
	}
}