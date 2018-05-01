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
    public class AnuntDonatorTests
    {
        private AnuntDonator _testAnuntDonator;


        [TestInitialize]
        public void InitializeTest()
        {
            _testAnuntDonator = new AnuntDonator();
        }


        [TestMethod]
        public void TestGettersAnuntDonator()
        {
            var _datetime = new DateTime(2018, 4, 14);

            _testAnuntDonator.Id = 1;
            _testAnuntDonator.IdDonator = 2;
            _testAnuntDonator.TipAnuntDonator = "Mister";
            _testAnuntDonator.Mesaj = "Bleedify";
            _testAnuntDonator.DataAnunt = _datetime;            

            Assert.IsTrue(_testAnuntDonator.Id == 1);
            Assert.IsTrue(_testAnuntDonator.IdDonator == 2);
            Assert.IsTrue(String.Compare(_testAnuntDonator.TipAnuntDonator, "Mister") == 0);
            Assert.IsTrue(String.Compare(_testAnuntDonator.Mesaj, "Bleedify") == 0);
            Assert.IsTrue(_testAnuntDonator.DataAnunt == _datetime);            
        }

        [TestMethod]
        public void TestSettersAnuntDonator()
        {
            var _datetime = new DateTime(2018, 4, 14);

            _testAnuntDonator.Id = 1;
            _testAnuntDonator.IdDonator = 2;
            _testAnuntDonator.TipAnuntDonator = "Mister";
            _testAnuntDonator.Mesaj = "Bleedify";
            _testAnuntDonator.DataAnunt = _datetime;

            Assert.IsTrue(_testAnuntDonator.Id == 1);
            Assert.IsTrue(_testAnuntDonator.IdDonator == 2);
            Assert.IsTrue(String.Compare(_testAnuntDonator.TipAnuntDonator, "Mister") == 0);
            Assert.IsTrue(String.Compare(_testAnuntDonator.Mesaj, "Bleedify") == 0);
            Assert.IsTrue(_testAnuntDonator.DataAnunt == _datetime);
        }
    }
}
