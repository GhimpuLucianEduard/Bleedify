using System;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyPersonal.ViewModels;
using BleedifyPersonal.Views;
using BleedifyServices;
using BleedifyServices.Services;
using DomainViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bleedify.Tests.TesteFunctionale
{
	[TestClass]
	public class TestPrelucrareDonatie
	{	
		private DonatieService _donatieService = new DonatieService();
		private ComponentaService _componentaService = new ComponentaService();
		private DonatorService _donatorService = new DonatorService();
		private Donatie _donatiePrelucrabila;
		private Donator _donator;
		private Utilizator _utilizator;

		[TestInitialize]
		public void InitializeTests()
		{
			_donator = new Donator
			{
				DataDonarePosibila = DateTime.Now,
				GrupaDeSange = 7,
				Nume = "TestFunctionalPrelucrare",
				Prenume = "TestFunctionalPrelucrare",
				TipUtilizator = "Donator",
				InstitutieAsociata = 10,
				UserName = "TestFunctionalPrelucrare",
				Password = "TestFunctionalPrelucrare"
			};

			_donatorService.Add(_donator);

			// create a mock donatie

			_donatiePrelucrabila = new Donatie
			{
				GrupaDeSange = 6,
				DataDonare = DateTime.Now,
				IdDonator = _donator.Id,
				EtapaDonare = "Analizata",
				InstitutieAsociata = _donator.InstitutieAsociata,
				MotivRefuz = ""
			};

			_donatieService.Add(_donatiePrelucrabila);
		}

		[TestMethod]
		public void PrelucreazaTest()
		{
			// create de view
			var manageDonatiiViewModel = new ManageDonatiiViewModel();
			manageDonatiiViewModel.LoadDonationsCommand.Execute(null);
			// get inital componente count
			var initialCount = _componentaService.GetAll().Count();

			// pass test if there is no data
			if (initialCount <= 0)
			{
				return;
			}

			// select donatie
			manageDonatiiViewModel.Donatii.ToList().ForEach(x =>
			{
				if (x.Donator.Nume.CompareTo("TestFunctionalPrelucrare") == 0)
				{
					manageDonatiiViewModel.SelectedDonatie = x;
				}
			});

			// assert that this is a viable componenta
			Assert.IsTrue(manageDonatiiViewModel.SelectedDonatie.EtapaDonare.CompareTo("Analizata")==0);

			// execute prelucreaza command
			manageDonatiiViewModel.PrelucreazaDonatieCommand.Execute(null);

			var afterCount = _componentaService.GetAll().Count();
			Assert.IsTrue(afterCount == initialCount + 3);

		}

		[TestCleanup]
		public void CleanupTests()
		{
			_componentaService.GetAll().ToList().ForEach(x =>
			{
				if (x.Donatie.Donator.Nume.CompareTo("TestFunctionalPrelucrare") == 0)
				{
					_componentaService.Delete(x.Id);
				}
			});
			_donatieService.GetAll().ToList().ForEach(x =>
			{
				if (x.Donator.Nume.CompareTo("TestFunctionalPrelucrare") == 0)
				{
					_donatieService.Delete(x.Id);
				}
			});
			_donatorService.GetAll().ToList().ForEach(x =>
			{
				if (x.Nume.CompareTo("TestFunctionalPrelucrare") == 0)
				{
					_donatorService.Delete(x.Id);
				}
			});
		}
	}
}