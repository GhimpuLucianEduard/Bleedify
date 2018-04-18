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
    public class DonatieTests
    {
        private Donatie _testDonatie;


        [TestInitialize]
        public void InitializeTest()
        {
            _testDonatie = new Donatie();
        }


        [TestMethod]
        public void TestGettersDonatie()
        {                     
            _testDonatie.Id = 1;
            _testDonatie.IdDonator = 2;
            _testDonatie.MotivRefuz = "Mister";
            _testDonatie.EtapaDonare = "Bleedify";
            _testDonatie.Componentas = new List<Componenta>();
            
            Assert.IsTrue(_testDonatie.Id == 1);
            Assert.IsTrue(_testDonatie.IdDonator == 2);
            Assert.IsTrue(String.Compare(_testDonatie.MotivRefuz, "Mister") == 0);
            Assert.IsTrue(String.Compare(_testDonatie.EtapaDonare, "Bleedify") == 0);
            Assert.IsTrue(_testDonatie.Componentas.Count == 0);            
        }

        [TestMethod]
        public void TestSettersDonatie()
        {
            _testDonatie.Id = 1;
            _testDonatie.IdDonator = 2;
            _testDonatie.MotivRefuz = "Mister";
            _testDonatie.EtapaDonare = "Bleedify";
            _testDonatie.Componentas = new List<Componenta>();

            Assert.IsTrue(_testDonatie.Id == 1);
            Assert.IsTrue(_testDonatie.IdDonator == 2);
            Assert.IsTrue(String.Compare(_testDonatie.MotivRefuz, "Mister") == 0);
            Assert.IsTrue(String.Compare(_testDonatie.EtapaDonare, "Bleedify") == 0);
            Assert.IsTrue(_testDonatie.Componentas.Count == 0);
        }

    }
}
