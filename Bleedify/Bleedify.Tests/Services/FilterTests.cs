using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using BleedifyServices;
using BleedifyServices.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Bleedify.Tests.Services
{
    [TestClass]
    public class FilterTests
    {
        DonatieService _service = AppService.Instance.DonatieService;
        Donatie _donatie = new Donatie();

        [TestInitialize]
        public void InitializeTests()
        {            
            _donatie.IdDonator = 204;
            _donatie.DataDonare = System.DateTime.Now;
            _donatie.EtapaDonare = "<!@FilterTests@!>";
            _donatie.InstitutieAsociata = 3;
            _donatie.GrupaDeSange = 1;

            _service.Add(_donatie);
        }

        [TestMethod]
        public void FilterDonatieTest()
        { 
            var foundCount = _service.Filter("<!@FilterTests@!>", 1).ToList().Count;
            var donatie = _service.Filter("<!@FilterTests@!>", 1).OrderByDescending(x => x.Id).First();
            var allCount = _service.GetAll().ToList().Count;

            Assert.IsTrue(foundCount == 1);
            Assert.IsTrue(_donatie.Id == donatie.Id);
            Assert.IsTrue(allCount == _service.Filter(null, null).ToList().Count);
            Assert.IsTrue(allCount == _service.Filter(null, new Nullable<int>()).ToList().Count);
            Assert.IsTrue(allCount == _service.Filter("", null).ToList().Count);
            Assert.IsTrue(allCount == _service.Filter("", new Nullable<int>()).ToList().Count);                        
        }

        [TestCleanup]
        public void CleanupTests()
        {            
            _service.Delete(_donatie.Id);
        }

    }
}