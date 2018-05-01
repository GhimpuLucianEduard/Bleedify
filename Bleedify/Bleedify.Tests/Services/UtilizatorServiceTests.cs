using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using BleedifyServices.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bleedify.Tests.Services
{	
	[TestClass]
	public class UtilizatorServiceTests
	{
		private UtilizatorService _service;

		[TestInitialize]
		public void InitializeTests()
		{
			_service = new UtilizatorService();
		}

		[TestMethod]
		public void LoginTest()
		{
			var loginOk = _service.Login("test", "test");
			Assert.IsTrue(loginOk);
		}

	}
}