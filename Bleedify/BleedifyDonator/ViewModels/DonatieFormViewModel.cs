using System;
using System.Windows;
using System.Windows.Input;
using BleedifyDonator.Utils;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
using BleedifyServices;
using DomainViewModels;
using DomainViewModels.Commands;

namespace BleedifyDonator.ViewModels
{
	public class DonatieFormViewModel : BaseViewModel
	{
		public event EventHandler<Donatie> DonatieAdded;

		public ICommand AddDonatieCommand { get; set; }

		public DonatieFormViewModel()
		{
			AddDonatieCommand = new BasicCommand(DonatieAddAction);
		}

		private void DonatieAddAction()
		{
			var donatie = new Donatie
			{
				GrupaDeSange = AppSettings.LoggedDonator.GrupaDeSange,
				IdDonator = AppSettings.LoggedDonator.Id,
				DataDonare = DateTime.Now,
				InstitutieAsociata = AppSettings.LoggedDonator.InstitutieAsociata,
				EtapaDonare = "De Analizat"
			};
			AppService.Instance.DonatieService.Add(donatie);

			var anunt = new AnuntDonator();
			anunt.IdDonator = AppSettings.LoggedDonator.Id;
			anunt.TipAnuntDonator = TipAnuntDonator.Info.ToString();
			anunt.DataAnunt = DateTime.Now;
			anunt.Mesaj = "Donatia ta a fost inregistrata cu succes!";

			//TODO modifica aici ca sa vezi diferenta mai mare de timp
			var date = DateTime.Now;
			//date = date.AddMinutes(1);
			date = date.AddSeconds(5);
			AppSettings.LoggedDonator.DataDonarePosibila = date;
			AppService.Instance.DonatorService.Update(AppSettings.LoggedDonator);
			DonatieAdded?.Invoke(this, donatie);

			MessageBox.Show("Donatia ta a fost inregistrata! Vino la cel mai apropiat centru pentru urmatoarea etapa!", "Succes", MessageBoxButton.OK);
		}
	}
}