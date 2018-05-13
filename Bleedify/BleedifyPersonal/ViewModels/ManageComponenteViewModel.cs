using BleedifyPersonal.Views;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BleedifyPersonal.ViewModels
{
    public class ManageComponenteViewModel : BaseViewModel
    {
        private bool _isDataLoaded;

        private ComponentaViewModel _selectedComponenta;
        public ComponentaViewModel SelectedComponenta
        {
            get { return _selectedComponenta; }
            set { SetValue(ref _selectedComponenta, value); }
        }

        public ObservableCollection<ComponentaViewModel> Componente { get; private set; } = new ObservableCollection<ComponentaViewModel>();

        public ICommand LoadComponenteCommand { get; private set; }
        public ICommand DeleteDonatieCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }

        public ManageComponenteViewModel()
        {
            LoadComponenteCommand = new BasicCommand(LoadData);
            DeleteDonatieCommand = new BasicCommand(DeleteComponenta);
            UpdateCommand = new BasicCommand(UpdateComponenta);
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

        private void DeleteComponenta()
        {
            if (SelectedComponenta == null)
            {
                MessageBox.Show("You have to select a Componenta first...");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Componenta?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    AppService.Instance.ComponentaService.Delete(SelectedComponenta.Id);
                    Componente.Remove(SelectedComponenta);
                }
            }
        }

        private void UpdateComponenta()
        {
            if (SelectedComponenta == null)
            {
                MessageBox.Show("You have to select a donation first...");
            }
            else
            {
                var viewModel = new ComponentaDetailViewModel(SelectedComponenta);
                ComponentaMasterDetailView DetailPage = new ComponentaMasterDetailView(viewModel);
                DetailPage.Show();

                viewModel.ComponentaUpdated += (source, componenta) =>
                {
                    var componentavm = new ComponentaViewModel(componenta);

                    Componente.ToList().ForEach(d =>
                    {
                        if (d.Id == componentavm.Id)
                        {
                            d = componentavm;
                            d.Pacient.Nume = componentavm.Pacient.Nume;
                            d.Pacient.Prenume = componentavm.Pacient.Prenume;
                        }
                    });

                    DetailPage.Close();
                };
            }
        }
    }
}
