using System.Collections.ObjectModel;
using System.Linq;
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
			Mesaje = new ObservableCollection<AnuntDonator>
					(AppService.Instance.AnuntDonatorService.Filter(AppSettings.LoggedDonator.Id).OrderByDescending(x => x.DataAnunt));
		}
	}
}