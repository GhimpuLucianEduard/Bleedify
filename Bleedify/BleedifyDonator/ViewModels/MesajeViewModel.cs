using System.Collections.ObjectModel;
using BleedifyModels.ModelsEF;
using BleedifyServices;
using DomainViewModels;

namespace BleedifyDonator.ViewModels
{
	public class MesajeViewModel : BaseViewModel
	{
		public ObservableCollection<AnuntDonator> Mesaje;

		public MesajeViewModel()
		{
			Mesaje = new ObservableCollection<AnuntDonator>(AppService.Instance.AnuntDonatorService.GetAll());
		}
	}
}