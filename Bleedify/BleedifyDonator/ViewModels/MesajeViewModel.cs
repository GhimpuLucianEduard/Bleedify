using System.Collections.ObjectModel;
using BleedifyDonator.Utils;
using BleedifyModels.ModelsEF;
using BleedifyServices;
using DomainViewModels;

namespace BleedifyDonator.ViewModels
{
	public class MesajeViewModel : BaseViewModel
	{
		public ObservableCollection<AnuntDonator> Mesaje { get; set; }

		public MesajeViewModel()
		{
			Mesaje = new ObservableCollection<AnuntDonator>(AppService.Instance.AnuntDonatorService.Filter(AppSettings.LoggedDonator.Id));
		}
	}
}