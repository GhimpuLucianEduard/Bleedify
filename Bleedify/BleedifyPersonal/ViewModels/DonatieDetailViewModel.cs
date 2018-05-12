using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BleedifyModels.ModelsEF;
using BleedifyPersonal.Views;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyPersonal.ViewModels
{
    public class DonatieDetailViewModel : BaseViewModel
    {
        public  DonatieViewModel DonatieViewModel { get; set; }
        public DonatieMasterDetailView view { get; set; }
		public bool IsAddState { get; set; }

        public ICommand AddCommand { get; private set; }
        public ICommand CloseWindowCommand { get; private set; }

        public event EventHandler<Donatie> DonatieAdded;
        public event EventHandler<Donatie> DonatieUpdated;

        public DonatieDetailViewModel(DonatieViewModel donatieViewModel)
        {
	        if (donatieViewModel.Id == 0)
	        {
		        IsAddState = true;
	        }
            DonatieViewModel = donatieViewModel;
            NumeDonator = DonatieViewModel.Donator.Nume;
            PrenumeDonator = DonatieViewModel.Donator.Prenume;
            SelectedInstitutie = DonatieViewModel.InstitutieAsociataObj;

            AddCommand = new BasicCommand(Save);
            CloseWindowCommand = new BasicCommandWithParameter(CloseWindow);
        }

        public IList<InstitutieAsociata> Institutii
        {
            get
            {
                return AppService.Instance.InstitutieAsociataService.GetAll().ToList();
            }
        }

        private InstitutieAsociata _selectedInstitutie;
        public InstitutieAsociata SelectedInstitutie
        {
            get
            {
                return _selectedInstitutie;
            }
            set
            {
                SetValue(ref _selectedInstitutie, value);
            }
        }
        public string NumeDonator { get; set; }
        public string PrenumeDonator { get; set; }
		public bool IsUpdate { get; set; }

        public void Save()
        {
            var test3 = SelectedInstitutie;
            if (String.IsNullOrEmpty(NumeDonator) ||
                String.IsNullOrEmpty(PrenumeDonator) ||
                DonatieViewModel.DataDonare == null ||
                String.IsNullOrEmpty(DonatieViewModel.EtapaDonare) ||
                SelectedInstitutie == null)
            {
                MessageBox.Show("Plase make sure you completed all the fields correctly..", "Error", MessageBoxButton.OK);
            }

            try
            {
                Donator Donator = AppService.Instance.DonatorService.getDonatorByName(NumeDonator, PrenumeDonator);
                DonatieViewModel.DonatorId = Donator.Id;
                DonatieViewModel.GrupaDeSangeId = Donator.GrupaDeSange;
                DonatieViewModel.GrupaDeSange = Donator.GrupaDeSangeObj;
                DonatieViewModel.InstitutieAsociataId = SelectedInstitutie.Id;

                var donatie = new Donatie()
                {
                    Id = DonatieViewModel.Id,
                    IdDonator = DonatieViewModel.DonatorId,
                    DataDonare = DonatieViewModel.DataDonare,
                    EtapaDonare = DonatieViewModel.EtapaDonare,
                    InstitutieAsociata = DonatieViewModel.InstitutieAsociataId,
                    GrupaDeSange = DonatieViewModel.GrupaDeSangeId,
                    MotivRefuz = DonatieViewModel.MotivRefuz
                };

                if (DonatieViewModel.Id == 0)
                {
                    AppService.Instance.DonatieService.Add(donatie);
                    MessageBox.Show("Donation added successfully!", "Success", MessageBoxButton.OK);
                    DonatieAdded?.Invoke(this, donatie);
                }
                else
                {
                    AppService.Instance.DonatieService.Update(donatie);
                    MessageBox.Show("You have successfully updated the Donation!", "Success", MessageBoxButton.OK);
                    DonatieUpdated?.Invoke(this, donatie);
                }
            }
            catch (ServiceException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void CloseWindow(object thisWindow)
        {
            var window = (Window)thisWindow;
            window.Close();
        }
    }
}
