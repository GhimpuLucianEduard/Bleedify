using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BleedifyPersonal.ViewModels
{
    public class ManageComponenteViewModel
    {
        private bool _isDataLoaded;

        public ObservableCollection<ComponentaViewModel> Componente { get; private set; } = new ObservableCollection<ComponentaViewModel>();

        public ICommand LoadComponenteCommand { get; private set; }

        public ManageComponenteViewModel()
        {
            LoadComponenteCommand = new BasicCommand(LoadData);
        }

        private void LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var components = AppService.Instance.ComponentaService.Filter(null, null);

            foreach (var c in components)
                Componente.Add(new ComponentaViewModel(c));
        }
    }
}
