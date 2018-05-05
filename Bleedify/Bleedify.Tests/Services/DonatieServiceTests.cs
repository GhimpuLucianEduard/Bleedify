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
        public void UpdateDonatietest()
        {
            var donatie = new Donatie() { Id = 4, EtapaDonare = "forTestUpdate", DataDonare = DateTime.Now };
            _service.Update(donatie);

            var donatieFound = _service.Find(donatie.Id);
            Assert.IsTrue(donatie.EtapaDonare.Equals("forTestUpdate"));
        }

        [TestMethod]
        public void FindDonatieTest()
        {
            var findResult = _service.Find(1);
            Assert.IsTrue(findResult == null);

            // Already an entity with id 2 in db.
            findResult = _service.Find(2);
            Assert.IsFalse(findResult == null);
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            var donatie = new Donatie() { Id = 4, EtapaDonare = "forTest", DataDonare = DateTime.Now };
            _service.Update(donatie);
        }
    }
}
