using BleedifyModels.ModelsEF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleedify.Tests
{
    [TestClass]
    public class ComponentaTests
    {
        private Componenta _testComponenta;

        [TestInitialize]
        public void InitializeTest()
        {
            _testComponenta = new Componenta();
        }

        [TestMethod]
        public void TestGettersDonatie()
        {
            var _datetimeDepunere = new DateTime(2018, 4, 16);
            var _datetimeDonatie = new DateTime(2018, 4, 16);

            _testComponenta.Id = 1;
            _testComponenta.TipComponenta = "Tip1";
            _testComponenta.IdDonatie = 1;
            _testComponenta.DataDepunere = _datetimeDepunere;
            _testComponenta.IdPrimitor = 1;
            _testComponenta.InstitutieAsociata = 1;
            _testComponenta.GrupaDeSange = 1;
            _testComponenta.DataDonare = _datetimeDonatie;
            _testComponenta.Stare = "Stare1";

            Assert.IsTrue(_testComponenta.Id == 1);
            Assert.IsTrue(String.Compare(_testComponenta.TipComponenta, "Tip1") == 0);
            Assert.IsTrue(_testComponenta.IdDonatie == 1);
            Assert.IsTrue(_testComponenta.DataDepunere == _datetimeDepunere);
            Assert.IsTrue(_testComponenta.IdPrimitor == 1);
            Assert.IsTrue(_testComponenta.InstitutieAsociata == 1);
            Assert.IsTrue(_testComponenta.GrupaDeSange == 1);
            Assert.IsTrue(_testComponenta.DataDonare == _datetimeDonatie);
            Assert.IsTrue(String.Compare(_testComponenta.Stare, "Stare1") == 0);
        }

        [TestMethod]
        public void TestSettersDonatie()
        {
            var _datetimeDepunere = new DateTime(2018, 4, 16);
            var _datetimeDonatie = new DateTime(2018, 4, 16);

            _testComponenta.Id = 1;
            _testComponenta.TipComponenta = "Tip1";
            _testComponenta.IdDonatie = 1;
            _testComponenta.DataDepunere = _datetimeDepunere;
            _testComponenta.IdPrimitor = 1;
            _testComponenta.InstitutieAsociata = 1;
            _testComponenta.GrupaDeSange = 1;
            _testComponenta.DataDonare = _datetimeDonatie;
            _testComponenta.Stare = "Stare1";

            Assert.IsTrue(_testComponenta.Id == 1);
            Assert.IsTrue(String.Compare(_testComponenta.TipComponenta, "Tip1") == 0);
            Assert.IsTrue(_testComponenta.IdDonatie == 1);
            Assert.IsTrue(_testComponenta.DataDepunere == _datetimeDepunere);
            Assert.IsTrue(_testComponenta.IdPrimitor == 1);
            Assert.IsTrue(_testComponenta.InstitutieAsociata == 1);
            Assert.IsTrue(_testComponenta.GrupaDeSange == 1);
            Assert.IsTrue(_testComponenta.DataDonare == _datetimeDonatie);
            Assert.IsTrue(String.Compare(_testComponenta.Stare, "Stare1") == 0);
        }
    }
}
