using BleedifyModels.ModelsEF;
using BleedifyServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleedify.Tests.Services
{
    [TestClass]
    public class DonatieServiceTests
    {
        private DonatieService _service;

        [TestInitialize]
        public void InitializeTests()
        {
            _service = new DonatieService();
        }

	    [TestMethod]
	    public void TestAdd()
	    {
		    var initalSize = _service.GetAll().Count();
		    var donatie = new Donatie()
		    {
			    EtapaDonare = "dsad",
			    DataDonare = DateTime.Now
		    };
			try
		    {
				_service.Add(donatie);
				_service.Delete((donatie.Id));
		    }
		    catch (Exception e)
		    {
			   Assert.Fail();
		    }

		    Assert.IsTrue(_service.GetAll().Count() == initalSize);
	    }

        [TestCleanup]
        public void CleanUpTest()
        {

        }
    }
}
