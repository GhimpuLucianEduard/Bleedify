using System.Linq;
using BleedifyPersonal.ViewModels;
using BleedifyServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bleedify.Tests.TesteFunctionale
{
	[TestClass]
	public class TestModificaAnuntaDonator
	{
		[TestClass]
		public class TestPrelucrareDonatie
		{	
			private DonatieService _donatieService = new DonatieService();
			private AnuntDonatorService _anuntDonatorService = new AnuntDonatorService();
			private string _oldValue;

			[TestInitialize]
			public void InitializeTests()
			{

			}

			[TestMethod]
			public void PrelucreazaTest()
			{
				var initialCount = _anuntDonatorService.GetAll().Count();
				// create view model
				var viewModel = new ManageDonatiiViewModel();
				if (viewModel.Donatii.Count <= 0)
				{
					return;
				}

				viewModel.SelectedDonatie = viewModel.Donatii[0];
				_oldValue = viewModel.SelectedDonatie.EtapaDonare;
				viewModel.SelectedDonatie.EtapaDonare = "TESTFUNCTIONAL";
				Assert.IsTrue(_anuntDonatorService.GetAll().Count() == initialCount + 1);
			}

			[TestCleanup]
			public void CleanupTests()
			{
				_donatieService.GetAll().ToList().ForEach(x =>
				{
					if (x.EtapaDonare.CompareTo("TESTFUNCTIONAL") == 0)
					{
						x.EtapaDonare = _oldValue;
					}
				});
			}
		}
	}
}