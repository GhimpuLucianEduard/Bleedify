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
    public class DonatorTests
    {
        private Donator _testDonator;


        [TestInitialize]
        public void InitializeTest()
        {
            _testDonator = new Donator();
        }


        [TestMethod]
        public void TestGettersDonator()
        {
            var _datetime = new DateTime(2018, 4, 14);

            _testDonator.Id = 1;
            _testDonator.IdUtilizator = 2;
            _testDonator.Nume = "Mister";
            _testDonator.Prenume = "Bleedify";
            _testDonator.DataDonarePosibila = _datetime;
            _testDonator.GrupaDeSange = 3;

            Assert.IsTrue(_testDonator.Id == 1);
            Assert.IsTrue(_testDonator.IdUtilizator == 2);
            Assert.IsTrue(String.Compare(_testDonator.Nume, "Mister") == 0);
            Assert.IsTrue(String.Compare(_testDonator.Prenume, "Bleedify") == 0);
            Assert.IsTrue(_testDonator.DataDonarePosibila == _datetime);
            Assert.IsTrue(_testDonator.GrupaDeSange == 3);
        }

    }
}
