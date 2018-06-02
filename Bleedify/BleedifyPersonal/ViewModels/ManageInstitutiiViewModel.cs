using System.Collections.ObjectModel;
using System.Linq;
using BleedifyServices;
using DomainViewModels;

namespace BleedifyPersonal.ViewModels
{
	public class ManageInstitutiiViewModel : BaseViewModel
	{

		public ObservableCollection<InstitutieAsociataViewModel> Institutii { get; set; }

		public ManageInstitutiiViewModel()
		{
			Institutii = new ObservableCollection<InstitutieAsociataViewModel>();
			LoadData();
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