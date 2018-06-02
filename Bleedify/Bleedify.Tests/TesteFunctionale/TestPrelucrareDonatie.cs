using System.Linq;
using BleedifyPersonal.ViewModels;
using BleedifyPersonal.Views;
using BleedifyServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bleedify.Tests.TesteFunctionale
{
	[TestClass]
	public class TestPrelucrareDonatie
	{
		private ComponentaService _componentaService;

		[TestInitialize]
		public void InitializeTests()
		{
			_componentaService = new ComponentaService();
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

			// select a viable donatie
			var donatie = manageDonatiiViewModel.Donatii[0];

			manageDonatiiViewModel.SelectedDonatie = donatie;
			manageDonatiiViewModel.PrelucreazaDonatieCommand.Execute(null);

		}

		[TestCleanup]
		public void CleanupTests()
		{

		}
	}
}