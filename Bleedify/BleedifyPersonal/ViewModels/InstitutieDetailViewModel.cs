using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyPersonal.ViewModels
{
	public class InstitutieDetailViewModel : BaseViewModel
	{
		
		public event EventHandler<InstitutieAsociata> InstitutieAdded;
		public event EventHandler<InstitutieAsociata> InstitutieUpdated;
		public InstitutieAsociataViewModel Institutie { get; set; }
		public AdresaViewModel Adresa { get; set; }

		public ObservableCollection<String> Tipuri { get; set; }
		private string _selectedTip;

		public String SelectedTip
		{
			get { return _selectedTip;}
			set
			{
				SetValue(ref _selectedTip, value);
			}
		}

		public ICommand AddInstitutieCommand { get; private set; }

		public InstitutieDetailViewModel(InstitutieAsociataViewModel institutieAsociataViewModel)
		{	
			Institutie = new InstitutieAsociataViewModel();

			if (institutieAsociataViewModel.Id != 0)
			{
				Institutie.Id = institutieAsociataViewModel.Id;
				Institutie.Nume = institutieAsociataViewModel.Nume;
				Institutie.Email = institutieAsociataViewModel.Email;
				Institutie.NrTel = institutieAsociataViewModel.NrTel;
				Institutie.Tip = institutieAsociataViewModel.Tip;
				Institutie.IdAdresa = institutieAsociataViewModel.IdAdresa;
				Institutie.Adresa = new Adresa();
			}

			if (institutieAsociataViewModel.Adresa == null)
			{
				Adresa = new AdresaViewModel();
			}
			else
			{
				Adresa = new AdresaViewModel(institutieAsociataViewModel.Adresa);
			}

			
			Tipuri = new ObservableCollection<String>(Enum.GetNames(typeof(TipInstitutieAsociata)).ToList());
			SelectedTip = Tipuri[0];
			AddInstitutieCommand = new BasicCommand(AddInstitutie);
		}

		private void AddInstitutie()
		{
			if (String.IsNullOrWhiteSpace(Institutie.Nume) ||
			    String.IsNullOrWhiteSpace(Institutie.Email) ||
			    String.IsNullOrWhiteSpace(Institutie.NrTel) ||
			    String.IsNullOrWhiteSpace(Adresa.Judet) ||
			    String.IsNullOrWhiteSpace(Adresa.Oras) ||
			    String.IsNullOrWhiteSpace(Adresa.Strada) ||
			    Adresa.CodPostal <= 0 ||
			    Adresa.Numarul <= 0)
			{
				MessageBox.Show("Date invalide", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				try
				{
					if (Institutie.Id == 0)
					{
						//add
						var adresa = new Adresa
						{
							CodPostal = Adresa.CodPostal,
							Strada = Adresa.Strada,
							Numarul = Adresa.Numarul,
							Judet = Adresa.Judet,
							Oras = Adresa.Oras
						};
						AppService.Instance.AdresaService.Add(adresa);
						var institutie = new InstitutieAsociata
						{
							Email = Institutie.Email,
							NumarTelefon = Institutie.NrTel,
							Nume = Institutie.Nume,
							Adresa = adresa.Id,
							TipInstitutie = SelectedTip
						};
						AppService.Instance.InstitutieAsociataService.Add(institutie);
						InstitutieAdded?.Invoke(this, institutie);
					}
					else
					{
						//update 
						var adresa = new Adresa
						{	
							Id = Adresa.Id,
							CodPostal = Adresa.CodPostal,
							Strada = Adresa.Strada,
							Numarul = Adresa.Numarul,
							Judet = Adresa.Judet,
							Oras = Adresa.Oras
						};
						AppService.Instance.AdresaService.Update(adresa);
						var institutie = new InstitutieAsociata
						{	
							Id = Institutie.Id,
							Email = Institutie.Email,
							NumarTelefon = Institutie.NrTel,
							Nume = Institutie.Nume,
							Adresa = adresa.Id,
							TipInstitutie = SelectedTip
						};
						AppService.Instance.InstitutieAsociataService.Update(institutie);
						InstitutieUpdated?.Invoke(this, institutie);
					}
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
				}
			}
		}
	}
}