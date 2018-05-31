using BleedifyModels.ModelsEF;
﻿using BleedifyModels.Enums;
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
        private string _selectedStareComponenta;
        private string _selectedTipComponenta;
        private bool _isDataLoaded;

        private ComponentaViewModel _selectedComponenta;
        public ComponentaViewModel SelectedComponenta
        {
            get { return _selectedComponenta; }
            set
            {
                SetValue(ref _selectedComponenta, value);
                LoadCereri();
            }
        }

        private CerereViewModel _selectedCerere;
        public CerereViewModel SelectedCerere
        {
            get { return _selectedCerere; }
            set
            {
                SetValue(ref _selectedCerere, value);
            }
        }

        public ObservableCollection<ComponentaViewModel> Componente { get; private set; } = new ObservableCollection<ComponentaViewModel>();
        public ObservableCollection<CerereViewModel> Cereri { get; private set; } = new ObservableCollection<CerereViewModel>();
        public ObservableCollection<string> Stari { get; private set; }
        public ObservableCollection<string> Tipuri { get; private set; }

        public ICommand LoadComponenteCommand { get; private set; }
        public ICommand DeservireComponentaCommand { get; private set; }
        public ICommand DeleteDonatieCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand FilterComponenteCommand { get; private set; }
        public ICommand ClearFilterComponenteCommand { get; private set; }

        public ManageComponenteViewModel()
        {
            Stari = new ObservableCollection<string>();
            Stari.Add("Toate");
            foreach (var stare in Enum.GetValues(typeof(StareCerere)))
            {
                Stari.Add(stare.ToString());
            }
            SelectedStareComponenta = Stari[0];

            Tipuri = new ObservableCollection<string>();
            Tipuri.Add("Toate");
            foreach (var tip in Enum.GetValues(typeof(TipComponenta)))
            {
                Tipuri.Add(tip.ToString());
            }
            SelectedTipComponenta = Tipuri[0];

            LoadComponenteCommand = new BasicCommand(LoadData);
            DeleteDonatieCommand = new BasicCommand(DeleteComponenta);
            UpdateCommand = new BasicCommand(UpdateComponenta);
            DeservireComponentaCommand = new BasicCommand(DeservireComponenta);
            FilterComponenteCommand = new BasicCommand(FilterComponente);
            ClearFilterComponenteCommand = new BasicCommand(ClearFilterComponente);
        }

        private void FilterComponente()
        {
            string ParamStare;
            string ParamTip;

            if (SelectedStareComponenta.CompareTo(Stari[0]) == 0)
            {
                ParamStare = null;
            }
            else
            {
                if (SelectedStareComponenta.Equals("InAsteptare"))
                {
                    ParamStare = "In Asteptare";
                }
                else
                {
                    ParamStare = SelectedStareComponenta;
                }
            }

            if (SelectedTipComponenta.CompareTo(Tipuri[0]) == 0)
            {
                ParamTip = null;
            }
            else
            {
                if(SelectedTipComponenta.Equals("GlobuleRosii"))
                {
                    ParamTip = "GlobuleRosii";
                }
                else
                {
                    ParamTip = SelectedTipComponenta;
                }
            }

            var comp = AppService.Instance.ComponentaService.Filter(ParamTip, ParamStare);

            Componente.Clear();
            foreach (var c in comp)
            {
                Componente.Add(new ComponentaViewModel(c));
            }
        }

        private void ClearFilterComponente()
        {
            var comp = AppService.Instance.ComponentaService.GetAll();

            Componente.Clear();
            foreach (var c in comp)
            {
                Componente.Add(new ComponentaViewModel(c));
            }

            SelectedStareComponenta = Stari[0];
            SelectedTipComponenta = Tipuri[0];
        }

        public string SelectedTipComponenta
        {
            get { return _selectedTipComponenta; }
            set { SetValue(ref _selectedTipComponenta, value); }
        }

        public string SelectedStareComponenta
        {
            get { return _selectedStareComponenta; }
            set { SetValue(ref _selectedStareComponenta, value); }
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

        private void LoadCereri()
        {
            Cereri.Clear();

            var grupa = SelectedComponenta.Donatie.GrupaDeSange;
            var tip = SelectedComponenta.TipComponenta;

	        if (SelectedComponenta.Stare.CompareTo("InAsteptare")==0 || SelectedComponenta.Stare.CompareTo("In Asteptare")==0 )
	        {
		        if (tip.Equals("Globule Rosii"))
		        {
			        tip = "GlobuleRosii";
		        }

		        var cereri = AppService.Instance.CerereService.Filter(grupa, tip, "InAsteptare");

		        foreach (var c in cereri)
			        Cereri.Add(new CerereViewModel(c));
			}
        }

        private void DeleteComponenta()
        {
            if (SelectedComponenta == null)
            {
                MessageBox.Show("Selectateaza o componenta...");
            }
            else
            {
                if (MessageBox.Show("Confirmati stergerea componentei?", "Confirmare", System.Windows.MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    AppService.Instance.ComponentaService.Delete(SelectedComponenta.Id);
                    Componente.Remove(SelectedComponenta);
                }
            }
        }

        private void DeservireComponenta()
        {
            if (SelectedCerere == null || SelectedComponenta == null)
            {
                MessageBox.Show("Selecteaza o componenta si o cerere.");
            }
            else
            {	
				// update componenta
                SelectedComponenta.Stare = StareComponenta.Donata.ToString();
				var updateCompo = AppService.Instance.ComponentaService.Find(SelectedComponenta.Id);
	            updateCompo.Stare = StareComponenta.Donata.ToString();
	            updateCompo.IdPrimitor = SelectedCerere.IdPacient;
				AppService.Instance.ComponentaService.Update(updateCompo);

				// updatate cerere
	            var updateCerere = AppService.Instance.CerereService.Find(SelectedCerere.Id);
	            updateCerere.Stare = StareCerere.IncheiataPozitiv.ToString();
				AppService.Instance.CerereService.Update(updateCerere);
				LoadCereri();


                // send anunt
				var anunt = new AnuntDonator();
				anunt.DataAnunt = DateTime.Now;
	            anunt.IdDonator = SelectedComponenta.Donatie.IdDonator;
	            anunt.TipAnuntDonator = TipAnuntDonator.Info.ToString();
	            anunt.Mesaj = "Componenta de tipul " + SelectedComponenta.TipComponenta + " din donatia ta a fost donata!";
                AppService.Instance.AnuntDonatorService.Add(anunt);
	            MessageBox.Show("Componenta a fost donata!.");
			}
		}

        private void UpdateComponenta()
        {
            if (SelectedComponenta == null)
            {
                MessageBox.Show("Selecteaza o donatie...");
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
