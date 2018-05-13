using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
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
    public class ComponentaDetailViewModel : BaseViewModel
    {
        public ComponentaViewModel ComponentaViewModel { get; set; }

        public ObservableCollection<string> Stari { get; set; }
        public ObservableCollection<string> Tipuri { get; set; }

        public event EventHandler<Componenta> ComponentaUpdated;

        public ICommand CloseWindowCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public ComponentaDetailViewModel(ComponentaViewModel componentaViewModel)
        {
            ComponentaViewModel = componentaViewModel;

            CloseWindowCommand = new BasicCommandWithParameter(CloseWindow);
            SaveCommand = new BasicCommand(Save);

            Stari = new ObservableCollection<string>();
            Tipuri = new ObservableCollection<string>();

            foreach (var stare in Enum.GetValues(typeof(StareComponenta)))
            {
                if(stare.ToString().Equals("InAsteptare"))
                {
                    Stari.Add("In Asteptare");
                }
                else
                {
                    Stari.Add(stare.ToString());
                }

            }

            foreach (var tip in Enum.GetValues(typeof(TipComponenta)))
            {
                Tipuri.Add(tip.ToString());
            }

            if(ComponentaViewModel.Pacient == null)
            {
                NumePrimitor = "";
            }
            else
            {
                NumePrimitor = ComponentaViewModel.Pacient.Nume;
            }

            if (ComponentaViewModel.Pacient == null)
            {
                PrenumePrimitor = "";
            }
            else
            {
                PrenumePrimitor = ComponentaViewModel.Pacient.Prenume;
            }
            SelectedStare = ComponentaViewModel.Stare;
            SelectedTip = ComponentaViewModel.TipComponenta;
            DataDepunere = ComponentaViewModel.DataDepunere;

        }

        private void CloseWindow(object thisWindow)
        {
            var window = (Window)thisWindow;
            window.Close();
        }

        private string _numePrimitor;
        public string NumePrimitor
        {
            get { return _numePrimitor; }
            set { SetValue(ref _numePrimitor, value); }
        }

        private string _prenumePrimitor;
        public string PrenumePrimitor
        {
            get { return _prenumePrimitor; }
            set { SetValue(ref _prenumePrimitor, value); }
        }

        private string _selectedStare;
        public string SelectedStare
        {
            get { return _selectedStare; }
            set { SetValue(ref _selectedStare, value); }
        }

        private string _selectedTip;
        public string SelectedTip
        {
            get { return _selectedTip; }
            set { SetValue(ref _selectedTip, value); }
        }

        private DateTime _dataDepunere;
        public DateTime DataDepunere
        {
            get { return _dataDepunere; }
            set { SetValue(ref _dataDepunere, value); }
        }

        private void Save()
        {
            if((!String.IsNullOrWhiteSpace(NumePrimitor) && !String.IsNullOrWhiteSpace(PrenumePrimitor)) ||
               (String.IsNullOrWhiteSpace(NumePrimitor) && String.IsNullOrWhiteSpace(PrenumePrimitor)))
            {
                var foundPacients = AppService.Instance.PacientService.GetPacientByFullName(NumePrimitor, PrenumePrimitor);

                if (foundPacients.Count() == 0 && (!String.IsNullOrWhiteSpace(NumePrimitor) && !String.IsNullOrWhiteSpace(PrenumePrimitor)))
                {
                    MessageBox.Show("No Pacient with that name was found", "Error", MessageBoxButton.OK);
                }
                else
                {
                    if(foundPacients.Count() > 0)
                    {
                        var pacient = foundPacients.ToList()[0];
                        ComponentaViewModel.IdPrimitor = pacient.Id;
                        ComponentaViewModel.Pacient = new Pacient()
                        {
                            Id = pacient.Id,
                            Nume = NumePrimitor,
                            Prenume = PrenumePrimitor
                        };

                    }
                    ComponentaViewModel.Stare = SelectedStare;
                    ComponentaViewModel.TipComponenta = SelectedTip;
                    ComponentaViewModel.DataDepunere = DataDepunere;

                    var componenta = new Componenta(ComponentaViewModel.Id, ComponentaViewModel.TipComponenta, ComponentaViewModel.IdDonatie,
                                                    ComponentaViewModel.DataDepunere, ComponentaViewModel.IdPrimitor, ComponentaViewModel.Stare,
                                                    ComponentaViewModel.Pacient.Nume, ComponentaViewModel.Pacient.Prenume);

                    AppService.Instance.ComponentaService.Update(componenta);
                    MessageBox.Show("You have successfully updated the Componenta!", "Success", MessageBoxButton.OK);
                    ComponentaUpdated?.Invoke(this, componenta);
                }

                
            }
            else if (!String.IsNullOrWhiteSpace(NumePrimitor) && String.IsNullOrWhiteSpace(PrenumePrimitor) ||
                     String.IsNullOrWhiteSpace(NumePrimitor) && !String.IsNullOrWhiteSpace(PrenumePrimitor))
            {
                MessageBox.Show("You have to complete both of Pacient fields", "Error", MessageBoxButton.OK);
            }
                
        }
    }
}
